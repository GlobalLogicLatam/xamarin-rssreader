using System;
using System.Collections.ObjectModel;
using Core.Data;
using Core.Model;
using Xamarin.Forms;

namespace GLClub
{
	public class MainPresenter
	{
		private MainView View { get; set;}
		private IMainPage MainPageImpl;

		public MainPresenter(MainView view)
		{
			View = view;
			MainPageImpl = DependencyService.Get<IMainPage>();
		}

		internal void Init()
		{
			try
			{
				// Get Rss from API
				var feedManager = new FeedManager();
				var rss = feedManager.GetRss();

				// Prepare collection
				var itemCollection = new ObservableCollection<Item>();
				foreach (var item in rss.channel.Items)
				{
					// Parse Html content using custom render for each platform
					if (MainPageImpl != null)
					{
						item.Description = MainPageImpl.FromHtml(item.Description);
					}

					// Format date
					item.Date = item.GetFormattedDate();

					// Add item to collection
					itemCollection.Add(item);
				}

				// Attach collection to view
				View.Render(itemCollection);
			}
			catch (RestResponseErrorException e)
			{
				// handle the possible rest exceptions
				DisplayError(e);
			}
		}

		void DisplayError(RestResponseErrorException e)
		{
			// verifies common status code errors
			switch (e.StatusCode)
			{
				// This is using the same message for all errors. You can cusotmize the text of the message.
				case System.Net.HttpStatusCode.RequestTimeout:
					MainPageImpl.ShowMessage(GlClubResource.String.CommonError);
					break;
				case System.Net.HttpStatusCode.NotFound:
					MainPageImpl.ShowMessage(GlClubResource.String.CommonError);
					break;
				case System.Net.HttpStatusCode.InternalServerError:
					MainPageImpl.ShowMessage(GlClubResource.String.CommonError);
					break;
				default:
					MainPageImpl.ShowMessage(GlClubResource.String.CommonError);
					break;
			}
		}

		internal void OnItemTapped(Item selectedItem)
		{
			if (MainPageImpl != null && selectedItem != null)
			{
				MainPageImpl.OnItemSelected(selectedItem.Link);
			}
		}
	}
}
