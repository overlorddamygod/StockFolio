using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFolio.Model
{
    public class Stock
    {
        public int Id { get; set; }
        public required string CompanyName { get; set; }
        public required string Symbol { get; set; }
        public Int64 Ltp {  get; set; }
        public Int64 SectorId { get; set; }
        public Sector Sector { get; set; }
    }
}
