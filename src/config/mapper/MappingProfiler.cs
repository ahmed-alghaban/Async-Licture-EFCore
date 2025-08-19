using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProductAppAsync.src.Dtos.Category;
using ProductAppAsync.src.models;

namespace ProductAppAsync.src.config.mapper
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryCreatDto>();
            CreateMap<Category, CategoryUpdateDto>();
        }
    }
}
