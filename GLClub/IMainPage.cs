using System;
namespace GLClub
{
	public interface IMainPage
	{
		string FromHtml(string htmlFormat);
		string FormatDate(string date);
		void OnItemSelected(string link);
		void ShowMessage(string message);
	}
}
