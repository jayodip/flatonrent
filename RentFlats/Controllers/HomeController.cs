using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentFlats.Application.CQRS.Queries.GetAllFlats;
using RentFlats.Models;
using System.Diagnostics;

namespace RentFlats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var flats = await _mediator.Send(new GetAllFlatsQuery());
            return View(flats);
        }
        public IActionResult NoAccess()
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
