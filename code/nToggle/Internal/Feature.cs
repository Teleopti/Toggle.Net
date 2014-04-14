using System.Collections.Generic;
using System.Linq;
using nToggle.Configuration.Specifications;

namespace nToggle.Internal
{
	public class Feature
	{
		private readonly ICollection<IToggleSpecification> _specifications;

		public Feature(string flag)
		{
			Flag = flag;
			_specifications = new List<IToggleSpecification>();
		}

		public string Flag { get; private set; }


		public void AddSpecification(IToggleSpecification specification)
		{
			_specifications.Add(specification);
		}

		public bool IsEnabled()
		{
			return _specifications.All(x => x.IsEnabled());
		}
	}
}