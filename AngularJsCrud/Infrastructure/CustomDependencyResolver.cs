using AngularJsCrud.Contract;
using AngularJsCrud.Models;
using AngularJsCrud.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace AngularJsCrud.Infrastructure
{
    public class CustomDependencyResolver :IDependencyResolver
    {
        UnityContainer unityContainer;
        public CustomDependencyResolver()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<IEmployeeRepository, EmployeeRepository>();

        }
        public IDependencyScope BeginScope()
        {
           return this;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return unityContainer.Resolve(serviceType);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return unityContainer.ResolveAll(serviceType);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}