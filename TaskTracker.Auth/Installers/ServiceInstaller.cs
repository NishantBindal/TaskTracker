using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskTracker.Auth.Contracts;
using TaskTracker.Auth.TokenGenerator;

namespace TaskTracker.Auth.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                 Component
                 .For<ITokenGenerator>()
                 .ImplementedBy<BasicAuthTokenGenerator>()
                 .LifestyleSingleton());
        }
    }
}