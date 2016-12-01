using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateRI.Entities
{
    class Message
    {
        public int messageId { get; set; }
        public Team team { get; set; }
        public string description { get; set; }
        public override string ToString()
        {
            return description;
        }

    }
}
