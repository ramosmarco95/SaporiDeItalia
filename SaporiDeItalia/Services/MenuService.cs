using System.Reflection;
using System.Text.Json;
using MenuItem = SaporiDeItalia.Models.MenuItem;

namespace SaporiDeItalia.Services
{
    public class MenuService
    {
        private const string MenuFilePath = "SaporiDeItalia.Resources.menu.json";

        public async Task<IEnumerable<MenuItem>> GetMenuAsync()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using Stream? stream = assembly.GetManifestResourceStream(MenuFilePath);
            if (stream == null)
                return new List<MenuItem>();

            using StreamReader reader = new StreamReader(stream);
            string json = await reader.ReadToEndAsync();
            return JsonSerializer.Deserialize<List<MenuItem>>(json) ?? new List<MenuItem>();
        }
    }
}
