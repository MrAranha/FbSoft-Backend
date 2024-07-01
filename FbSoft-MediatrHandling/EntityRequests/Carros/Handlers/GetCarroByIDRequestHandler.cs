using FbSoft_MediatrHandling.EntityRequests.Carros.Requests;
using FbSoft_MediatrHandling.EntityRequests.Carros.Results;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Handlers
{
    public class GetCarroByIDRequestHandler : IRequestHandler<GetCarroByIDRequest, GetCarroByIDResult>
    {
        private readonly ICarroRepository _carroRepository;
        public GetCarroByIDRequestHandler(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }
        public async Task<GetCarroByIDResult> Handle(GetCarroByIDRequest request, CancellationToken cancellationToken)
        {
            var result = await _carroRepository.GetByID(request.ID);
            return new GetCarroByIDResult()
            {
                ID = result.Id,
               Nome = result.Nome,
               Marca = result.Marca,
               Ano = result.Ano
            };
        }
    }
}
