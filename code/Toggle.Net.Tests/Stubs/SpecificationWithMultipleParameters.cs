using Toggle.Net.Specifications;

namespace Toggle.Net.Tests.Stubs
{
	public class SpecificationWithMultipleParameters : ToggleSpecification
	{
		public const string ParameterName1 = "TheParameterName1";
		public const string ParameterName2 = "TheParameterName2";
		public const string ParameterName3 = "TheParameterName3";

		public override string Name
		{
			get { return "ParametersSpecification"; }
		}

		public override bool IsEnabled(string currentUser)
		{
			return bool.Parse(Parameters[ParameterName1]) &&
				bool.Parse(Parameters[ParameterName2]) &&
				bool.Parse(Parameters[ParameterName3]);
		}
	}
}