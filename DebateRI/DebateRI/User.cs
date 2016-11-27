using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateRI
{
    public class User
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
        public byte[] salt { get; set; }
        public DateTime joinDate { get; set; }
        public Role role { get; set; }

    }
}
