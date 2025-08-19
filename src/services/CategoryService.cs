using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductAppAsync.src.config.DB;
using ProductAppAsync.src.Dtos.Category;
using ProductAppAsync.src.models;

namespace ProductAppAsync.src.services
{
    public class CategoryService : ICateogoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            return _mapper.Map<CategoryDto>(await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id) ?? throw new Exception("Category not found"));
        }
        public async Task<CategoryDto> AddAsync(CategoryCreatDto createdCategory)
        {
            var category = _mapper.Map<Category>(createdCategory);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(category);
        }
        public async Task<CategoryDto> UpdateAsync(CategoryUpdateDto updatedCategory, Guid id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id) ?? throw new Exception("Category not found");
            _mapper.Map(updatedCategory, category);
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(category);
        }
        public async Task DeleteAsync(Guid id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id) ?? throw new Exception("Category not found");
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}