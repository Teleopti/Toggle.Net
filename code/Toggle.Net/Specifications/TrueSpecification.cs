using System.Collections.Generic;

namespace Toggle.Net.Specifications
{
	public class TrueSpecification : IToggleSpecification
	{
		public string Name
		{
			get { return "true"; }
		}

		public bool IsEnabled(string currentUser, IDictionary<string, string> parameters)
		{
			return true;
		}
	}
}