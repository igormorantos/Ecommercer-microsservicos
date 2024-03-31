using AutoMapper;
using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Model.Context;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeekShopping.CartAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {
        public readonly HttpClient _client;

        public CouponRepository(HttpClient client)
        {
            _client = client;
        }

        async Task<CouponVO> ICouponRepository.GetCoupon(string couponCode, string token)
        {
            //"api/v1/coupon"
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"/api/v1/coupon/{couponCode}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != System.Net.HttpStatusCode.OK) new CouponVO();
            return JsonSerializer.Deserialize<CouponVO>(content,
               new JsonSerializerOptions
               { PropertyNameCaseInsensitive = true });

        }
    }
}
