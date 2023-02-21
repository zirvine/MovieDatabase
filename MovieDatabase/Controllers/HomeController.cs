using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieDatabase.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EnterMovieContext _movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, EnterMovieContext movieContext)
        {
            _logger = logger;
            _movieContext = movieContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie(MovieResponse mr)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(mr);
                _movieContext.SaveChanges();

                return View("Confirmation");
            }

            else //invalid data
            {
                ViewBag.Categories = _movieContext.Categories.ToList();


                return View(mr);
            }
            
        }

        public IActionResult MovieList ()
        {
            var movies = _movieContext.responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var movie = _movieContext.responses.Single(x => x.MovieID == movieid);

            return View("EnterMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieResponse mr)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Update(mr);
                _movieContext.SaveChanges();

                return RedirectToAction("MovieList");
            }

            else //invalid data
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View("EnterMovie", mr);
            }
        }


        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = _movieContext.responses.Single(x => x.MovieID == movieid);


            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse mr)
        {
            _movieContext.responses.Remove(mr);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
