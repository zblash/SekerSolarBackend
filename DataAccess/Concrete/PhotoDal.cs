using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class PhotoDal : EFRepositoryBase<AppContext, Photo>, IPhotoDal
    {
    }
}
