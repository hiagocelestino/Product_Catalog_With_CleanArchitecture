using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Category> GetByIdAsync(int? id);

        Task<IEnumerable<Product>> GetProductCategoryAsync();

        Task<Category> CreateAsync(Category category);
        
        Task<Category> UpdateAsync(Category category);
        
        Task<Category> RemoveAsync(Category category);
    }
}