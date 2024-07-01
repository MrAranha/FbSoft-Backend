using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Requests
{
    public class DeleteCarroRequest : IRequest<bool>
    {
        public int ID { get; set; }
    }
}
