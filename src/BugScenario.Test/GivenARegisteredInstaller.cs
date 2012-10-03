using Castle.Windsor;
using NUnit.Framework;

namespace BugScenario.Test
{
    [TestFixture]
    public class GivenARegisteredInstaller
    {
        private WindsorContainer container;

        [TestFixtureSetUp]
        public void Scenario()
        {
            container = new WindsorContainer();
            container.Install(new GenericClassInstaller());
        }

        [Test]
        public void ShouldResolveOneGenericClassOfOneEntity()
        {
            var a = new OneGenericClass<OneEntity>();
            var oneGenericClass = container.Resolve<GenericInterface<OneEntity>>();

            Assert.That(oneGenericClass, Is.InstanceOf<OneGenericClass<OneEntity>>());
        }

        [Test]
        public void ShouldResolveAnotherGenericClassOfAnotherEntity()
        {
            var oneGenericClass = container.Resolve<GenericInterface<AnotherEntity>>();

            Assert.That(oneGenericClass, Is.InstanceOf<AnotherGenericClass<AnotherEntity>>());
        }
    }
}
