using SaporiDeItalia.ViewModels;

namespace SaporiDeItalia.Views;

public partial class MenuPage : ContentPage
{
	public MenuPage(MenuViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}