using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using talycapglobalPrueba.Core.Entities;
using talycapglobalPrueba.Core.Interfaces.Repository;
using talycapglobalPrueba.Infraestructure.Services;

namespace talycapglobalPrueba.Infraestructure.Repository
{
    public class ThirdApiRepository : IThirdApiRepository
    {
        private readonly HttpServiceHelper _httpServiceHelper;
        public ThirdApiRepository(IHttpClientFactory httpClientFactory)
        {
            _httpServiceHelper = new HttpServiceHelper(httpClientFactory);
         }
        public async Task<List<Author>> GetAuthors()
        {
            string url = BuildCoinLoreUrl("/api/v1", "/Authors");
            return await _httpServiceHelper.CosumeServiceGet<List<Author>>(url); 
        }

        public async Task<List<Book>> GetBooks()
        {
            string url = BuildCoinLoreUrl("/api/v1", "/Books");
            return await _httpServiceHelper.CosumeServiceGet<List<Book>>(url);
        }
        public string BuildCoinLoreUrl(string EntPoint, string Params = "")
        {
            return string.Concat("https://fakerestapi.azurewebsites.net/", EntPoint, "/", Params);

        }
    }
}
