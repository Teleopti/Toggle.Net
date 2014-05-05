using System.Collections.Generic;
using Toggle.Net.Internal;

namespace Toggle.Net.Specifications
{
	/// <summary>
	/// Decides if a <see cref="Feature"/> is enabled ot not.
	/// Implementation should be stateless!
	/// </summary>
	public interface IToggleSpecification
	{
		/// <summary>
		/// Is the <see cref="Feature"/> enabled or not?
		/// </summary>
		/// <param name="currentUser"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		bool IsEnabled(string currentUser, IDictionary<string, string> parameters);
	}
}