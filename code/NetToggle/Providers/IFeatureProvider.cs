using NetToggle.Internal;

namespace NetToggle.Providers
{
	/// <summary>
	/// Gets features settings from the source
	/// </summary>
	public interface IFeatureProvider
	{
		/// <summary>
		/// Gets the feature from the repository.
		/// If not present, this method must return <code>null</code>.
		/// </summary>
		/// <param name="flagName"><see cref="Feature.FlagName"/></param>
		/// <returns><see cref="Feature"/></returns>
		Feature Get(string flagName);
	}
}