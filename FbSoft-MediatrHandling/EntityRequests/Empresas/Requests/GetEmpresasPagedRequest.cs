using FbSoft_MediatrHandling.EntityRequests.Empresas.Results;
using FbSoft_MediatrHandling.Generics;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Empresas.Requests
{
    public class GetEmpresasPagedRequest : PagedRequest, IRequest<IEnumerable<GetEmpresasPagedResult>>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Empresa { get; set; }
        public string? id { get; set; }
    }
}
