using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Internal;
using Toggle.Net.Specifications;
using Toggle.Net.Tests.Stubs;

namespace Toggle.Net.Tests.Toggle
{
	public class UserTest
	{
		[Test]
		public void ShouldBeEnabled()
		{
			const string flag = "someFlag";
			const string currentUser = "roger";
			const string activedUser = "roger";

			var toggle = new ToggleChecker(new InMemoryProvider(
				new Feature(flag, new UserSpecification(activedUser))
			));
			toggle.SetUserProvider(new UserProviderStub(currentUser));

			toggle.IsEnabled(flag)
				.Should().Be.True();
		}

		[Test]
		public void ShouldBeDisabled()
		{
			const string flag = "someFlag";
			const string currentUser = "roger";
			const string activedUser = "someone else";

			var toggle = new ToggleChecker(new InMemoryProvider(
				new Feature(flag, new UserSpecification(activedUser))
			));
			toggle.SetUserProvider(new UserProviderStub(currentUser));

			toggle.IsEnabled(flag)
				.Should().Be.False();
		} 
	}
}