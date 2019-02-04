using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();

        Task<ProductDto> GetById(int id);

        Task Add(Product product);

        Task Delete(int productid);

        Task Update(Product product);

        Task<List<ProductDto>> GetByCategory(int categoryId);
    }
}
