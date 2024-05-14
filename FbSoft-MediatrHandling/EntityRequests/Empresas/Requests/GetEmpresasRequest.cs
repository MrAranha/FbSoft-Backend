using FbSoft_MediatrHandling.EntityRequests.Empresas.Results;
using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Empresas.Requests
{
    public class GetEmpresasRequest : IRequest<IEnumerable<GetEmpresasResult>>
    {
    }
}
