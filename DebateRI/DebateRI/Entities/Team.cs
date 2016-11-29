using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateRI.Entities
{
    class Team
    {
        public int teamId { get; set; }
        public string name { get; set; }
        public Debate debate { get; set; }
        public List<User> users { get; set; }

    }
}
