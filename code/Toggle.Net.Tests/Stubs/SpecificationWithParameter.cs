using Toggle.Net.Specifications;

namespace Toggle.Net.Tests.Stubs
{
	public class SpecificationWithParameter : ToggleSpecification
	{
		public const string ParameterName = "TheParameterName";

		public override string Name
		{
			get { return "ParameterSpecification"; }
		}

		public override bool IsEnabled(string currentUser)
		{
			return bool.Parse(Parameters[ParameterName]);
		}
	}
}