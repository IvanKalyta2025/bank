
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace api.Models
{
    public class Comment
    {
        public int? StockId { get; set; }

        public Stock? Stock { get; set; }

    }
}