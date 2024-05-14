using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Empresas.Requests
{
    public class DeleteEmpresasRequest : IRequest<bool>
    {
        public string ID { get; set; }
    }
}
