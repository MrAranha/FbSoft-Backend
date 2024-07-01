using FbSoft_Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.Entities
{
    [Table("TB_Pedidos")]
    public class TB_Pedidos
    {
        [Key]
        public int Id { get; set; }
        public string ID_Usuario { get; set; }
        public int ID_Carro { get; set; }
    }
}