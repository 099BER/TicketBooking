using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingServer.Models;
using TicketBookingServer.ViewModels;

namespace TicketBookingServer.Controllers
{
    public class MovieController : Controller
    {
        private readonly IScreeningRepository _screeningRepository;
        public MovieController(IScreeningRepository screeningRepository)
        {
            _screeningRepository = screeningRepository;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var screening = _screeningRepository.GetScreeningById(id);
            return View(screening);
        }
    }
}
