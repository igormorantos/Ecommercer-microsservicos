﻿using GeekShopping.web.Models;
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

        public async Task<IEnumerable<ProductViewModel>> FindAllProducts(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductViewModel>>();
        }

        public async Task<ProductViewModel> FindProductById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductViewModel>();
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProductViewModel>();
            else throw new Exception($"Deu ruim no post na hora de criar {response.ReasonPhrase}");
            
        }

        public async Task<ProductViewModel> UpdateProduct(ProductViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync(BasePath, model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProductViewModel>();
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
