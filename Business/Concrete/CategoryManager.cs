using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public async Task Add(Category category)
        {
            await _categoryDal.Add(category);
        }

        public async Task Delete(int categoryid)
        {
            await _categoryDal.Add(new Category{Id = categoryid});
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryDal.GetList();
        }

        public async Task<Category> GetById(int id)
        {
            return await _categoryDal.Get(c => c.Id == id);
        }

        public async Task Update(Category category)
        {
            await _categoryDal.Update(category);
        }
    }
}
