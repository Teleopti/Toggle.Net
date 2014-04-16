using NetToggle.Internal;

namespace NetToggle
{
	/// <summary>
	/// Main interface at runtime.
	/// </summary>
	public interface IToggleChecker
	{
		/// <summary>
		/// Returns <code>true</code> if feature with specified flag name is enabled,
		/// otherwise <code>false</code>.
		/// </summary>
		/// <param name="flagName"><see cref="Feature.FlagName"/></param>
		/// <returns></returns>
		bool IsEnabled(string flagName);
	}
}