using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SaporiDeItalia.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Contact = SaporiDeItalia.Models.Contact;

namespace SaporiDeItalia.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        private readonly ContactService _contactService;

        [ObservableProperty]
        private ObservableCollection<Contact> contacts = new();

        public ContactViewModel(ContactService contactService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            LoadContactsCommand = new AsyncRelayCommand(LoadContactsAsync);
        }

        public ICommand LoadContactsCommand { get; }

       
        private async Task LoadContactsAsync()
        {
            try
            {
                var contacts = await _contactService.GetContactsAsync();
                if (contacts != null && contacts.Any())
                {
                    Contacts = new ObservableCollection<Contact>(contacts);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading contacts: {ex.Message}");
            }
           
        }
    }
}
