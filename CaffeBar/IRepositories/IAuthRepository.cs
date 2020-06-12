using CaffeBar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
    public interface IAuthRepository
    {
        bool CombinationExists(CaffeAuth auth);
    }
}
