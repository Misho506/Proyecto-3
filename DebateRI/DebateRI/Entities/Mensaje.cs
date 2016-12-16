using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateRI.Entities
{
   public class Mensaje
    {
        public string description { get; set; }
        public int messageId{ get; set; }
        public string sender{ get; set; }
    
    public Mensaje(String _description, int _messageId, string _sender)
    {
            description = _description;
            messageId = _messageId;
            sender = _sender;
    }

    public Mensaje()
    {
    }
    public override string ToString()
    {
        return description;
    }
}
}