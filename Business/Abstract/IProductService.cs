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

        Task<Product> GetById(int id);

        Task Add(Product product);

        Task Delete(int productid);

        Task Update(Product product);
    }
}
