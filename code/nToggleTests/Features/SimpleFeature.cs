using nToggle.Configuration;

namespace nToggleTests.Features
{
	public class SimpleFeature : IFeature
	{
		public string Flag
		{
			get { return "Simple Feature"; }
		}
	}
}