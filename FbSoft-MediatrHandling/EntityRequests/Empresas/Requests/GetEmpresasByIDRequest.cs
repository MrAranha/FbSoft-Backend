using FbSoft_MediatrHandling.EntityRequests.Empresas.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Empresas.Requests
{
    public class GetEmpresasByIDRequest : IRequest<GetEmpresasByIDResult>
    {
        public string ID { get; set; }
    }
}
