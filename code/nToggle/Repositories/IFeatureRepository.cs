using nToggle.Internal;

namespace nToggle.Repositories
{
	/// <summary>
	/// Gets or adds features to the repository
	/// </summary>
	public interface IFeatureRepository
	{
		/// <summary>
		/// Gets the feature from the repository.
		/// If not present, this method must return <code>null</code>.
		/// </summary>
		/// <param name="flagName"><see cref="Feature.FlagName"/></param>
		/// <returns><see cref="Feature"/></returns>
		Feature Get(string flagName);

		/// <summary>
		/// Adds the feature to the repository.
		/// If the repository already contains this feature, the feature should be replaced.
		/// </summary>
		/// <param name="feature"></param>
		void Add(Feature feature);
	}
}