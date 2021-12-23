using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingServer.Models;
using TicketBookingServer.ViewModels;
using System.Collections.Generic;

namespace TicketBookingServer.Controllers
{
    public class BookingController : Controller
    {
        private readonly IScreeningRepository _screeningRepository;
        private readonly IMovieRepository _movieRepository;
        private IOrderRepository _orderRepository;
        public BookingController(IScreeningRepository screeningRepository, IOrderRepository orderRepository, IMovieRepository movieRepository)
        {
            _screeningRepository = screeningRepository;
            _orderRepository = orderRepository;
            _movieRepository = movieRepository;
        }
        [HttpGet]
        public IActionResult CreateBooking(int id)
        {
            HttpContext.Session.SetInt32("screeningId", id);
            return RedirectToAction("","BookingEngine");
        }

        [HttpGet]
        public IActionResult GetSelectedScreeningData()
        {
            int screeningId = HttpContext.Session.GetInt32("screeningId") ?? 0;
            var screeningData = _screeningRepository.GetScreeningById(screeningId);
            return Json(screeningData);
        }

        [HttpPost]
        public IActionResult PostBookingData(int screeningId, IEnumerable<int> seatSelection)
        {
            try
            {
                List<ChosenSeat> chosenSeats = new List<ChosenSeat>();
                foreach (int seatNumber in seatSelection)
                {
                    chosenSeats.Add(new ChosenSeat
                    {
                        ScreeningId = screeningId,
                        SeatNumber = seatNumber,
                    });
                }
                var movieId = _screeningRepository.GetScreeningById(screeningId).MovieId;
                var movie = _movieRepository.GetMovieById(movieId);
                var order = new Order
                {
                    ScreeningId = screeningId,
                    MovieId = movieId,
                    UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    ChosenSeats = chosenSeats,
                    OrderTotal = chosenSeats.Count() * movie.Price
                };
            }
            catch
            {
                return StatusCode(500);
            }
            
            return StatusCode(200);
        }
    }
}