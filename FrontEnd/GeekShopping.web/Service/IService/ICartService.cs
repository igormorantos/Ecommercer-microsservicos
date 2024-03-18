﻿using GeekShopping.web.Models;

namespace GeekShopping.web.Service.IService
{
    public interface ICartService
    {
        Task<CartViewModel> FindCartByUserId(string userId, string token );
        Task<CartViewModel> AddItemToCart(CartViewModel cart, string token );
        Task<CartViewModel> UpdateItemToCart(CartViewModel cart, string token );
        Task<bool> RemoveFromCart(long cartId, string token );

        Task<bool> ApplyCoupon(CartViewModel cart, string couponCode, string token );
        Task<bool> RemoveCoupon(string userId, string token );
        Task<bool> ClearCart(string userId, string token );

        Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token);
    }
}