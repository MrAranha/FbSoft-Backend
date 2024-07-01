using FbSoft_MediatrHandling.EntityRequests.Carros.Requests;
using FbSoft_MediatrHandling.EntityRequests.Carros.Results;
using FbSoft_MediatrHandling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Interfaces
{
    public interface IGetPagedCarroQuery
    {
        Task<IEnumerable<GetCarroPagedResult>> Get(GetCarroPagedRequest request);
    }
}
