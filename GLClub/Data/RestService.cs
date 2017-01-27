using System.IO;
using System.Net;
using System.Threading.Tasks;
using GLClub;

namespace Core
{
	public class RestService : IRestService
	{

		public Stream DoGet(string url)
		{
			var request = WebRequest.CreateHttp(url);
			request.ContentType = "application/xml";
			request.Method = "GET";

			var response = request.GetResponse() as HttpWebResponse;
			if (response.StatusCode == HttpStatusCode.OK) return response.GetResponseStream();
			throw new RestResponseErrorException(response.StatusCode);
		}
	}
}
