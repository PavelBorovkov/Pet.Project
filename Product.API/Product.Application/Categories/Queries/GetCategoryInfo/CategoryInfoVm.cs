using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Common.Mappings;
using TestTask.Domain;

namespace TestTask.Application.Categories.Queries.GetCategoryInfo
{
    public class CategoryInfoVm:IMapWith<Category>
    {
        public string Name { get; set; }
        public string? Description { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryInfoVm>()
                .ForMember(CategoryVm => CategoryVm.Name,
                    opt => opt.MapFrom(Category => Category.Name))
                .ForMember(CategoryVm => CategoryVm.Description,
                    opt => opt.MapFrom(Category => Category.Description));
        }
    }
}
