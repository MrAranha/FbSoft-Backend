using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Carros.Results
{
    public class GetCarroByIDResult
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Ano { get; set; }
        public string Marca { get; set; }
    }
}
