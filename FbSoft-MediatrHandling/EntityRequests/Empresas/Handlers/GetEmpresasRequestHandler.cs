using AutoMapper;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Requests;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Results;
using FbSoft_MediatrHandling.Interfaces;
using FbSoft_Services.Entities;
using MediatR;
using System.Collections.Generic;

namespace FbSoft_MediatrHandling.EntityRequests.Empresas.Handlers
{
    public class GetEmpresasRequestHandler : IRequestHandler<GetEmpresasRequest, IEnumerable<GetEmpresasResult>>
    {
        private readonly IUserRepository _empRepository;
        private readonly IMapper _mapper;
        public GetEmpresasRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _empRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetEmpresasResult>> Handle(GetEmpresasRequest request, CancellationToken cancellationToken)
        {
            var result = await _empRepository.GetAll();
            return _mapper.Map<IEnumerable<GetEmpresasResult>>(result);
        }
    }
}
