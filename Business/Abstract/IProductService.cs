using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();

        Task<ProductDto> GetById(int id);

        Task Add(Product product);

        Task Delete(int productid);

        Task Update(Product product);

        Task<List<Product>> GetByCategory(int categoryId);
    }
}
