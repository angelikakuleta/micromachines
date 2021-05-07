using MicroMachines.Services.Catalog.Data.Repositories;
using MicroMachines.Services.Catalog.Dtos;
using MicroMachines.Services.Catalog.Mappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroMachines.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            var products = (await _productRepository.GetAll()).Select(x => x.ToDto());
            return Ok(products);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ProductDto>> Get(Guid id)
        {
            var product = (await _productRepository.GetSingle(x => x.Id == id)).ToDto();
            return Ok(product);
        }
    }
}
