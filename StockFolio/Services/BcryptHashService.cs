using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFolio.Services
{
    public class BCryptHashService : IHashService
    {
        public string HashPassword(string text)
        {
            return BCrypt.Net.BCrypt.HashPassword(text);
        }

        public bool VerifyPassword(string text, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(text, hash);
        }
    }
}
