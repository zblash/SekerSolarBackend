using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task Add(User user)
        {
            await _userDal.Add(user);
        }

        public async Task Delete(int userid)
        {
            await _userDal.Delete(new User{u => u.Id == userid});
        }

        public async Task<List<User>> GetAll()
        {
            return await _userDal.GetList();
        }

        public async Task<User> GetById(int id)
        {
            return await _userDal.Get(u => u.Id == id);
        }

        public async Task Update(User user)
        {
            await _userDal.Update(user);
        }
    }
}
