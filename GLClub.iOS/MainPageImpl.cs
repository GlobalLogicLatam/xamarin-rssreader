using System;
using Foundation;
using GLClub.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(MainPageImpl))]
namespace GLClub.iOS
{
	public class MainPageImpl : IMainPage
	{
		public MainPageImpl()
		{
		}

		public string FormatDate(string date)
		{
			try
			{
				var dateTime = DateTime.ParseExact(date, "ccc, dd LLLL yyyy HH:mm:ss Z", null);
				return dateTime.ToShortDateString();
			}
			catch (FormatException e)
			{
				return date;
			}
		}

		public string FromHtml(string htmlFormat)
		{
			var attr = new NSAttributedStringDocumentAttributes();
			var nsError = new NSError();
			attr.DocumentType = NSDocumentType.HTML;

			var myHtmlData = NSData.FromString(htmlFormat, NSStringEncoding.Unicode);
			return new NSAttributedString(myHtmlData, attr, ref nsError).Value;
		}

		public void OnItemSelected(string link)
		{
			UIApplication.SharedApplication.OpenUrl(new NSUrl(link));
		}

		public void ShowMessage(string message)
		{
			var alert = new UIAlertView()
			{
				Title = "Error",
				Message = message
			};
			alert.Show();
		}
	}
}
