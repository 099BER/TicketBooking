using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingServer.Models;
using TicketBookingServer.ViewModels;

namespace WebApplication2.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IMovieRepository _movieRepository;
        private IScreeningRepository _screeningRepository;
        private ITheatreRepository _theatreRepository;
        private ISeatingConfigRepository _seatingConfigRepository;
        private IGenreRepository _genreRepository;
        public AdminController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IMovieRepository movieRepository, IScreeningRepository screeningRepository,
            ITheatreRepository theatreRepository, ISeatingConfigRepository seatingConfigRepository, IGenreRepository genreRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _movieRepository = movieRepository;
            _screeningRepository = screeningRepository;
            _theatreRepository = theatreRepository;
            _seatingConfigRepository = seatingConfigRepository;
            _genreRepository = genreRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserManagement()
        {
            var users = _userManager.Users;
            return View(users);
        }
        /************************* Movie management methods **********************************/
        public IActionResult MovieManagement()
        {
            var movies = _movieRepository.AllMovies;
            return View(movies);
        }
        [HttpGet]
        public IActionResult AddMovie()
        {
            var movieAddEditViewModel = new MovieAddEditViewModel
            {
                Movie = new Movie(),
                Genres = _genreRepository.AllGenres
            };
            return View(movieAddEditViewModel);
        }
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            movie.Genre = _genreRepository.GetGenreById(movie.MovieId);
            movie.Duration = new TimeSpan(0, 2, 0, 0, 0);
            bool succeed = _movieRepository.AddMovie(movie);
            if (succeed)
            {
                return RedirectToAction("MovieManagement");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong adding the movie.");
            }

            return RedirectToAction("MovieManagement");
        }

        [HttpGet]
        public IActionResult UpdateMovie(int id)
        {
            Movie selectedMovie = _movieRepository.GetMovieById(id);
            if (selectedMovie != null)
            {
                var movieAddEditViewModel = new MovieAddEditViewModel
                {
                    Movie = selectedMovie,
                    Genres = _genreRepository.AllGenres
                };
                return View(movieAddEditViewModel);
            }
            else
            {
                ModelState.AddModelError("", "This movie cannot be found.");
            }
            return RedirectToAction("MovieManagement");
        }

        [HttpPost]
        public IActionResult UpdateMovie(Movie movie)
        {
            Movie selectedMovie = _movieRepository.GetMovieById(movie.MovieId);
            if (selectedMovie != null)
            {
                selectedMovie.Title = movie.Title;
                selectedMovie.Description = movie.Description;
                selectedMovie.ImageUrl = movie.ImageUrl;
                selectedMovie.GenreId = movie.GenreId;
                selectedMovie.Genre = _genreRepository.GetGenreById(movie.GenreId);
                selectedMovie.Price = Math.Round(movie.Price, 2);
                bool succeed = _movieRepository.UpdateMovie(selectedMovie);
                if (succeed)
                {
                    return RedirectToAction("MovieManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong while updating the movie.");
                }
            }
            else
            {
                ModelState.AddModelError("", "This movie cannot be found.");
            }
            return RedirectToAction("MovieManagement");
        }
        public IActionResult DeleteMovie(int id)
        {
            Movie selectedMovie = _movieRepository.GetMovieById(id);
            if (selectedMovie != null)
            {
                bool succeed = _movieRepository.DeleteMovie(selectedMovie);
                if (succeed)
                {
                    return RedirectToAction("MovieManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong while deleting the movie.");
                }
            }
            else
            {
                ModelState.AddModelError("", "This movie cannot be found.");
            }
            return RedirectToAction("MovieManagement");
        }

        /**************************************************************************************/
        /************************* Theatre management methods *********************************/
        public IActionResult TheatreManagement()
        {
            var theatreManagementViewModel = new TheatreManagementViewModel
            {
                Theatres = _theatreRepository.AllTheatres,
                SeatingConfigs = _seatingConfigRepository.AllSeatingConfigs
            };
            return View(theatreManagementViewModel);
        }
        [HttpGet]
        public IActionResult DeleteTheatre(int id)
        {
            Theatre selectedTheatre = _theatreRepository.GetTheatrebyId(id);
            if (selectedTheatre != null)
            {
                bool succeed = _theatreRepository.DeleteTheatre(selectedTheatre);
                if (succeed)
                {
                    return RedirectToAction("TheatreManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong while deleting the theatre.");
                }
            }
            else
            {
                ModelState.AddModelError("", "This theatre cannot be found.");
            }
            return RedirectToAction("TheatreManagement");
        }

        [HttpGet]
        public IActionResult EditTheatre(int id)
        {
            Theatre selectedTheatre = _theatreRepository.GetTheatrebyId(id);
            if (selectedTheatre != null)
            {
                var editTheatreViewModel = new EditTheatreViewModel
                {
                    Theatre = selectedTheatre,
                    SeatingConfigs = _seatingConfigRepository.AllSeatingConfigs
                };
                return View(editTheatreViewModel);
            }
            else
            {
                ModelState.AddModelError("", "This theatre cannot be found.");
            }
            return RedirectToAction("TheatreManagement");
        }

        [HttpPost]
        public IActionResult EditTheatre(Theatre theatre)
        {
            Theatre selectedTheatre = _theatreRepository.GetTheatrebyId(theatre.TheatreId);
            if (selectedTheatre != null)
            {
                selectedTheatre.Name = theatre.Name;
                selectedTheatre.Description = theatre.Description;
                selectedTheatre.SeatingConfig = _seatingConfigRepository.GetSeatingConfig(theatre.SeatingConfigId);
                selectedTheatre.SeatingConfigId = theatre.SeatingConfigId;
                bool succeed = _theatreRepository.UpdateTheatre(selectedTheatre);
                if (succeed)
                {
                    return RedirectToAction("TheatreManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong while editing the theatre.");
                }
            }
            else
            {
                ModelState.AddModelError("", "This theatre cannot be found.");
            }
            return RedirectToAction("TheatreManagement");
        }

        [HttpGet]
        public IActionResult AddTheatre()
        {
            var editTheatreViewModel = new EditTheatreViewModel
            {
                Theatre = new Theatre(),
                SeatingConfigs = _seatingConfigRepository.AllSeatingConfigs
            };
            return View(editTheatreViewModel);
        }

        [HttpPost]
        public IActionResult AddTheatre(Theatre theatre)
        {
            theatre.SeatingConfig = _seatingConfigRepository.GetSeatingConfig(theatre.SeatingConfigId);
            bool succeed = _theatreRepository.AddTheatre(theatre);
            if (succeed)
            {
                return RedirectToAction("TheatreManagement");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong adding the theatre.");
            }

            return RedirectToAction("TheatreManagement");
        }
        /***************************************************************************************/
        /*************************** Screening management **************************************/
        public IActionResult ScreeningManagement()
        {
            var screenings = _screeningRepository.AllScreening;
            return View(screenings);
        }
        [HttpGet]
        public IActionResult AddScreening()
        {
            var screeningAddEditViewModel = new ScreeningAddEditViewModel
            {
                Screening = new Screening(),
                TheatreList = _theatreRepository.AllTheatres,
                MovieList = _movieRepository.AllMovies
            };
            return View(screeningAddEditViewModel);
        }

        [HttpPost]
        public IActionResult AddScreening(Screening screening)
        {
            screening.Movie = _movieRepository.GetMovieById(screening.MovieId);
            screening.EndDateTime = screening.ScreeningDateTime.Add(screening.Movie.Duration);
            screening.Theatre = _theatreRepository.GetTheatrebyId(screening.TheatreId);

            // See if theres another screeening in the same time, same theatre
            var getConflicts = _screeningRepository.AllScreening.Where(s =>
            {
                bool sameTheatre = (s.TheatreId == screening.Theatre.TheatreId);
                bool startTimeOverlap = (s.ScreeningDateTime >= screening.ScreeningDateTime || s.EndDateTime >= screening.ScreeningDateTime);
                bool endTimeOverlap = (s.ScreeningDateTime <= screening.EndDateTime || s.EndDateTime <= screening.EndDateTime);
                return (startTimeOverlap || endTimeOverlap) && sameTheatre;
            });

            if(getConflicts.Count() > 0)
            {
                ModelState.AddModelError("", "There is a date/time conflict at this theatre.");
                var screeningAddEditViewModel = new ScreeningAddEditViewModel
                {
                    Screening = screening,
                    TheatreList = _theatreRepository.AllTheatres,
                    MovieList = _movieRepository.AllMovies
                };
                return View(screeningAddEditViewModel);
            }

            bool succeed = _screeningRepository.AddScreening(screening);
            if (succeed)
            {
                return RedirectToAction("ScreeningManagement");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong adding the screening.");
            }

            return RedirectToAction("ScreeningManagement");
        }

        [HttpGet]
        public IActionResult DeleteScreening(int id)
        {
            Screening selectedScreening = _screeningRepository.GetScreeningById(id);
            if (selectedScreening != null)
            {
                bool succeed = _screeningRepository.DeleteScreening(selectedScreening);
                if (succeed)
                {
                    return RedirectToAction("ScreeningManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong while deleting the screening.");
                }
            }
            else
            {
                ModelState.AddModelError("", "This screening cannot be found.");
            }
            return RedirectToAction("ScreeningManagement");
        }

        /***************************************************************************************/
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            if(!ModelState.IsValid) return View(addUserViewModel);
            var user = new IdentityUser()
            {
                UserName = addUserViewModel.UserName,
                Email = addUserViewModel.Email,
            };
            IdentityResult result = await _userManager.CreateAsync(user, addUserViewModel.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("UserManagement");
            }
            foreach(IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(addUserViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return RedirectToAction("UserManagement");
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string userName, string Email)
        {
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = Email;
                user.UserName = userName;
                var result = await _userManager.UpdateAsync(user);
                if(result.Succeeded)
                {
                    return RedirectToAction("UserManagement");
                }
                else
                {
                    ModelState.AddModelError("","Something went wrong");
                }
            }
            return RedirectToAction("UserManagement");
        }

        public async Task<IActionResult> DeleteUser(string userId)
        {
            IdentityUser user = await _userManager.FindByIdAsync(userId);

            if(user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if(result.Succeeded)
                {
                    return RedirectToAction("UserManagement");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong while deleting this user.");
                }
            }
            else
            {
                ModelState.AddModelError("", "This user cannot be found.");
            }
            return RedirectToAction("UserManagement");
        }
    }
}
