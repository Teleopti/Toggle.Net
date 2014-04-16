using NetToggle.Internal;
using NetToggle.Specifications;
using NUnit.Framework;
using SharpTestsEx;

namespace NetToggleTests.Toggle
{
	public class MultipleTest
	{
		[Test]
		public void ShouldSupportMultipleFeatures()
		{
			const string trueFlag = "someFlag";
			const string falseFlag = "someOtherFlag";

			var nToggle = new ToggleChecker(new InMemoryProvider(
				new Feature(trueFlag, new TrueSpecification()),
				new Feature(falseFlag, new FalseSpecification())
			));

			nToggle.IsEnabled(trueFlag).Should().Be.True();
			nToggle.IsEnabled(falseFlag).Should().Be.False();
		}
	}
}