using System.Diagnostics;
using EBookCart.Models;
using EBookCart.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace EBookCart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }

        public async Task <IActionResult> Index(string sTerm="", int genreID =0)
        {
         
            IEnumerable<Book> books =  await _homeRepository.GetBooks(sTerm, genreID);
            IEnumerable<Genre> genres = await _homeRepository.Genres();
            BookDisplayModel bookDisplayModel = new BookDisplayModel
            {
                Books = books,
                Genres = genres,
                STerm = sTerm,
                GenreId= genreID
            };
            return View(bookDisplayModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}