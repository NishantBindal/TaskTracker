using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(TaskTracker.Auth.App_Start.WindsorActivator), "PreStart")]  
//[assembly: ApplicationShutdownMethodAttribute(typeof(TaskTracker.Auth.App_Start.WindsorActivator), "Shutdown")]  
 namespace TaskTracker.Auth.App_Start
{
    public class WindsorActivator
    {
        static ContainerBootstrapper bootstrapper;

        public static void PreStart()
        {
            bootstrapper = ContainerBootstrapper.Bootstrap();
        }

        public static void Shutdown()
        {
            if (bootstrapper != null)
                bootstrapper.Dispose();
        }
    }
}