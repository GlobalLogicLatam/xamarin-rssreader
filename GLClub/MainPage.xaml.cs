using System.Collections.ObjectModel;
using Core.Model;
using Core.View;
using GLClub;
using Xamarin.Forms;

namespace Core
{
	public partial class MainPage : ContentPage, MainView
	{
		private MainPresenter presenter;

		public MainPage()
		{
			InitializeComponent();

			presenter = new MainPresenter(this);
			this.Title = "GL Club";
			presenter.Init();
		}

		void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e == null) return; // has been set to null, do not 'process' tapped event
			var listViewObject = ((ListView)sender);
			var selectedItem = listViewObject.SelectedItem as Item;
			presenter.OnItemTapped(selectedItem);
			listViewObject.SelectedItem = null; // de-select the row
		}

		public void Render(ObservableCollection<Item> ItemCollection)
		{
			listView.ItemTemplate = new DataTemplate(typeof(CustomRssCell));

			// Attach the collection to ItemsSource
			listView.ItemsSource = ItemCollection;
			Content = listView;
		}
	}
}
