using ECommerceDiscount.Application.Interfaces;
using ECommerceDiscount.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDiscountProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public ProductController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("CalculateDiscount")]
        public IActionResult CalculateDiscount([FromBody] ProductRequest request)
        {
            if (request.OriginalPrice <= 0)
                return BadRequest("Fiyat 0'dan büyük olmalıdır.");

            if (request.Quantity < 1 || request.Quantity > 100)
                return BadRequest("Adet 1-100 arasında olmalıdır.");

            var response = _discountService.CalculateDiscount(request);
            return Ok(response);
        }
    }
}
