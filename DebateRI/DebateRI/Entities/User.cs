using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateRI.Entities
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

        public User(int _userId, string _name, string _lastName, string _email, string _passwordHash, DateTime _joinDate)
        {
            userId = _userId;
            name = _name;
            lastName = _lastName;
            email = _email;
            passwordHash = _passwordHash;
            joinDate = _joinDate ;               
        }

        public User()
        {
        }
        public override string ToString()
        {
            return name;
        }
    }
}
