using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal//şuan ekleme silme güncelleme yaptık
    {
    }
}
