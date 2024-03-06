using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFolio.Services
{
    public interface IHashService
    {
        String HashPassword(String text);
        bool VerifyPassword(String text, String hash);
    }
}
