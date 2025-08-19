using ProductAppAsync.src.Dtos.Category;
using ProductAppAsync.src.models;

public interface ICateogoryService
{
    Task<List<Category>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(Guid id);
    Task<CategoryDto> AddAsync(CategoryCreatDto category);
    Task<CategoryDto> UpdateAsync(CategoryUpdateDto category,Guid id);
    Task DeleteAsync(Guid id);
}