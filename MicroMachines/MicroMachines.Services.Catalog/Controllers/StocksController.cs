using MicroMachines.Services.Catalog.Dtos;
using MicroMachines.Services.Catalog.Mappers;
using MicroMachines.Services.Catalog.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroMachines.Common.Contracts;

namespace MicroMachines.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StocksController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockDto>>> Get()
        {
            var stocks = (await _stockRepository.GetAll()).Select(x => x.ToDto());
            return Ok(stocks);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<StockDto>> Get(Guid id)
        {
            var stock = (await _stockRepository.GetSingle(x => x.Id == id)).ToDto();
            return Ok(stock);
        }

        [HttpPut("purchase")]
        public async Task<ActionResult> Purchase(IEnumerable<CreateOrderItemDto> itenarary)
        {
            if (!await _stockRepository.TakeAll(itenarary))
            {
                return BadRequest("Not all items can be taken");
            }

            return Ok();
        }

        
        [HttpGet("~/api/balances/{productId:Guid}")]
        public async Task<ActionResult<StockItemBalanceDto>> GetBalances(Guid productId)
        {
            var product = await _stockRepository.GetBalance(productId);
            if (product == null) return NotFound();

            return Ok(product.ToDto());
        }

        [HttpPut("~/api/balances/{productId:Guid}/add")]
        public async Task<ActionResult<StockItemBalanceDto>> AddBalance(Guid productId, [FromQuery] int quantity)
        {
            var product = await _stockRepository.GetBalance(productId);
            if (product == null) return NotFound();

            var itemBalance = (await _stockRepository.ChangeBalance(productId, quantity));
            return Ok(itemBalance.ToDto());
        }

        [HttpPut("~/api/balances/{productId:Guid}/sub")]
        public async Task<ActionResult<StockItemBalanceDto>> SubBalance(Guid productId, [FromQuery] int quantity)
        {
            var product = await _stockRepository.GetBalance(productId);
            if (product == null) return NotFound();

            var itemBalance = (await _stockRepository.ChangeBalance(productId, -quantity));
            return Ok(itemBalance.ToDto());
        }
    }
}
