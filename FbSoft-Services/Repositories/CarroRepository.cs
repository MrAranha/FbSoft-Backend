using Dapper;
using DbExtensions;
using FbSoft_MediatrHandling.Entities;
using FbSoft_MediatrHandling.Interfaces;
using FbSoft_Services.Entities;
using FbSoft_Services.Services;
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

        public async Task<IEnumerable<TB_Carros>> GetAll()
        {
            var result = await _session.Connection.QueryAsync<TB_Carros>("SELECT * FROM TB_Carros", null, _session.Transaction);
            return result;
        }

        public async Task<int> Add(TB_Carros users)
        {
            /*await _session.Connection.ExecuteAsync("INSERT INTO TB_Users (ID, password, email, displayName, role) VALUES(@id, @password, @email, @nome, @role)",
                new { id = users.id, Nome = users.displayName, Email = users.email, Password = users.password, role = users.role }, _session.Transaction);
            return users.id;*/
            return 0;
        }
        public async Task<bool> Edit(TB_Carros users)
        {
            /*
            var query = new SqlBuilder().UPDATE("TB_Carros")
                .SET("id = @id")
                ._If(!users.displayName.IsNullOrEmpty(), "displayName = @displayName")
                ._If(!users.password.IsNullOrEmpty(), "password = @password")
                ._If(!users.email.IsNullOrEmpty(), "email = @email")
                ._If(!users.country.IsNullOrEmpty(), "country = @country")
                ._If(!users.city.IsNullOrEmpty(), "city = @city")
                ._If(!users.address.IsNullOrEmpty(), "address = @address")
                ._If(!users.state.IsNullOrEmpty(), "state = @state")
                ._If(!users.about.IsNullOrEmpty(), "about = @about")
                ._If(!users.zipCode.IsNullOrEmpty(), "zipCode = @zipCode")
                ._If(!users.role.IsNullOrEmpty(), "role = @role")
                .WHERE("id = @id").ToString();
            await _session.Connection.ExecuteAsync(query,
                new
                {
                    displayName = users.displayName,
                    email = users.email,
                    country = users.country,
                    city = users.city,
                    address = users.address,
                    state = users.state,
                    about = users.about,
                    zipCode = users.zipCode,
                    role = users.role,
                    id = users.id,
                    password = users.password
                }, _session.Transaction);*/
            return true;
        }
        public async Task<bool> Delete(int ID)
        {
            await _session.Connection.ExecuteAsync("delete from TB_Carros where id = @id", new { id = ID }, _session.Transaction);
            return true;
        }
    }
}
