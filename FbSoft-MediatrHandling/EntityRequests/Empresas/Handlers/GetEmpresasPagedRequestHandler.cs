using FbSoft_MediatrHandling.EntityRequests.Empresas.Interfaces;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Requests;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Results;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Empresas.Handlers
{
    public class GetEmpresasPagedRequestHandler : IRequestHandler<GetEmpresasPagedRequest, IEnumerable<GetEmpresasPagedResult>>
    {
        private readonly IGetPagedEmpresasQuery _getPagedUsersQuery;
        public GetEmpresasPagedRequestHandler(IGetPagedEmpresasQuery getPagedUsersQuery) { _getPagedUsersQuery = getPagedUsersQuery; }

        public async Task<IEnumerable<GetEmpresasPagedResult>> Handle(GetEmpresasPagedRequest request, CancellationToken cancellationToken)
        {
            return await _getPagedUsersQuery.Get(request);
        }
    }
}