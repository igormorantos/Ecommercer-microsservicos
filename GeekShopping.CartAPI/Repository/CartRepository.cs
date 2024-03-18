using AutoMapper;
using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Model;
using GeekShopping.CartAPI.Model.Context;
using Microsoft.EntityFrameworkCore;


namespace GeekShopping.CartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly MySQLContext _cartRepository;
        private IMapper _mapper;

        public CartRepository(MySQLContext cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<bool> ApplyCoupon(string userId, string CouponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeader = await _cartRepository.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cartHeader != null) 
            {
                _cartRepository.CartDetails.RemoveRange(_cartRepository.CartDetails.Where(c => c.CartHeaderId == cartHeader.Id));
                _cartRepository.CartHeaders.Remove(cartHeader);
                await _cartRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CartVO> FindCartByUserId(string userId)
        {
            Cart cart = new()
            {
                CartHeader = await _cartRepository.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId)
            };

            cart.CartDetails = _cartRepository.CartDetails.Where(c => c.CartHeaderId == cart.CartHeader.Id)
                .Include(c => c.Product);

            return _mapper.Map<CartVO>(cart);
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(long cartDetailsId)
        {
            try
            {
                CartDetail carDetail = await _cartRepository.CartDetails.FirstOrDefaultAsync(c => c.Id == cartDetailsId);
                
                int total = _cartRepository.CartDetails.Where(c => c.CartHeaderId == carDetail.CartHeaderId).Count();

                _cartRepository.CartDetails.Remove(carDetail);
                if (total == 1)
                {
                    var cartHeaderToRemove = await _cartRepository.CartHeaders.FirstOrDefaultAsync(c => c.Id == carDetail.CartHeaderId);
                    _cartRepository.CartHeaders.Remove(cartHeaderToRemove);
                }
                await _cartRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<CartVO> SaveOrUpdateCart(CartVO vo)
        {
            Cart cart = _mapper.Map<Cart>(vo);
            var product = await _cartRepository.Products.FirstOrDefaultAsync(p => p.Id == vo.CartDetails.FirstOrDefault().ProductId);

            if (product == null)
            {
                _cartRepository.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                await _cartRepository.SaveChangesAsync();
            }

            var cartHeader = await _cartRepository.CartHeaders.AsNoTracking().FirstOrDefaultAsync(
                c => c.UserId == cart.CartHeader.UserId);

            if (cartHeader == null)
            {
                _cartRepository.CartHeaders.Add(cart.CartHeader);
                await _cartRepository.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
                cart.CartDetails.FirstOrDefault().Product = null;
                _cartRepository.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                await _cartRepository.SaveChangesAsync();
            }
            else
            {
                var cartDetail = await _cartRepository.CartDetails.AsNoTracking().FirstOrDefaultAsync(
                    p => p.ProductId == cart.CartDetails.FirstOrDefault().ProductId &&
                    p.CartHeaderId == cartHeader.Id);
                
                if (cartDetail == null)
                {
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeader.Id;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    _cartRepository.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                    await _cartRepository.SaveChangesAsync();
                }
                else
                {
                    cart.CartDetails.FirstOrDefault().Product = null;
                    cart.CartDetails.FirstOrDefault().Count += cartDetail.Count;
                    cart.CartDetails.FirstOrDefault().Id = cartDetail.Id;
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;
                    _cartRepository.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                    _cartRepository.SaveChangesAsync();
                }
            }
            return _mapper.Map<CartVO>(cart);
        }
    }
}
