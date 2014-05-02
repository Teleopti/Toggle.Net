﻿using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Configuration;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Tests.Stubs;

namespace Toggle.Net.Tests.TextFile
{
	public class MissingTest
	{
		[Test]
		public void ShouldBeEnabled()
		{
			var content = new[] { "someflag=true" };
			var toggleChecker = new ToggleConfiguration(new FileProvider(new FileReaderStub(content))).Create();
			toggleChecker.IsEnabled("someflag2")
				.Should().Be.False();
		} 
	}
}