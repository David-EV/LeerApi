using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNationalize
{
    class VerDatos
    {
        public string name { get; set; }
        public List<county> country { get; set; }
    }
    public class county
    {
        public string country_id { get; set; }
        public string probability { get; set; }
    }
}
