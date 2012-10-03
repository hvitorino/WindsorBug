using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BugScenario
{
    public class GenericClassInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                AllTypes
                    .FromAssemblyContaining<OneEntity>()
                    .BasedOn(typeof(GenericInterface<>))
                    .WithService
                    .AllInterfaces());
        }
    }
}
