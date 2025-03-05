using System.Reflection;
using System.Text.Json;
using Contact = SaporiDeItalia.Models.Contact;

namespace SaporiDeItalia.Services
{
    public class ContactService
    {
       
        private const string _jsonFilePath = "SaporiDeItalia.Resources.contacts.json";

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using Stream? stream = assembly.GetManifestResourceStream(_jsonFilePath);
            if (stream == null)
                return new List<Contact>();
            using StreamReader reader = new StreamReader(stream);
            string json = await reader.ReadToEndAsync();
            return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
        }

    }
}
