using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace SaporiDeItalia.ViewModels
{
    public partial class LocationViewModel : ObservableObject
    {
        private const string ApiKey = "ADD-YOUR-API"; // Replace with your API key
        private const string Address = "1360 S Eagle Flight Way, Boise, ID 83709";

        [ObservableProperty]
        private string mapImageUrl;

        public LocationViewModel()
        {
            MapImageUrl = GenerateMapUrl();
        }

        private string GenerateMapUrl()
        {
            string encodedAddress = Uri.EscapeDataString(Address);
            return $"https://maps.googleapis.com/maps/api/staticmap?center={encodedAddress}&zoom=15&size=600x300&markers=color:red%7C{encodedAddress}&key={ApiKey}";
        }

        [ObservableProperty]
        private string restaurantAddress = "1360 S Eagle Flight Way, Boise, ID 83709";

        [RelayCommand]
        private async Task OpenInMapsAsync()
        {
            string mapsUrl = $"https://www.google.com/maps/search/?api=1&query={Uri.EscapeDataString(RestaurantAddress)}";

            try
            {
                await Launcher.OpenAsync(mapsUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening maps: {ex.Message}");
            }
        }
    }
}
