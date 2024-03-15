using GeekShopping.web.Models;
using GeekShopping.web.Service.IService;
using GeekShopping.web.Utils;
using System.Net.Http.Headers;
using System.Reflection;
using static System.Net.WebRequestMethods;

namespace GeekShopping.web.Service
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath =$"api/v1/product";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProductModel>();
            else throw new Exception($"Deu ruim no post na hora de criar {response.ReasonPhrase}");
            
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProductModel>();
            else throw new Exception($"Deu ruim no put na hora de criar {response.ReasonPhrase}");
        }

        public async Task<bool> DeleteProductById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();
            else throw new Exception($"Deu ruim no Delete na hora de criar {response.ReasonPhrase}");
        }
    }
}
