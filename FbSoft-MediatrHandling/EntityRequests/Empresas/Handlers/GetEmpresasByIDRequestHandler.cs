using FbSoft_MediatrHandling.EntityRequests.Empresas.Requests;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Results;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;
namespace FbSoft_MediatrHandling.EntityRequests.Empresas.Handlers
{
    public class GetEmpresasByIDRequestHandler : IRequestHandler<GetEmpresasByIDRequest, GetEmpresasByIDResult>
    {
        private readonly IEmpresaRepository _empRepository;
        public GetEmpresasByIDRequestHandler(IEmpresaRepository empRepository)
        {
            _empRepository = empRepository;
        }
        public async Task<GetEmpresasByIDResult> Handle(GetEmpresasByIDRequest request, CancellationToken cancellationToken)
        {
            var result = await _empRepository.GetByID(request.ID);
            return new GetEmpresasByIDResult()
            {/*
                ID = result.id,
                Name    = result.displayName,
                Email   = result.email,
                country = result.country,
                address = result.address,
                state   = result.state,
                city    = result.city,
                zipCode = result.zipCode,
                about   = result.about,
                role    = result.role*/
            };
        }
    }
}
