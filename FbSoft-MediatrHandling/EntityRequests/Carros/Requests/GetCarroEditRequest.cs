using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Requests
{
    public class GetCarroEditRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Ano { get; set; }
        public string? Marca { get; set; }
    }
}
