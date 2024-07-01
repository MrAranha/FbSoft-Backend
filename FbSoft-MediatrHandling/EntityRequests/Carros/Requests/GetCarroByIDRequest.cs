using FbSoft_MediatrHandling.EntityRequests.Carros.Results;
using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Requests
{
    public class GetCarroByIDRequest : IRequest<GetCarroByIDResult>
    {
        public int ID { get; set; }
    }
}
