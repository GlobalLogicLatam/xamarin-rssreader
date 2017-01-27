using System.IO;

namespace Core
{
	public interface IRestService
	{
		Stream DoGet(string url);
	}
}
