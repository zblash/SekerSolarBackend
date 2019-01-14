using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class UserDal : EFRepositoryBase<AppContext, User>, IUserDal
    {

    }
}