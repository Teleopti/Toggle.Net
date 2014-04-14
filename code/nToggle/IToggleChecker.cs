namespace nToggle
{
	/// <summary>
	/// Main interface at runtime.
	/// Returns <code>true</code> if feature with specified flag name is enabled,
	/// otherwise <code>false</code>.
	/// </summary>
	public interface IToggleChecker
	{
		bool IsEnabled(string confligFlag);
	}
}