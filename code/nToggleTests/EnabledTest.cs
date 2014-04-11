using nToggle;
using NUnit.Framework;
using SharpTestsEx;

namespace nToggleTests
{
	public class EnabledTest
	{
		[Test]
		public void ShouldBeEnabledIfDefined()
		{
			const string flag = "Some Conf";

			var conf = new InMemoryConfiguration();
			conf.Enable(flag);
			var factory = new ToggleCheckerFactory(conf);

			var nToggle = factory.Build();

			nToggle.IsEnabled(flag)
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