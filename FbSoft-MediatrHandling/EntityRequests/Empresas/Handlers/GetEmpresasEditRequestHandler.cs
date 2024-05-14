using FbSoft_MediatrHandling.Entities;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Requests;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Empresas.Handlers
{
    public class GetEmpresasEditRequestHandler : IRequestHandler<GetEmpresasEditRequest, bool>
    {
        private readonly IEmpresaRepository _repository;
        public GetEmpresasEditRequestHandler(IEmpresaRepository repository) { _repository = repository; }
        public async Task<bool> Handle(GetEmpresasEditRequest request, CancellationToken cancellationToken)
        {
            await _repository.Edit(new TB_Empresas()
            {
            });
            return true;
        }
    }
}
