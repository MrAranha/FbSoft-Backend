using FbSoft_MediatrHandling.EntityRequests.Carros.Results;
using FbSoft_MediatrHandling.Generics;
using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Requests
{
    public class GetCarroPagedRequest : PagedRequest, IRequest<IEnumerable<GetCarroPagedResult>>
    {
        public int? ID { get; set; }
        public string? Nome { get; set; }
        public string? Ano { get; set; }
        public string? Marca { get; set; }
    }
}
