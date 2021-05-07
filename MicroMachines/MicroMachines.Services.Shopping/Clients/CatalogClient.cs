using MicroMachines.Common.Contracts;
using MicroMachines.Common.CustomExceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroMachines.Services.Shopping.Clients
{
    public class CatalogClient
    {
        private readonly HttpClient _httpClient;

        public CatalogClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<OrderItemDto>> GetOrderItems(IEnumerable<CreateOrderItemDto> itenarary)
        {
            var json = JsonConvert.SerializeObject(itenarary);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("api/orderItems", data);
            var content = await result.Content.ReadAsStringAsync();

            if (result.StatusCode == HttpStatusCode.BadRequest) throw new BadRequestException(content);
            if (result.StatusCode != HttpStatusCode.OK) throw new Exception();
                        
            return JsonConvert.DeserializeObject<IReadOnlyCollection<OrderItemDto>>(content);
        }
    }
}
