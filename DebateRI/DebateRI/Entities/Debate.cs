using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateRI.Entities
{
    class Debate
    {
        public int debateId { get; set; }
        public string name { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime initialTime { get; set; }
        public DateTime endTime { get; set; }

    }
}
