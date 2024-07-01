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
        public GetCarroEditRequestHandler(ICarroRepository repository) { _repository = repository; }
        public async Task<bool> Handle(GetCarroEditRequest request, CancellationToken cancellationToken)
        {
            await _repository.Edit(new Entities.TB_Carros()
            {
                Id = request.Id,
                Nome = request.Nome,
                Marca = request.Marca,
                Ano = request.Ano,
            });
            return true;
        }
    }
}
