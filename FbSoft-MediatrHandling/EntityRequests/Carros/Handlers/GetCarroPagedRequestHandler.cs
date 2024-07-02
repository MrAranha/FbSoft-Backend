using FbSoft_MediatrHandling.EntityRequests.Carros.Interfaces;
using FbSoft_MediatrHandling.EntityRequests.Carros.Requests;
using FbSoft_MediatrHandling.EntityRequests.Carros.Results;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Handlers
{
    public class GetCarroPagedRequestHandler : IRequestHandler<GetCarroPagedRequest, IEnumerable<GetCarroPagedResult>>
    {
        private readonly IGetPagedCarroQuery _getPagedCarroQuery;
        public GetCarroPagedRequestHandler(IGetPagedCarroQuery getPagedCarroQuery) { _getPagedCarroQuery = getPagedCarroQuery; }

        public async Task<IEnumerable<GetCarroPagedResult>> Handle(GetCarroPagedRequest request, CancellationToken cancellationToken)
        {
            var result = await _getPagedCarroQuery.Get(request);
            return result;
        }
    }
}