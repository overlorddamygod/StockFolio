using StockFolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFolio.Services
{
    public interface IUserService
    {
        User? GetUserWithEmail(string email);
        User? AddUser(User user);
    }
}
