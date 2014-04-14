using nToggle.Configuration;
using nToggleTests.Features;
using NUnit.Framework;
using SharpTestsEx;

namespace nToggleTests
{
	public class EnabledTest
	{
		[Test]
		public void ShouldBeEnabledIfDefined()
		{
			var feature = new SimpleFeature();
			var conf = new InMemoryConfiguration();
			conf.Enable(feature);
			var factory = new ToggleCheckerFactory(conf);

			var nToggle = factory.Build();

			nToggle.IsEnabled(feature.Flag)
				.Should().Be.True();
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