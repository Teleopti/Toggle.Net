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

		/// <summary>
		/// Called once at startup to see if owner <see cref="Feature"/> parameter values
		/// is valid for this specification.
		/// If not valid, throw a <see cref="InvalidSpecificationParameterException"/>
		/// with suitable message.
		/// </summary>
		/// <param name="toggleName"></param>
		/// <param name="parameters"></param>
		void Validate(string toggleName, IDictionary<string, string> parameters);
	}
}