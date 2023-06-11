using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using TestTask.Web.Exceptions;
using TestTask.Web.Helpers;
using TestTask.Web.Models;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace TestTask.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient client;
        private readonly HttpClientUriOptions uriOptions;

        public OrderService(HttpClient client, IOptions<HttpClientUriOptions> options)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.uriOptions = options.Value;
        }

        public async Task<OrderModel> GetSingleOrder()
        {
            var response = await client.GetAsync(uriOptions.OrderGetUri);
            ResolveResponseErrors(response);

            return await response.ReadContentAsync<OrderModel>();
        }

        public async Task<OrderModel> UpdateSingleOrder(OrderModel order)
        {
            var content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, Application.Json);

            var response = await client.PutAsync(uriOptions.OrderUpdateSingleUri, content);
            ResolveResponseErrors(response);

            return await response.ReadContentAsync<OrderModel>();
        }

        private void ResolveResponseErrors(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException();
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new BadRequestException();
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new InternalServerErrorException();
            }
        }
    }
}
