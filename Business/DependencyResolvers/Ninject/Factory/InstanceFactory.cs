using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Ninject.Factory
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new NinjectBusinessModule());
            return kernel.Get<T>();
        }
    }
}
