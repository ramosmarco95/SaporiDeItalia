using SaporiDeItalia.ViewModels;
namespace SaporiDeItalia.Views;

public partial class ContactPage : ContentPage
{
	public ContactPage(ContactViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}