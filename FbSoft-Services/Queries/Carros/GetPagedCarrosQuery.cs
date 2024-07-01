using Dapper;
using DbExtensions;
using DevExpress.Mvvm.Native;
using FbSoft_Services.Services;
using FbSoft_MediatrHandling.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Net.Http.Headers;
using FbSoft_MediatrHandling.EntityRequests.Carros.Interfaces;
using FbSoft_MediatrHandling.EntityRequests.Carros.Results;
using FbSoft_MediatrHandling.EntityRequests.Carros.Requests;

namespace FbSoft_Services.Queries.Carros
{
    public class GetPagedCarroQuery : IGetPagedCarroQuery
    {
        private DbSession _session;
        public GetPagedCarroQuery(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<GetCarroPagedResult>> Get(GetCarroPagedRequest request)
        {
            if (!request.Nome.IsNullOrEmpty())
            {
                request.Nome = "%" + request.Nome + "%";
            }
            if (!request.Marca.IsNullOrEmpty())
            {
                request.Marca = "%" + request.Marca + "%";
            }
            var query = new SqlBuilder().SELECT("*").FROM("TB_Carros")
                .WHERE()
                ._If(!request.Nome.IsNullOrEmpty(), "Nome LIKE @Nome")
                ._If(!request.Marca.IsNullOrEmpty(), "Marca LIKE @Marca")
                ._If(request.ID != 0 && request.ID != null, "id = @id")
                ._If(!request.Ano.IsNullOrEmpty(), "Ano = @Ano");

            return await _session.Connection.QueryAsync<GetCarroPagedResult>(query.ToString(),
                new { Nome = request.Nome, Email = request.Marca, Ano = request.Ano, id = request.ID },
                _session.Transaction);
        }

    }
}