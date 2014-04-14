﻿using System.Collections.Generic;
using System.Linq;
using nToggle.Specifications;

namespace nToggle.Internal
{
	public class Feature
	{
		public Feature(string flagName, params IToggleSpecification[] specifications)
		{
			FlagName = flagName;
			Specifications = specifications.Any() ? 
					specifications : 
					new[] {new FalseSpecification()};
		}

		public string FlagName { get; private set; }
		public IEnumerable<IToggleSpecification> Specifications { get; private set; }

		public bool IsEnabled()
		{
			return Specifications.All(x => x.IsEnabled());
		}

		public override bool Equals(object obj)
		{
			var that = obj as Feature;
			return that != null && that.FlagName.Equals(FlagName);
		}

		public override int GetHashCode()
		{
			return FlagName.GetHashCode();
		}
	}
}