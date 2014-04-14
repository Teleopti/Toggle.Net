using nToggle.Configuration;
using nToggle.Configuration.Specifications;
using NUnit.Framework;
using SharpTestsEx;

namespace nToggleTests
{
	public class EnabledTest
	{
		[Test]
		public void ShouldBeEnabled()
		{
			const string flag = "someFlag";
			var conf = new InMemoryConfiguration();
			conf.Add(flag, new TrueSpecification());
			var factory = new ToggleCheckerFactory(conf);

			var nToggle = factory.Build();

			nToggle.IsEnabled(flag)
				.Should().Be.True();
		}

		[Test]
		public void ShouldBeDisabled()
		{
			const string flag = "aFlag";
			var conf = new InMemoryConfiguration();
			conf.Add(flag, new FalseSpecification());
			var factory = new ToggleCheckerFactory(conf);

			var nToggle = factory.Build();

			nToggle.IsEnabled(flag)
				.Should().Be.False();
		}

		[Test]
		public void ShouldBeDisabledIfNotDefined()
		{
			var conf = new InMemoryConfiguration();
			var factory = new ToggleCheckerFactory(conf);

			var nToggle = factory.Build();

			nToggle.IsEnabled("non existing")
				.Should().Be.False();
		}
	}
}