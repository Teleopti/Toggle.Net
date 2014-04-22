using System;
using System.Configuration;
using System.Web;
using System.Web.Script.Serialization;
using Toggle.Net.Internal;
using Toggle.Net.Providers.TextFile;

namespace Toggle.Net.Web
{
	public class ToggleNetHandler : IHttpHandler
	{
		private readonly Lazy<IToggleChecker> _toggleChecker;
		private static readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

		public ToggleNetHandler()
		{
			_toggleChecker = new Lazy<IToggleChecker>(makeSureToggleCheckerIsSet);
		}

		public void ProcessRequest(HttpContext context)
		{
			var flagName = context.Request["flag"];
			var reply = new ToggleReply
			{
				IsEnabled = _toggleChecker.Value.IsEnabled(flagName)
			};
			var serialized = serializer.Serialize(reply);

			context.Response.Clear();
			context.Response.ContentType = "application/json; charset=utf-8";
			context.Response.Write(serialized);

		}

		private IToggleChecker makeSureToggleCheckerIsSet()
		{
				const string appSetting = "toggle.net.txt";
				var path = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[appSetting]);
				return new ToggleChecker(new FileProvider(new FileReader(path)));
		}

		public bool IsReusable
		{
			get { return true; }
		}
	}
}
