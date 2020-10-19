using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.CookieAuthentication.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string DateOfBirth { get; set; }

        public IEnumerable<Users> UserList()
        {
            return new List<Users>()
            {
                new Users { Id=100001,Username="rezaice07", Email="rezaice07@gmail.com", Name="Rejwanul Reja", Password="rezaice07_123",Role="Consumer",DateOfBirth="01-Jun-1990"}
            };
        }
    }
}
