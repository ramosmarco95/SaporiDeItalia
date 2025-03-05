using SaporiDeItalia.ViewModels;

namespace SaporiDeItalia.Views;

public partial class LocationPage : ContentPage
{
	public LocationPage(LocationViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}