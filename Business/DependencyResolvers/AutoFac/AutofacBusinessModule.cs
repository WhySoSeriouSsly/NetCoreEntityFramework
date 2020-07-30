using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.DataAccess.Nhibernate;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.NHiberNate;
using DataAccess.Concrete.NHiberNate.Helpers;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutofacBusinessModule:Module//bunn karşılığı budur burda yapılır.
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();//

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<SqlServerHelper>().As<NHibernateHelper>();//
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();


        }
    }
}
