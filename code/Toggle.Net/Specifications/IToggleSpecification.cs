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
		/// <returns></returns>
		bool IsEnabled();
	}
}