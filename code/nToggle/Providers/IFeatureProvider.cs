using nToggle.Internal;

namespace nToggle.Providers
{
	/// <summary>
	/// Gets or adds features to the repository
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