using System.Configuration;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Script.Serialization;
using Toggle.Net.Internal;
using Toggle.Net.Providers.TextFile;

namespace Toggle.Net.Web
{
	public class ToggleNetHandler : IHttpHandler
	{
		private volatile IToggleChecker _toggleChecker;
		private readonly object lockObject = new object();
		private static readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

		public void ProcessRequest(HttpContext context)
		{
			makeSureToggleCheckerIsSet(context);

			var flagName = context.Request["flagName"];
			var reply = new ToggleReply
			{
				IsEnabled = _toggleChecker.IsEnabled(flagName)
			};
			var serialized = serializer.Serialize(reply);

			context.Response.Clear();
			context.Response.ContentType = "application/json; charset=utf-8";
			context.Response.Write(serialized);

		}

		private void makeSureToggleCheckerIsSet(HttpContext context)
		{
			if (_toggleChecker != null) return;
			lock (lockObject)
			{
				if (_toggleChecker != null) return;

				const string appSetting = "toggle.net.txt";
				var path = context.Server.MapPath(ConfigurationManager.AppSettings[appSetting]);
				_toggleChecker = new ToggleChecker(new FileProvider(new FileReader(path)));
			}
		}

		public bool IsReusable
		{
			get { return true; }
		}
	}
}