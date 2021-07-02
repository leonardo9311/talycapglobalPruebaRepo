using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Infraestructure.Exceptions;

namespace talycapglobalPrueba.Infraestructure.Services
{
    public  class HttpServiceHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpServiceHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> CosumeServiceGet<T>(string url)
        {

            try
            {
                var client = _httpClientFactory.CreateClient("ThirdApi");
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();                   
                    return JsonConvert.DeserializeObject<T>(apiResponse);

                }
                else
                {
                    throw new ThirdApiExceptions(response.StatusCode, "Error response from ThirdApi: " + response.ReasonPhrase);
                }
            }
            catch (Exception e)
            {

                throw new ThirdApiExceptions(System.Net.HttpStatusCode.OK, "Error response from ThirdApi: " + e.Message);
            }
        }
    }
}
