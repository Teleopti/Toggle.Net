using System.Collections.Generic;
using System.Linq;
using nToggle.Configuration.Specifications;

namespace nToggle.Internal
{
	public class Feature
	{
		private readonly List<IToggleSpecification> _specifications;

		public Feature(string flagName, params IToggleSpecification[] specifications)
		{
			FlagName = flagName;
			_specifications = new List<IToggleSpecification>();
			_specifications.AddRange(specifications);
		}

		public string FlagName { get; private set; }

		public bool IsEnabled()
		{
			return _specifications.All(x => x.IsEnabled());
		}
	}
}