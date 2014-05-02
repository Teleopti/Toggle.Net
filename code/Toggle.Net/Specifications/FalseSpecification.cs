using System.Collections.Generic;

namespace Toggle.Net.Specifications
{
	public class FalseSpecification : IToggleSpecification
	{
		public string Name
		{
			get { return "false"; }
		}

		public bool IsEnabled(string currentUser, IDictionary<string, string> parameters)
		{
			return false;
		}
	}
}