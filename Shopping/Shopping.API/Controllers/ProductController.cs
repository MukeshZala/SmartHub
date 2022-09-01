using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Shoppnig.API.Data;
using Shoppnig.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductContext _context; 

        public ProductController(ILogger<ProductController> logger, ProductContext context)
        {
            _logger = logger;
            _context = context; 
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.ProductCollection.Find(o => true).ToListAsync(); 


        }
    }
}
