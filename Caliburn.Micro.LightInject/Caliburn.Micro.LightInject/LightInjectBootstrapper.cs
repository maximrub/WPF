using System;
using System.Collections.Generic;
using LightInject;
using LightInject.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Caliburn.Micro.LightInject
{
    public class Bootstrapper : BootstrapperBase
    {
        protected ServiceContainer m_Container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override sealed void Configure()
        {
            m_Container = new ServiceContainer();
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            Register(m_Container);
            RegisterViews(m_Container);
            populateContainer(m_Container, services);
        }

        protected override object GetInstance(Type i_Service, string i_Key)
        {
            return i_Key == null ? m_Container.GetInstance(i_Service) : m_Container.GetInstance(i_Service, i_Key);
        }

        protected override IEnumerable<object> GetAllInstances(Type i_Service)
        {
            return m_Container.GetAllInstances(i_Service);
        }

        protected override void BuildUp(object i_Instance)
        {
            m_Container.InjectProperties(i_Instance);
        }

        /// <summary>
        /// Configure Framework services
        /// </summary>
        protected internal virtual void ConfigureServices(IServiceCollection i_Services)
        {
        }

        /// <summary>
        /// Register Components using LightInject container
        /// </summary>
        protected internal virtual void Register(ServiceContainer i_Container)
        {
        }

        /// <summary>
        /// Register Components using LightInject container
        /// </summary>
        protected internal virtual void RegisterViews(ServiceContainer i_Container)
        {
        }

        private void populateContainer(ServiceContainer i_Container, IServiceCollection i_Services)
        {
            i_Container.CreateServiceProvider(i_Services);
        }
    }
}
