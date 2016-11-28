using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateRI.Entities
{
    class Session
    {

        public Debate debate { get; set; }
        public int IdSession { get; set; }

        public string SessionName { get; set; }

        public int Time { get; set; }

        public string Description { get; set; }

        public Session(int idSession, string sessionName, int time, string description)
        {
            IdSession = idSession;
            SessionName = sessionName;
            Time = time;
            Description = description;
        }
        public override string ToString()
        {
            return SessionName;
        }

    }
}
