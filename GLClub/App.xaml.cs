using System;
using System.IO;
using Core;
using GLClub;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Core
{
	public partial class App : Application
	{
		public App()
		{
			MainPage = new NavigationPage()
			{
				BarBackgroundColor = Color.FromHex(GlClubResource.Color.BarBackgroundColor),
				BarTextColor = Color.White
			};
			MainPage.Navigation.PushAsync(new MainPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
