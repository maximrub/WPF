using System;
using System.Collections.Generic;
using LightInject;
using LightInject.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Caliburn.Micro.LightInject
{
    public abstract class LightInjectBootstrapper : BootstrapperBase
    {
        protected LightInjectBootstrapper()
        {
            Initialize();
        }

        protected ServiceContainer Container { get; private set; }

        protected override sealed void Configure()
        {
            Container = new ServiceContainer();
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            Register(Container);
            RegisterViews(Container);
            populateContainer(Container, services);
            OnRegistered(Container);
        }

        protected override object GetInstance(Type i_Service, string i_Key)
        {
            return i_Key == null ? Container.GetInstance(i_Service) : Container.GetInstance(i_Service, i_Key);
        }

        protected override IEnumerable<object> GetAllInstances(Type i_Service)
        {
            return Container.GetAllInstances(i_Service);
        }

        protected override void BuildUp(object i_Instance)
        {
            Container.InjectProperties(i_Instance);
        }

        /// <summary>
        /// Configure Framework services
        /// </summary>
        protected virtual void ConfigureServices(IServiceCollection i_Services)
        {
        }

        /// <summary>
        /// Register Components using LightInject container
        /// </summary>
        protected virtual void Register(ServiceContainer i_Container)
        {
        }

        /// <summary>
        /// Register Components using LightInject container
        /// </summary>
        protected virtual void RegisterViews(ServiceContainer i_Container)
        {
        }

        /// <summary>
        /// Preform actions when the LightInject container is populated
        /// </summary>
        protected virtual void OnRegistered(ServiceContainer i_Container)
        {
        }

        private void populateContainer(ServiceContainer i_Container, IServiceCollection i_Services)
        {
            i_Container.CreateServiceProvider(i_Services);
        }
    }
}
