using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class ProductDal : EFRepositoryBase<AppContext, Product>, IProductDal
    {
        public override async Task<Product> Get(Expression<Func<Product, bool>> filter)
        {
            using (var context = new AppContext())
            {
                return await context.Products.Where(filter).Include(p => p.Category).SingleOrDefaultAsync();
            }
        }
        public override async Task<List<Product>> GetList(Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new AppContext())
            {
     
                 return filter == null
                    ? await context.Products.Include(p => p.Category).ToListAsync()
                    : await context.Products.Where(filter).Include(p => p.Category).ToListAsync();
            }
        }
    }
}
