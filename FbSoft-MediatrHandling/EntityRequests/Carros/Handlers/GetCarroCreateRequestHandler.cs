using FbSoft_MediatrHandling.EntityRequests.Carros.Requests;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Handlers
{
    public class GetCarroCreateRequestHandler : IRequestHandler<GetCarroCreateRequest, int>
    {
        private readonly ICarroRepository _repository;
        public GetCarroCreateRequestHandler(ICarroRepository repository) { _repository = repository; }
        public async Task<int> Handle(GetCarroCreateRequest request, CancellationToken cancellationToken)
        {
            return await _repository.Add(new FbSoft_MediatrHandling.Entities.TB_Carros()
            {
                Ano = request.Ano,
                Marca = request.Marca,
               Nome = request.Nome 
            });
        }
    }
}
