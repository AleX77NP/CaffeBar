using CaffeBar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        CaffeContext context;

        public AuthRepository(CaffeContext context)
        {
            this.context = context;
        }
        public bool CombinationExists(CaffeAuth auth)
        {
            var count = context.Auth.Where(x => x.Username == auth.Username && x.Password == auth.Password).Count();
            return count == 1 ? true : false;
        }
    }
}
