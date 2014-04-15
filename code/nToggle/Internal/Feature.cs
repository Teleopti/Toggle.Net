using System;
using System.Collections.Generic;
using System.Linq;
using nToggle.Specifications;

namespace nToggle.Internal
{
	public class Feature
	{
		private readonly ICollection<IToggleSpecification> _specifications;

		public Feature(string flagName, params IToggleSpecification[] specifications)
		{
			FlagName = flagName;
			_specifications = new List<IToggleSpecification>();
			Array.ForEach(specifications, AddSpecification);
			if (!specifications.Any())
			{
				AddSpecification(new FalseSpecification());
			}
		}

		public string FlagName { get; private set; }

		public bool IsEnabled()
		{
			return _specifications.All(x => x.IsEnabled());
		}

		public void AddSpecification(IToggleSpecification specification)
		{
			_specifications.Add(specification);
		}
	}
}