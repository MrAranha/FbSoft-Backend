using Dapper;
using DbExtensions;
using DevExpress.Mvvm.Native;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Interfaces;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Requests;
using FbSoft_MediatrHandling.EntityRequests.Empresas.Results;
using FbSoft_MediatrHandling.Interfaces;
using FbSoft_Services.Services;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Net.Http.Headers;

namespace FbSoft_Services.Queries.Empresas
{
    public class GetPagedEmpresasQuery : IGetPagedEmpresasQuery
    {
        private DbSession _session;
        public GetPagedEmpresasQuery(DbSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<GetEmpresasPagedResult>> Get(GetEmpresasPagedRequest request)
        {
            if (!request.Nome.IsNullOrEmpty())
            {
                request.Nome = "%" + request.Nome + "%";
            }
            if (!request.Email.IsNullOrEmpty())
            {
                request.Email = "%" + request.Email + "%";
            }
            var query = new SqlBuilder().SELECT("*").FROM("TB_Users")
                .WHERE()
                ._If(!request.Nome.IsNullOrEmpty(), "displayName LIKE @Nome")
                ._If(!request.Email.IsNullOrEmpty(), "email LIKE @Email")
                ._If(!request.id.IsNullOrEmpty(), "id = @id")
                ._If(!request.Empresa.IsNullOrEmpty(), "Empresa = @Empresa");

            return await _session.Connection.QueryAsync<GetEmpresasPagedResult>(query.ToString(),
                new { Nome = request.Nome, Email = request.Email, Empresa = request.Empresa, id = request.id },
                _session.Transaction);
        }
    }
}
