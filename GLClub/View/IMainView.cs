using System.Collections.ObjectModel;
using Core.Model;

namespace GLClub
{
	public interface MainView
	{
		void Render(ObservableCollection<Item> ItemCollection);
	}
}
