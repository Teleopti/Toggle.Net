using System;
using System.Collections.Generic;
using System.Linq;
using nToggle.Specifications;

namespace nToggle.Internal
{
	public class Feature
	{
		private readonly ICollection<IToggleSpecification> _specifications;

		public Feature(string flagName, IToggleSpecification specification, params IToggleSpecification[] specifications)
		{
			FlagName = flagName;
			_specifications = new List<IToggleSpecification>();
			AddSpecification(specification);
			Array.ForEach(specifications, AddSpecification);
		}

		public string FlagName { get; private set; }

		public bool IsEnabled()
		{
			return _specifications.All(x => x.IsEnabled());
		}

		public void AddSpecification(IToggleSpecification specification)
		{
			if(specification==null)
				throw new ArgumentNullException("specification");
			_specifications.Add(specification);
		}
	}
}