using FbSoft_MediatrHandling.EntityRequests.Carros.Requests;
using FbSoft_MediatrHandling.EntityRequests.Carros.Results;
using FbSoft_MediatrHandling.Interfaces;
using FbSoft_Services.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;
using System.Security.Claims;

namespace FbSoft_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarrosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        public async Task<IEnumerable<GetCarroPagedResult>> Search([FromQuery] GetCarroPagedRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("save")]
        public async Task<int> CreateCarro([FromForm] GetCarroCreateRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteCarro([FromQuery] DeleteCarroRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("getById")]
        public async Task<GetCarroByIDResult> GetById([FromQuery] GetCarroByIDRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut("edit")]
        public async Task<bool> EditCarro([FromForm] GetCarroEditRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
