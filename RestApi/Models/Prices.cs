using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class Prices
    {
        public long Id { get; set; }
        public long PricelistId { get; set; }
        public long ProductId { get; set; }
        public long Amount { get; set; }
    }
}
