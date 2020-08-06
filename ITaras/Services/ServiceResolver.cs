using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ITaras.Services;

namespace ITaras
{
    public class ServiceResolver
    {
        private static WindsorContainer container;
        private static IServiceProvider serviceProvider;

        public ServiceResolver(IServiceCollection services)
        {
            container = new WindsorContainer();
            container.Register(Component.For<IServiceRepository>().ImplementedBy<ServiceRepository>());            
            serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(container, services);
        }

        public IServiceProvider GetServiceProvider()
        {
            return serviceProvider;
        }
    }
}
