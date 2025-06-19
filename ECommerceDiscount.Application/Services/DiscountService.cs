using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDiscount.Application.Interfaces;
using ECommerceDiscount.Domain.Models;

namespace ECommerceDiscount.Application.Services
{
    public class DiscountService : IDiscountService
    {
        public ProductResponse CalculateDiscount(ProductRequest request)
        {
            if (request.ProductName == "EXCEPTION")
                throw new Exception("Test hatası");

            decimal categoryDiscountRate = request.Category switch
            {
                "Elektronik" => 0.15m,
                "Giyim" => 0.20m,
                "Ev & Yaşam" => 0.10m,
                _ => 0
            };

            decimal customerDiscountRate = request.CustomerType == "VIP" ? 0.05m : 0;
            decimal quantityDiscountRate = request.Quantity >= 5 ? 0.10m : 0;

            decimal categoryDiscount = request.OriginalPrice * categoryDiscountRate;
            decimal customerDiscount = request.OriginalPrice * customerDiscountRate;
            decimal quantityDiscount = request.OriginalPrice * quantityDiscountRate;

            decimal totalDiscount = categoryDiscount + customerDiscount + quantityDiscount;
            decimal finalPrice = request.OriginalPrice - totalDiscount;

            return new ProductResponse
            {
                ProductName = request.ProductName,
                OriginalPrice = request.OriginalPrice,
                CategoryDiscount = categoryDiscount,
                CustomerDiscount = customerDiscount,
                QuantityDiscount = quantityDiscount,
                TotalDiscount = totalDiscount,
                FinalPrice = finalPrice
            };
        }
    }
}
