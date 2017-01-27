using GLClub;
using Xamarin.Forms;

namespace Core.View
{
    public class CustomRssCell : ViewCell
    {
		public CustomRssCell()
		{
			//instantiate each of our views
			var titleLabel = new Label { TextColor = Color.Black };
			var descriptionLabel = new Label { TextColor = Color.FromHex(GlClubResource.Color.SecondaryTextColor), FontAttributes = FontAttributes.Italic};
			var dateLabel = new Label { TextColor = Color.FromHex(GlClubResource.Color.SecondaryTextColor) };
			var verticaLayout = new StackLayout { BackgroundColor = Color.White };
			var horizontalLine = new StackLayout {
				BackgroundColor = Color.FromHex(GlClubResource.Color.HorizontalLineColor),
				HeightRequest = 0.5,
				HorizontalOptions = LayoutOptions.Fill
			};

			//set bindings
			titleLabel.SetBinding(Label.TextProperty, new Binding("Title"));
			descriptionLabel.SetBinding(Label.TextProperty, new Binding("Description"));
			dateLabel.SetBinding(Label.TextProperty, new Binding("Date"));

			//Set properties for desired design
			titleLabel.FontSize = 24;
			descriptionLabel.FontSize = 14;
			dateLabel.FontSize = 12;
			verticaLayout.Padding = 10;
			dateLabel.HorizontalTextAlignment = TextAlignment.End;

			//add views to the view hierarchy
			verticaLayout.Children.Add(titleLabel);
			verticaLayout.Children.Add(horizontalLine);
			verticaLayout.Children.Add(descriptionLabel);
			verticaLayout.Children.Add(dateLabel);

			// add to parent view
			View = verticaLayout;
		}
	}
}
