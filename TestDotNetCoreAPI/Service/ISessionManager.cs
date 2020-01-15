using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDotNetCoreAPI.Service
{
    public interface ISessionManager
    {
        bool IsAuthenticated(string token);
    }

    public class SessionManager : ISessionManager
    {
        private readonly IUserRepository userRepository;

        public SessionManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        bool ISessionManager.IsAuthenticated(string token)
        {
            return userRepository.SingleByToken(token) != null;
        }
    }
}
