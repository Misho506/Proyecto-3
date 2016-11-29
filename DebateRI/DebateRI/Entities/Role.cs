using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateRI.Entities
{
    public class Role
    {
        public int roleId { get; set; }
        public string name { get; set; }
        public bool isAdmin { get; set; }
    }
}
