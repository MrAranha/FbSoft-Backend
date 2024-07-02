using AutoMapper;
using FbSoft_MediatrHandling.Entities;
using FbSoft_MediatrHandling.EntityRequests.Carros.Requests;
using FbSoft_MediatrHandling.EntityRequests.Carros.Results;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Handlers
{
    public class GetFazerPedidoCarroRequestHandler : IRequestHandler<GetFazerPedidoCarroRequest, GetFazerPedidoCarroResult>
    {
        private readonly IMapper _mapper;
        private readonly ICarroRepository _carroRepository;
        public GetFazerPedidoCarroRequestHandler(IUserRepository userRepository, IMapper mapper, ICarroRepository carroRepository)
        {
            _mapper = mapper;
            _carroRepository = carroRepository;
        }
        public async Task<GetFazerPedidoCarroResult> Handle(GetFazerPedidoCarroRequest request, CancellationToken cancellationToken)
        {
            var carro = await _carroRepository.GetByID(request.idCarro);
            if (carro.Quantidade == 0)
            {
                await _carroRepository.FazerPedido(new TB_Pedidos() { ID_Usuario = request.user, ID_Carro = request.idCarro });
                return new GetFazerPedidoCarroResult()
                { Id = 2 };
            }
            carro.Quantidade--;
            await _carroRepository.Edit(carro);
            return new GetFazerPedidoCarroResult()
            { Id = 0 };
        }
    }
}
