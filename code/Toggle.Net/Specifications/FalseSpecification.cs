using System.Collections.Generic;

namespace Toggle.Net.Specifications
{
	public class FalseSpecification : IToggleSpecification
	{
		public bool IsEnabled(string currentUser, IDictionary<string, string> parameters)
		{
			return false;
		}
	}
}