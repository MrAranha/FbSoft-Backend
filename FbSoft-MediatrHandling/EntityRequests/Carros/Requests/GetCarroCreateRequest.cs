using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Requests
{
    public class GetCarroCreateRequest : IRequest<int>
    {
        public string Nome { get; set; }
        public string Ano { get; set; }
        public string Marca { get; set; }
    }
}
