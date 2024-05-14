using FbSoft_MediatrHandling.EntityRequests.Empresas.Requests;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Results;
using FbSoft_MediatrHandling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Empresas.Interfaces
{
    public interface IGetPagedEmpresasQuery
    {
        Task<IEnumerable<GetEmpresasPagedResult>> Get(GetEmpresasPagedRequest request);
    }
}
