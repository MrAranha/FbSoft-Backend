using FbSoft_MediatrHandling.EntityRequests.Empresas.Requests;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Results;
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
    public class EmpresasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmpresasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<GetEmpresasResult>> GetAllEmpresas([FromQuery] GetEmpresasRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<GetEmpresasPagedResult>> Search([FromQuery] GetEmpresasPagedRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("save")]
        public async Task<string> CreateEmpresas([FromForm] GetEmpresasCreateRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("delete")]
        public async Task<bool> DeleteEmpresas([FromQuery] DeleteEmpresasRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("getById")]
        public async Task<GetEmpresasByIDResult> GetById([FromQuery] GetEmpresasByIDRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut("edit")]
        public async Task<bool> EditUser([FromForm] GetEmpresasEditRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
