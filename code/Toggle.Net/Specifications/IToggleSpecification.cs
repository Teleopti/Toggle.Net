using Toggle.Net.Internal;

namespace Toggle.Net.Specifications
{
	/// <summary>
	/// Decides if a <see cref="Feature"/> is enabled ot not.
	/// </summary>
	public interface IToggleSpecification
	{
		/// <summary>
		/// A name for this specification. Every specification needs a unique name.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Is the <see cref="Feature"/> enabled or not?
		/// </summary>
		/// <param name="currentUser"></param>
		/// <returns></returns>
		bool IsEnabled(string currentUser);

		/// <summary>
		/// Adds a parameter to this specification.
		/// Can be used when validating if this specificatin is valid.
		/// </summary>
		/// <param name="parameterName"></param>
		/// <param name="parameterValue"></param>
		void AddParameter(string parameterName, string parameterValue);
	}
}