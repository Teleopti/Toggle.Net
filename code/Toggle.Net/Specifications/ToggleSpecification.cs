using System.Collections.Generic;

namespace Toggle.Net.Specifications
{
	public abstract class ToggleSpecification : IToggleSpecification
	{
		protected ToggleSpecification()
		{
			Parameters = new Dictionary<string, string>();
		}

		public abstract string Name { get; }
		public abstract bool IsEnabled(string currentUser);
		public void AddParameter(string key, string value)
		{
			Parameters.Add(key, value);
		}

		public IDictionary<string, string> Parameters { get; private set; }
	}
}