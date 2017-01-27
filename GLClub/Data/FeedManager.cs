using System.IO;
using System.Xml.Serialization;
using Core.Model;
using GLClub;

namespace Core.Data
{
    public class FeedManager
    {
		public static string FeedUrl = "https://dl.dropboxusercontent.com/u/48706064/Coding%20Dojo/feed.xml";

		private IRestService restService;

	    public FeedManager()
	    {
		    restService = new RestService();
	    }

	    public Rss GetRss()
	    {
			// Get the content from API
			using (var stream = restService.DoGet(FeedUrl))
			{
				// Parse xml to object
				return CreateRssObject(stream);
			}
		}

	    private Rss CreateRssObject(Stream stream)
	    {
		    Rss rss;
			using (var reader = new StreamReader(stream))
			{
				var xRoot = new XmlRootAttribute();

				// This is because this particulary xml file does not have content definition
				xRoot.ElementName = "rss";
				xRoot.IsNullable = true;

				var serializer = new XmlSerializer(typeof(Rss), xRoot);
				rss = (Rss)serializer.Deserialize(reader);
			}

			return rss;
	    }
	}
}
