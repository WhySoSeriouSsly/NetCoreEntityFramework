using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using EasyNetQ.LightInject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.LightInject
{
    class LightInjectBusinessModule: ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IProductService, ProductManager>();
            serviceRegistry.Register<IProductDal, EfProductDal>();
            serviceRegistry.Register<ICategoryService, CategoryManager>();
            serviceRegistry.Register<ICategoryDal, EfCategoryDal>();

        }
    }
}
