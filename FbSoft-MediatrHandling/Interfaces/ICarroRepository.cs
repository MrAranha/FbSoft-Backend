using FbSoft_MediatrHandling.Entities;
using FbSoft_Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.Interfaces
{
    public interface ICarroRepository
    {
        public Task<IEnumerable<TB_Carros>> GetAll();
        public Task<int> Add(TB_Carros add);
        public Task<TB_Carros> GetByID(int id);
        public Task<bool> Delete(int id);
        public Task<bool> Edit(TB_Carros edit); 
        Task<int> FazerPedido(TB_Pedidos pedido);
        Task<IEnumerable<TB_Pedidos>> GetPedidos(int idCarro);
        Task<bool> DeletePedido(int idPedido);
    }
}
