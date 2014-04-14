using nToggle.Internal;
using nToggle.Providers.Memory;
using NUnit.Framework;
using SharpTestsEx;

namespace nToggleTests.Repositories
{
	public class InMemoryRepositoryTest
	{
		[Test]
		public void ShouldEnumerate()
		{
			var feature1 = new Feature("1");
			var feature2 = new Feature("2");

			var repository = new InMemoryProvider {feature1, feature2};

			repository.Should().Have.SameValuesAs(feature1, feature2);
		}
	}
}