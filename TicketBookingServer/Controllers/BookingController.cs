﻿using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IScreeningRepository _screeningRepository;
        private readonly IMovieRepository _movieRepository;
        private IOrderRepository _orderRepository;
        private readonly IChosenSeatRepository _chosenSeatRepository;
        public BookingController(IScreeningRepository screeningRepository, IOrderRepository orderRepository, IMovieRepository movieRepository, IChosenSeatRepository chosenSeatRepository)
        {
            _screeningRepository = screeningRepository;
            _orderRepository = orderRepository;
            _movieRepository = movieRepository;
            _chosenSeatRepository = chosenSeatRepository;
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
            screeningData.Movie.Genre = null;
            return Json(screeningData);
        }

        [HttpGet]
        public IActionResult GetOccupiedSeatsForScreening()
        {
            int screeningId = HttpContext.Session.GetInt32("screeningId") ?? 0;
            var occupiedSeats = _chosenSeatRepository.GetOccupiedSeatsByScreeningId(screeningId);
            return Json(occupiedSeats);
        }

        [HttpPost]
        public IActionResult PostBookingData([FromBody] List<int> seatSelection)
        {
            int screeningId = HttpContext.Session.GetInt32("screeningId") ?? 0;
            System.Diagnostics.Debug.WriteLine(seatSelection.Count());
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
                    Screening = _screeningRepository.GetScreeningById(screeningId),
                    UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    ChosenSeats = chosenSeats,
                    OrderTotal = chosenSeats.Count() * movie.Price
                };

                _orderRepository.CreateOrder(order);
            }
            catch
            {
               
                return StatusCode(500);
            }

            return StatusCode(200);
        }

        [HttpGet]
        public IActionResult Manage()
        {
            var vm = new ManageBookingsViewModel
            {
                orders = _orderRepository.AllOrdersForUser(User.FindFirst(ClaimTypes.NameIdentifier).Value)
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult DeleteBookingByOrderId(int id)
        {
            _orderRepository.DeleteOrderById(id);
            return RedirectToAction("Manage");
        }
    }
}