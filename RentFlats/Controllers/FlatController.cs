using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentFlats.Application.CQRS.Commands.CreateFlat;
using RentFlats.Application.CQRS.Commands.EditFlat;
using RentFlats.Application.CQRS.Queries.GetAllFlats;
using RentFlats.Application.CQRS.Queries.GetFlatByEncodedName;
using RentFlats.Application.Dtos;

namespace RentFlats.Controllers
{
    public class FlatController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FlatController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var flats = await _mediator.Send(new GetAllFlatsQuery());
            return View(flats);
        }
        [Route("Flat/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var flat = await _mediator.Send(new GetFlatByIdQuery(id));
            return View(flat);
        }
        [Route("Flat/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var flat = await _mediator.Send(new GetFlatByIdQuery(id));
            if(!flat.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }
            var model = _mapper.Map<EditFlatCommand>(flat);
            return View(model);
        }
        [HttpPost]
        [Route("Flat/{id}/Edit")]
        public async Task<IActionResult> Edit(int id, EditFlatCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
            
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateFlatCommand command)
        {         
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index)); 
        }
    }
}
