using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public interface IPhotoDal : IRepository<Photo>
    {
    }
}