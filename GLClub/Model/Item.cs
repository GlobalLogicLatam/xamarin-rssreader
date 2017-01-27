using System.Xml.Serialization;
using GLClub;
using Xamarin.Forms;

namespace Core.Model
{
	public class Item
	{
		[XmlElement("title")]
		public string Title { get; set; }

		[XmlElement("link")]
		public string Link { get; set; }

		[XmlElement("description")]
		public string Description { get; set; }

		[XmlElement("pubDate")]
		public string Date { get; set; }

		public string GetFormattedDate()
		{
			// Tue, 05 Apr 2016 14:59:59 +0000
			if (Date == null) return "";
			var mainPageImpl = DependencyService.Get<IMainPage>();
			if (mainPageImpl == null) return "";
			return mainPageImpl.FormatDate(Date);
		}
	}
}
