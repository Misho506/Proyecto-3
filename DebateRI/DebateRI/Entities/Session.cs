using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateRI.Entities
{
    class Session
    {


        public int IdSession { get; private set; }

        public string SessionName { get; private set; }

        public int Time { get; private set; }

        public string Description { get; private set; }

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
