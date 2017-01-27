using Android.Content;
using Android.Text;
using Android.Util;
using Android.Widget;
using GLClub.Droid;
using Java.Text;
using Java.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(MainPageImpl))]
namespace GLClub.Droid
{
	public class MainPageImpl : IMainPage
	{
		public MainPageImpl()
		{
		}

		public string FormatDate(string pubDate)
		{
			var format = new SimpleDateFormat("ccc, dd LLLL yyyy HH:mm:ss Z", Locale.English);
			var date = new Date();
			try
			{
				date = format.Parse(pubDate);
				var sdf = new SimpleDateFormat("ccc dd LLLL yyyy", Locale.Default);
				return sdf.Format(date);
			}
			catch (Java.Text.ParseException e)
			{
				Log.Info("MainPageImpl", "Error parsing date", e);
				// Return the same passed string
				return pubDate;
			}
		}

		public string FromHtml(string htmlFormat)
		{
			return Html.FromHtml(htmlFormat).ToString();
		}

		public void OnItemSelected(string link)
		{
			var i = new Intent(Intent.ActionView);
			i.SetData(Android.Net.Uri.Parse(link));
			Forms.Context.StartActivity(i);
		}

		public void ShowMessage(string message)
		{
			Toast.MakeText(Forms.Context, message, ToastLength.Short).Show();
		}
	}
}
