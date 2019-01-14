using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task Add(Product product)
        {
            await _productDal.Add(product);
        }

        public async Task Delete(int productid)
        {
            await _productDal.Delete(new Product {Id = productid});
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productDal.GetList();
        }

        public async Task<Product> GetById(int id)
        {
            return await _productDal.Get(p => p.Id == id);
        }

        public async Task Update(Product product)
        {
            await _productDal.Update(product);
        }
    }
}
