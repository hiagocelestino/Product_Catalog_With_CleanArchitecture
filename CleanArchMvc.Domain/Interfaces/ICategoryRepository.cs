using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    interface ICategoruRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<Category> GetByIdAsync(int? id);

        Task<Category> CreateAsync(Category category);
        
        Task<Category> UpdateAsync(Category category);
        
        Task<Category> RemoveAsync(Category category);
    }
}