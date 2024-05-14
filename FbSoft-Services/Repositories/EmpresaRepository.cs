using Dapper;
using DbExtensions;
using FbSoft_Services.Services;
using FbSoft_MediatrHandling.Entities;
using FbSoft_MediatrHandling.Interfaces;
using FbSoft_Services.Entities;
using Microsoft.IdentityModel.Tokens;

namespace FbSoft_Services.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private DbSession _session;

        public EmpresaRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<TB_Empresas> GetByID(string id)
        {
            var result = await _session.Connection.QueryFirstAsync<TB_Empresas>("SELECT * FROM TB_Empresas where ID = @ID", new { id = id }, _session.Transaction);
            return result;
        }

        public async Task<IEnumerable<TB_Empresas>> GetAll()
        {
            var result = await _session.Connection.QueryAsync<TB_Empresas>("SELECT * FROM TB_Empresas", null, _session.Transaction);
            return result;
        }

        public async Task<int> Add(TB_Empresas empresa)
        {
            return await _session.Connection.ExecuteAsync(@"insert into TB_Empresas (
                                                                                    Nome,
                                                                                    DT_Add,
                                                                                    DT_Alt,
                                                                                    CNPJ,
                                                                                    DT_Adesao,
                                                                                    RazaoSocial,
                                                                                    Estado,
                                                                                    Municipio,
                                                                                    Endereco,
                                                                                    Complemento,
                                                                                    Bairro,
                                                                                    CEP,
                                                                                    Telefone,
                                                                                    InscricaoEstadual,
                                                                                    InscricaoMunicipal,
                                                                                    Dominio) VALUES (@Nome, getdate(), getdate(), @CNPJ,
                                                                                    @DT_Adesao,
                                                                                    @RazaoSocial,
                                                                                    @Estado,
                                                                                    @Municipio,
                                                                                    @Endereco,
                                                                                    @Complemento,
                                                                                    @Bairro,
                                                                                    @CEP,
                                                                                    @Telefone,
                                                                                    @InscricaoEstadual,
                                                                                    @InscricaoMunicipal,
                                                                                    @Dominio)",
                new {
                    ID = empresa.ID,
                    Nome = empresa.Nome,
                    CNPJ = empresa.CNPJ,
                    DT_Adesao = empresa.DT_Adesao,
                    RazaoSocial = empresa.RazaoSocial,
                    Estado = empresa.Estado,
                    Municipio = empresa.Municipio,
                    Endereco = empresa.Endereco,
                    Complemento = empresa.Complemento,
                    Bairro = empresa.Bairro,
                    CEP = empresa.CEP,
                    Telefone = empresa.Telefone,
                    InscricaoEstadual = empresa.InscricaoEstadual,
                    InscricaoMunicipal = empresa.InscricaoMunicipal,
                    Dominio = empresa.Dominio
                }, _session.Transaction); ;
        }
        public async Task<bool> Edit(TB_Empresas empresa)
        {
            var query = new SqlBuilder().UPDATE("TB_Users")
                .SET("id = @id")
                ._If(!empresa.Nome.IsNullOrEmpty(), "Nome = @Nome")
                ._If(!empresa.CNPJ.IsNullOrEmpty(), "CNPJ = @CNPJ")
                ._If(!empresa.RazaoSocial.IsNullOrEmpty(), "RazaoSocial = @RazaoSocial")
                ._If(!empresa.Estado.IsNullOrEmpty(), "Estado = @Estado")
                ._If(!empresa.Municipio.IsNullOrEmpty(), "Municipio = @Municipio")
                ._If(!empresa.Endereco.IsNullOrEmpty(), "Endereco = @Endereco")
                ._If(!empresa.Complemento.IsNullOrEmpty(), "Complemento = @Complemento")
                ._If(!empresa.Bairro.IsNullOrEmpty(), "Bairro = @Bairro")
                ._If(!empresa.CEP.IsNullOrEmpty(), "CEP = @CEP")
                ._If(!empresa.Telefone.IsNullOrEmpty(), "Telefone = @Telefone")
                ._If(!empresa.InscricaoEstadual.IsNullOrEmpty(), "InscricaoEstadual = @InscricaoEstadual")
                ._If(!empresa.InscricaoMunicipal.IsNullOrEmpty(), "InscricaoMunicipal = @InscricaoMunicipal")
                ._If(!empresa.Dominio.IsNullOrEmpty(), "Dominio = @Dominio")
                .WHERE("id = @id").ToString();
            await _session.Connection.ExecuteAsync(query,
                 new
                 {
                     ID = empresa.ID,
                     Nome = empresa.Nome,
                     CNPJ = empresa.CNPJ,
                     DT_Adesao = empresa.DT_Adesao,
                     RazaoSocial = empresa.RazaoSocial,
                     Estado = empresa.Estado,
                     Municipio = empresa.Municipio,
                     Endereco = empresa.Endereco,
                     Complemento = empresa.Complemento,
                     Bairro = empresa.Bairro,
                     CEP = empresa.CEP,
                     Telefone = empresa.Telefone,
                     InscricaoEstadual = empresa.InscricaoEstadual,
                     InscricaoMunicipal = empresa.InscricaoMunicipal,
                     Dominio = empresa.Dominio
                 }, _session.Transaction);
            return true;
        }
        public async Task<bool> Delete(string ID)
        {
            await _session.Connection.ExecuteAsync("delete from TB_Empresas where id = @id", new { id = ID }, _session.Transaction);
            return true;
        }
    }
}
