using AutoMapper;
using FbSoft_MediatrHandling.EntityRequests.Users.Requests;
using FbSoft_MediatrHandling.EntityRequests.Users.Results;
using FbSoft_MediatrHandling.Interfaces;
using FbSoft_Services.Entities;
using MediatR;
using System.Collections.Generic;

namespace FbSoft_MediatrHandling.EntityRequests.Users.Handlers
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, IEnumerable<GetUserResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetUserRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetUserResult>> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<GetUserResult>>(result);
        }
    }
}
