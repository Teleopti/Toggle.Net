using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
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

			var toggle = new ToggleConfiguration(new InMemoryProvider(
				new Feature(flag, new UserSpecification(activedUser))
			))
			.SetUserProvider(new UserProviderStub(currentUser))
			.Create();

			toggle.IsEnabled(flag)
				.Should().Be.True();
		}

		[Test]
		public void ShouldBeDisabled()
		{
			const string flag = "someFlag";
			const string currentUser = "roger";
			const string activedUser = "someone else";

			var toggle = new ToggleConfiguration(new InMemoryProvider(
				new Feature(flag, new UserSpecification(activedUser))
			))
			.SetUserProvider(new UserProviderStub(currentUser))
			.Create();

			toggle.IsEnabled(flag)
				.Should().Be.False();
		} 
	}
}