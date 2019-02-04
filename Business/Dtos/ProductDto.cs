using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Business.Abstract;
using Entities.Concrete;

namespace Business.Dtos
{
    public class ProductDto : ICustomMapping
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<PhotoDto> Photos { get; set; }

        public void CreateMapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.CategoryName,
                    opt => opt.MapFrom(p => p.Category != null ? p.Category.Name : string.Empty));
            profile.CreateMap<Product,ProductDto>()
                .ForMember(dto => dto.Photos,
                    opt => opt.MapFrom(p => p.Photos));
        }
    }
}
