using FbSoft_MediatrHandling.EntityRequests.Users.Requests;
using FbSoft_MediatrHandling.EntityRequests.Users.Results;
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
        public async Task<IEnumerable<GetCarrosPagedResult>> Search([FromQuery] GetCarrosPagedRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("save")]
        public async Task<string> CreateCarro([FromForm] GetCarrosCreateRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteCarro([FromQuery] GetCarroRequest request)
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
