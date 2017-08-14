using System;
using System.Collections.Generic;
using LightInject;

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
            Register(Container);
            RegisterViews(Container);
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
    }
}
