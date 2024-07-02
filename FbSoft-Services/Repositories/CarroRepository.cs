using Dapper;
using DbExtensions;
using FbSoft_MediatrHandling.Entities;
using FbSoft_MediatrHandling.Interfaces;
using FbSoft_Services.Entities;
using FbSoft_Services.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_Services.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private DbSession _session;

        public CarroRepository(DbSession session)
        {
            _session = session;
        }
        public async Task<TB_Carros> GetByID(int id)
        {
            var result = await _session.Connection.QueryFirstAsync<TB_Carros>("SELECT * FROM TB_Carros where id = @id", new { id = id }, _session.Transaction);
            return result;
        }

        public async Task<bool> DeletePedido (int idpedido)
        {
            await _session.Connection.ExecuteAsync("delete from TB_Pedidos where Id = @Id", new { Id = idpedido}, _session.Transaction );
            return true;
        }

        public async Task<IEnumerable<TB_Carros>> GetAll()
        {
            var result = await _session.Connection.QueryAsync<TB_Carros>("SELECT * FROM TB_Carros", null, _session.Transaction);
            return result;
        }
        public async Task<int> FazerPedido(TB_Pedidos pedido)
        {
            return await _session.Connection.ExecuteAsync("INSERT INTO TB_Pedidos (ID_Usuario, ID_Carro) VALUES(@ID_Usuario, @ID_Carro)", 
                new { ID_Carro = pedido.ID_Carro, ID_Usuario = pedido.ID_Usuario }, _session.Transaction);
        }

        public async Task<int> Add(TB_Carros users)
        {
            return await _session.Connection.ExecuteAsync("INSERT INTO TB_Carros (Ano, Nome, Marca, Quantidade) VALUES(@Ano, @Nome, @Marca, @Quantidade)",
                new { Ano = users.Ano, Nome = users.Nome, Marca = users.Marca, Quantidade = users.Quantidade }, _session.Transaction); ;
        }
        public async Task<bool> Edit(TB_Carros users)
        {
            var query = new SqlBuilder().UPDATE("TB_Carros")
                .SET("id = @id")
                ._If(!users.Nome.IsNullOrEmpty(), "Nome = @Nome")
                ._If(!users.Ano.IsNullOrEmpty(), "Ano = @Ano")
                ._If(!users.Marca.IsNullOrEmpty(), "Marca = @Marca")
                ._If(users.Quantidade >= 0, "Quantidade = @Quantidade")
                .WHERE("id = @id").ToString();
            await _session.Connection.ExecuteAsync(query,
                new
                {
                    Nome = users.Nome,
                    Ano = users.Ano,
                    Quantidade = users.Quantidade,
                    Marca = users.Marca,
                    id = users.Id,
                }, _session.Transaction);
            return true;
        }
        public async Task<IEnumerable<TB_Pedidos>> GetPedidos(int idCarro)
        {
            return await _session.Connection.QueryAsync<TB_Pedidos>("SELECT * FROM TB_Pedidos where ID_Carro = @ID_Carro", new { ID_Carro = idCarro }, _session.Transaction);
        }
        public async Task<bool> Delete(int ID)
        {
            await _session.Connection.ExecuteAsync("delete from TB_Carros where id = @id", new { id = ID }, _session.Transaction);
            return true;
        }
    }
}
