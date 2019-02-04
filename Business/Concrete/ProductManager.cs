using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Dtos;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        public async Task Add(Product product)
        {
            await _productDal.Add(product);
        }

        public async Task Delete(int productid)
        {
            await _productDal.Delete(new Product {Id = productid});
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var products = await _productDal.GetList();
           return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetById(int id)
        { 

            var Product = await _productDal.Get(p => p.Id == id);
            return _mapper.Map<ProductDto>(Product);

        }

        public async Task Update(Product product)
        {
            await _productDal.Update(product);
        }

        public async Task<List<ProductDto>> GetByCategory(int categoryId)
        {
            var products = await _productDal.GetList(p => p.CategoryId == categoryId);
            return _mapper.Map<List<ProductDto>>(products);
        }
        
    }
}
