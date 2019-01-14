using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class CategoryDal : EFRepositoryBase<AppContext,Category>, ICategoryDal
    {
        
    }
}
