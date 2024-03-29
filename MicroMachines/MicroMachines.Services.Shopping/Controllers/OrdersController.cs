﻿using System;
using System.Collections.Generic;
using System.Linq;
using MicroMachines.Services.Shopping.Mappers;
using MicroMachines.Services.Shopping.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using MicroMachines.Services.Shopping.Dtos;
using System.Threading.Tasks;
using MicroMachines.Services.Shopping.Data.Models;
using MicroMachines.Services.Shopping.Clients;
using MicroMachines.Common.Contracts;

namespace MicroMachines.Services.Identity.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase 
    {
        private readonly IOrderRepository _orderRepository;
        private readonly CatalogClient _catalogClient;

        public OrdersController(IOrderRepository orderRepository, CatalogClient catalogClient) {
            _orderRepository = orderRepository;
            _catalogClient = catalogClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> Get()
        {
            var orders = await _orderRepository.GetAll();
            return Ok(orders.Select(x => x.ToDto()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<OrderDto>> Get(Guid id)
        {
            var order = await _orderRepository.GetSingle(x => x.Id == id);
            if (order == null) return NotFound();
                
            return Ok(order.ToDto());
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> Create([FromBody] CreateOrderDto createOrderDto)
        {           
            var orderItemDtos = await _catalogClient.GetOrderItems(createOrderDto.Itenarary);
            var order = createOrderDto.ToOrder(orderItemDtos);

            if (!await _catalogClient.ChangeStockSupplies(createOrderDto.Itenarary))
            {
                order.Status = OrderStatus.Denied;
            }

            await _orderRepository.Add(order);
            return CreatedAtAction(nameof(Get), order.Id, order.ToDto());
        }

        [HttpPost("{id:Guid}/pay")]
        public async Task<ActionResult<OrderDto>> Pay(Guid id, [FromBody] CreateTransactionDto createTransactionDto)
        {
            var order = await _orderRepository.GetSingle(x => x.Id == id);
            if (order == null) return NotFound();

            if (order.Status != OrderStatus.Pending) return BadRequest("The order is incomplete or has already been paid for.");

            var transaction = await MakeTransfer(createTransactionDto);
            if (transaction == null) BadRequest("This transaction cannot be completed");

            order.Transaction = transaction;
            order.Status = OrderStatus.Confirmed;
            await _orderRepository.Edit(order);
            return CreatedAtAction(nameof(Get), order.Id, order.ToDto());
        }

        private Task<Transaction> MakeTransfer(CreateTransactionDto createTransactionDto)
        {
            return Task.FromResult<Transaction>(null);
        }
    }
}
