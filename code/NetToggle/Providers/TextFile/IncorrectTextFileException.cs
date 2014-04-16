using System;

namespace NetToggle.Providers.TextFile
{
	public class IncorrectTextFileException : Exception
	{
		public IncorrectTextFileException(string message) :base(message)
		{
		}
	}
}