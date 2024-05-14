using FbSoft_MediatrHandling.Entities;
using FbSoft_Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.Interfaces
{
    public interface IEmpresaRepository
    {
        public Task<IEnumerable<TB_Empresas>> GetAll();
        public Task<int> Add(TB_Empresas add);
        public Task<TB_Empresas> GetByID(string id);
        public Task<bool> Delete(string id);
        public Task<bool> Edit(TB_Empresas edit);
    }
}
