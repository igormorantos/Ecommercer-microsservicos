using GeekShopping.web.Models;
using GeekShopping.web.Service.IService;
using GeekShopping.web.Utils;
using System.Net;
using System.Net.Http.Headers;

namespace GeekShopping.web.Service
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = $"api/v1/cart";

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient)); ;
        }

        public async Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"{BasePath}/find-cart/{userId}");
            return await response.ReadContentAs<CartViewModel>();
        }

        public async Task<CartViewModel> AddItemToCart(CartViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJson($"{BasePath}/add-cart", model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<CartViewModel>();
            else
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        throw new Exception("Acesso não autorizado!");
                    case HttpStatusCode.BadRequest:
                        var errors = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Erro na requisição: {errors}");
                    case (HttpStatusCode)422: // Unprocessable Entity
                        var errors2 = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Dados inválidos: {errors2}");
                    default:
                        throw new Exception($"Erro desconhecido: {response.ReasonPhrase}");
                }
            }
        }

        public async Task<CartViewModel> UpdateItemToCart(CartViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJson($"{BasePath}/update-cart", model);
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<CartViewModel>();
            else throw new Exception($"Deu ruim no post na hora de criar {response.ReasonPhrase}");
        }

        public async Task<bool> RemoveFromCart(long cartId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.DeleteAsync($"{BasePath}/remove-cart/{cartId}");
            if (response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();
            else throw new Exception($"Deu ruim no Delete na hora de criar {response.ReasonPhrase}");
        }

        public async Task<bool> ApplyCoupon(CartViewModel cart, string couponCode, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId, string token)
        {
            throw new NotImplementedException();
        }



        public async Task<bool> RemoveCoupon(string userId, string token)
        {
            throw new NotImplementedException();
        }


    }
}
