using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAll();

        Task<Category> GetById(int id);

        Task Add(Category category);

        Task Delete(int categoryid);

        Task Update(Category category);
    }
}
