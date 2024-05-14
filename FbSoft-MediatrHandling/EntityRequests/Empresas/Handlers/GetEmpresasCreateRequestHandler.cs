using FbSoft_MediatrHandling.Entities;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Requests;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Empresas.Handlers
{
    public class GetEmpresasCreateRequestHandler : IRequestHandler<GetEmpresasCreateRequest, string>
    {
        private readonly IEmpresaRepository _repository;
        public GetEmpresasCreateRequestHandler(IEmpresaRepository repository) { _repository = repository; }
        public async Task<string> Handle(GetEmpresasCreateRequest request, CancellationToken cancellationToken)
        {
            /*
            return await _repository.Add(new TB_Empresas()
            {
            });*/
            return "";
        }
    }
}
