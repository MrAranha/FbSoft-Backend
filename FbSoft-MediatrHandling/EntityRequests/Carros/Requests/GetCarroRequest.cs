using FbSoft_MediatrHandling.EntityRequests.Carros.Results;
using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Requests
{
    public class GetCarroRequest : IRequest<IEnumerable<GetCarroResult>>
    {
        public int ID { get; set; }
    }
}
