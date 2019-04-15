using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using DependencyInjection.Models;
using System.Web.Mvc;

namespace DependencyInjection.Infrastructure
{
    public class DefaultDependenceResolver : IDependencyResolver
    {
        IKernel kernel;
        public DefaultDependenceResolver()
        {
            kernel = new StandardKernel();
            AddBinding();
        }

        public void AddBinding()
        {
            kernel.Bind<ITotalValueCalculator>().To<TotalValueCalculator>();
            kernel.Bind<IDiscount>().To<DefaultDiscount>();
            kernel.Bind<IDiscontSize>().To<DiscountSize>().WithPropertyValue("Size", 20m);
            kernel.Bind<IDiscount>().To<FlexibleDiscount>().WhenInjectedInto<TotalValueCalculator>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}