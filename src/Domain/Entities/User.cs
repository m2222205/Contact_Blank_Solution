using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

    }
}
