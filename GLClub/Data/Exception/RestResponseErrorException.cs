using System;
using System.Net;

namespace GLClub
{
	public class RestResponseErrorException: Exception
	{
		public HttpStatusCode StatusCode { get; set; }

		public RestResponseErrorException(HttpStatusCode statusCode)
		{
			StatusCode = statusCode;
		}
	}
}
