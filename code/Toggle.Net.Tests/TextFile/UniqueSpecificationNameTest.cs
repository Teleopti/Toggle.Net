using System;
using NUnit.Framework;
using SharpTestsEx;
using Toggle.Net.Providers.TextFile;
using Toggle.Net.Specifications;

namespace Toggle.Net.Tests.TextFile
{
	public class UniqueSpecificationNameTest
	{
		[Test]
		public void ShouldThrowIfAddingSpecificationsWithSameName()
		{
			var mappings = new DefaultSpecificationMappings();
			mappings.AddMapping("double", new TrueSpecification());
			Assert.Throws<ArgumentException>(() => 
				mappings.AddMapping("double", new TrueSpecification()));
		}

		[Test]
		public void ShouldThrowIfAddingSpecificationsWithSameNameAsDefaultOne()
		{
			var mappings = new DefaultSpecificationMappings();
			Assert.Throws<ArgumentException>(() =>
				mappings.AddMapping("false", new TrueSpecification()));
		}

		[Test]
		public void ShouldNotBeAbleToChangeNameSpecificationMappings()
		{
			var mappings = new DefaultSpecificationMappings();
			var specificationMappings = mappings.NameSpecificationMappings();
			specificationMappings.Add("added", new TrueSpecification());

			mappings.NameSpecificationMappings().Count
				.Should().Not.Be.EqualTo(specificationMappings.Count);
		}

		[Test]
		public void ShouldThrowIfAddingMultipleSpecificationDifferOnlyInCasing()
		{
			var mappings = new DefaultSpecificationMappings();
			mappings.AddMapping("DOUBle", new TrueSpecification());
			Assert.Throws<ArgumentException>(() =>
				mappings.AddMapping("double", new TrueSpecification()));
		}
	}
}