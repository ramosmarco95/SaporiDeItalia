
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SaporiDeItalia.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MenuItem = SaporiDeItalia.Models.MenuItem;

namespace SaporiDeItalia.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {
        private readonly MenuService _menuService;

        [ObservableProperty]
        private ObservableCollection<MenuItem> _menuItems = new();


        public MenuViewModel(MenuService menuService)
        {
            _menuService = menuService ?? throw new ArgumentNullException(nameof(menuService));
            LoadMenuCommand = new AsyncRelayCommand(LoadMenuAsync);
        }

        public ICommand LoadMenuCommand { get; }

        private async Task LoadMenuAsync()
        {
            try
            {
                var items = await _menuService.GetMenuAsync();
                if (items != null && items.Any())
                {
                    MenuItems = new ObservableCollection<MenuItem>(items);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading menu: {ex.Message}");
            }
        }


    }
}

