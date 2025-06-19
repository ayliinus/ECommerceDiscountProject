using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDiscount.Domain.Models;

namespace ECommerceDiscount.Application.Interfaces
{
    public interface IDiscountService
    {
        ProductResponse CalculateDiscount(ProductRequest request);
    }
}
