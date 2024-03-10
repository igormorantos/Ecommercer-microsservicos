using GeekShopping.web.Models;

namespace GeekShopping.web.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts();

        Task<ProductModel> FindProductById(long id);

        Task<ProductModel> CreateProduct(ProductModel model);

        Task<ProductModel> UpdateProduct(ProductModel model);

        Task<bool> DeleteProductById(long id);

    }
}
