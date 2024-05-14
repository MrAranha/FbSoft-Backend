using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FbSoft_MediatrHandling.EntityRequests.Empresas.Requests
{
    public class GetEmpresasCreateRequest : IRequest<string>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
