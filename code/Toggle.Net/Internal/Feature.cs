using System;
using System.Collections.Generic;
using System.Linq;
using Toggle.Net.Specifications;

namespace Toggle.Net.Internal
{
	public class Feature
	{
		private readonly ICollection<IToggleSpecification> _specifications;

		public Feature(string flagName, IToggleSpecification specification)
		{
			FlagName = flagName;
			_specifications = new List<IToggleSpecification>();
			AddSpecification(specification);
		}

		public string FlagName { get; private set; }

		public bool IsEnabled(string currentUser)
		{
			return _specifications.All(x => x.IsEnabled(currentUser));
		}

		public void AddSpecification(IToggleSpecification specification)
		{
			if(specification==null)
				throw new ArgumentNullException("specification");
			_specifications.Add(specification);
		}
	}
}