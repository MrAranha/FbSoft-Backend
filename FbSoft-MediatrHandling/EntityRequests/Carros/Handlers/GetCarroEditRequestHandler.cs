using FbSoft_MediatrHandling.EntityRequests.Carros.Requests;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Handlers
{
    public class GetCarroEditRequestHandler : IRequestHandler<GetCarroEditRequest, bool>
    {
        private readonly ICarroRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMailService _mailService;
        public GetCarroEditRequestHandler(ICarroRepository repository, IMailService mailService, IUserRepository userRepository) { _repository = repository; _mailService = mailService; _userRepository = userRepository; }
        public async Task<bool> Handle(GetCarroEditRequest request, CancellationToken cancellationToken)
        {
            var antigoCarro = await _repository.GetByID(request.Id);
            if(antigoCarro.Quantidade == 0 && request.Quantidade > 0)
            {
                var pedidos = await _repository.GetPedidos(antigoCarro.Id);
                foreach(var pedido in pedidos)
                {
                    var usuario = await _userRepository.GetByID(pedido.ID_Usuario);
                    _mailService.SendMail(new Entities.EmailDTO()
                    {
                        EmailBody = "NOVO " + antigoCarro.Nome + "EM ESTOQUE!",
                        EmailSubject = "NOVO " + antigoCarro.Nome + "EM ESTOQUE!",
                        EmailToId = usuario.email,
                        EmailToName = usuario.displayName
                    });
                    await _repository.DeletePedido(pedido.Id);
                }
            }
            await _repository.Edit(new Entities.TB_Carros()
            {
                Id = request.Id,
                Nome = request.Nome,
                Marca = request.Marca,
                Ano = request.Ano,
                Quantidade = request.Quantidade,
            });
            return true;
        }
    }
}
