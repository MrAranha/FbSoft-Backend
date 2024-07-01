using DevExpress.Mvvm.POCO;
using FbSoft_MediatrHandling.EntityRequests.Carros.Interfaces;
using FbSoft_MediatrHandling.EntityRequests.Carros.Requests;
using FbSoft_MediatrHandling.EntityRequests.Carros.Results;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Handlers
{
    public class DeleteCarroRequestHandler : IRequestHandler<DeleteCarroRequest, bool>
    {
        private readonly ICarroRepository _carroRepository;
        public DeleteCarroRequestHandler(ICarroRepository carroRepository) { _carroRepository = carroRepository; }

        public async Task<bool> Handle(DeleteCarroRequest request, CancellationToken cancellationToken)
        {
            return await _carroRepository.Delete(request.ID);
        }
    }
}