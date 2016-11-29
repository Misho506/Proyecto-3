using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateRI.Entities
{
    class TimeKeeping
    {
        public int timeKeepingId { get; set; }
        public User user { get; set; }
        public DateTime initialTiem { get; set; }
        public DateTime endTime { get; set; }
    }
}
