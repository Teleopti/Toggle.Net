using System.Collections.Generic;
using System.Linq;
using nToggle.Configuration.Specifications;

namespace nToggle.Internal
{
	public class Feature
	{
		public Feature(string flagName, params IToggleSpecification[] specifications)
		{
			FlagName = flagName;
			if (specifications.Any())
			{
				Specifications = specifications;
			}
			else
			{
				Specifications = new[] {new FalseSpecification()};
			}
		}

		public string FlagName { get; private set; }
		public IEnumerable<IToggleSpecification> Specifications { get; private set; }

		public bool IsEnabled()
		{
			return Specifications.All(x => x.IsEnabled());
		}
	}
}