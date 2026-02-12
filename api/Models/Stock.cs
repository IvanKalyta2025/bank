
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

        [Precision(18, 2)] //først variant of that type
        public decimal Purchase { get; set; }

        [Column(TypeName = "decimal(18,2)")] //second variant of that type
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; }

        public List<string> Comments { get; set; } = new List<string>();
    }
}