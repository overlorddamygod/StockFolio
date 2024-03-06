using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFolio.Model
{
    public class UserStock
    {
        public Int64 Id { get; set; }
        public int UserId { get; set; }
        public int StockId { get; set; }
        public Int64 Quantity { get; set; }
        public Int64 Investment { get; set; }
    }
}
