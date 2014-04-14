namespace nToggle
{
	public abstract class Feature : IFeature
	{
		protected Feature(string flag)
		{
			Flag = flag;
		}
		public string Flag { get; private set; }
	}
}