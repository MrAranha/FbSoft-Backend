using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.Entities
{
    [Table("TB_Empresas")]
    public class TB_Empresas
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DT_Add { get; set; }
        public DateTime DT_Alt { get; set; }
        public string CNPJ { get; set; }
        public DateTime? DT_Adesao { get; set; }
        public string RazaoSocial { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string Dominio { get; set; }
    }
}
