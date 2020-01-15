using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDotNetCoreAPI.Service
{
    public class User
    {
        public int Id { get; set; }
        public string Identity { get; set; }
        public string Token { get; set; }
    }

    public class UserRepository : IUserRepository
    {
        public List<User> users = new List<User>()
        {
            new User() { Id = 1, Identity = "farukaydogan", Token = "aydoganf" },
            new User() { Id = 2, Identity = "abdullagaydogan", Token = "aydoganab" },
            new User() { Id = 3, Identity = "durduaydogan", Token = "aydogandu" },
        };

        User IUserRepository.SingleByToken(string token)
        {
            return users.FirstOrDefault(u => u.Token == token);
        }
    }

    public interface IUserRepository
    {
        User SingleByToken(string token);
    }
}
