using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<List<User>> GetAll();

        Task<User> GetById(int id);

        Task Add(User user);

        Task Delete(int userid);

        Task Update(User user);
    }
}
