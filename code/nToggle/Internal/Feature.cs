using System.Collections.Generic;
using System.Linq;
using nToggle.Configuration.Specifications;

namespace nToggle.Internal
{
	public class Feature
	{
		private readonly List<IToggleSpecification> _specifications;

		public Feature(string flag, params IToggleSpecification[] specifications)
		{
			Flag = flag;
			_specifications = new List<IToggleSpecification>();
			_specifications.AddRange(specifications);
		}

		public string Flag { get; private set; }

		public bool IsEnabled()
		{
			return _specifications.All(x => x.IsEnabled());
		}
	}
}