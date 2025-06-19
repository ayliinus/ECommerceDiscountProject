using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDiscount.Domain.Models
{
    public class ProductRequest
    {
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Quantity { get; set; }
        public string? CustomerType { get; set; }
    }
}
