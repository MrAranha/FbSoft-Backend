using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.Entities
{
    [Table("TB_Carros")]
    public class TB_Carros
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Ano { get; set; }
        public string? Marca { get; set; }
        public int Quantidade { get; set; }
    }
}
