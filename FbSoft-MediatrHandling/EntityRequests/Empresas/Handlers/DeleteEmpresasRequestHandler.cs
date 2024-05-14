
using DevExpress.Mvvm.POCO;
using FbSoft_MediatrHandling.EntityRequests.Users.Interfaces;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Requests;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Results;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Empresas.Handlers
{
    public class DeleteEmpresasRequestHandler : IRequestHandler<DeleteEmpresasRequest, bool>
    {
        private readonly IEmpresaRepository _empRepository;
        public DeleteEmpresasRequestHandler(IEmpresaRepository empRepository) { _empRepository = empRepository; }

        public async Task<bool> Handle(DeleteEmpresasRequest request, CancellationToken cancellationToken)
        {
            return await _empRepository.Delete(request.ID);
        }
    }
}