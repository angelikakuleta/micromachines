using MicroMachines.Services.Catalog.Dtos;
using MicroMachines.Services.Catalog.Mappers;
using MicroMachines.Services.Catalog.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroMachines.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CategoriesController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            var categories = (await _categoryRepository.GetAll()).Select(x => x.ToDto());
            return Ok(categories);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<CategoryDto>> Get(Guid id)
        {
            var category = (await _categoryRepository.GetSingle(x => x.Id == id)).ToDto();
            return Ok(category);
        }

        [HttpGet("{id:Guid}/products")]
        public async Task<ActionResult<ProductDto>> GetProducts(Guid id)
        {
            var products = (await _productRepository.GetByCategory(id)).Select(x => x.ToDto());
            return Ok(products);
        }
    }
}
