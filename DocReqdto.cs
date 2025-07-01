using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class DocReqdto
    {
        public string flag { get; set; }
        public int Doc_id { get; set; }

        public int Proj_id{ get; set; }

        public string Document { get; set; }
    }
}
