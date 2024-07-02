using FbSoft_MediatrHandling.EntityRequests.Carros.Results;
using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Requests
{
    public class GetFazerPedidoCarroRequest : IRequest<GetFazerPedidoCarroResult>
    {
        public string user { get; set; }
        public int idCarro { get; set; }
    }
}
