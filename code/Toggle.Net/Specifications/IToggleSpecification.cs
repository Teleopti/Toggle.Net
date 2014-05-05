using System.Collections.Generic;
using Toggle.Net.Internal;

namespace Toggle.Net.Specifications
{
	/// <summary>
	/// Decides if a <see cref="Feature"/> is enabled ot not.
	/// Implementation is shared between diffent features,
	/// so make sure you don't keep global state.
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