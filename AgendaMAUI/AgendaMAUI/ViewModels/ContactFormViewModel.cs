using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AgendaMAUI.Services;
using AgendaMAUI.Models;
using Microsoft.Maui.Controls;

namespace AgendaMAUI.ViewModels
{
    public partial class ContactFormViewModel : ObservableObject
    {
        private readonly DatabaseService _database;

        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private string phone = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private int contactId;

        public ContactFormViewModel(DatabaseService database)
        {
            _database = database;
        }

        public async Task LoadContactAsync(int id)
        {
            if (id <= 0) return;
            var list = await _database.GetContactsAsync();
            var c = list.Find(x => x.Id == id);
            if (c != null)
            {
                ContactId = c.Id;
                Name = c.Name ?? string.Empty;
                Phone = c.Phone ?? string.Empty;
                Email = c.Email ?? string.Empty;
            }
        }

        [RelayCommand]
        public async Task Save()
        {
            var missing = new System.Collections.Generic.List<string>();
            if (string.IsNullOrWhiteSpace(Name)) missing.Add("Nombre");
            if (string.IsNullOrWhiteSpace(Phone)) missing.Add("Teléfono");
            if (string.IsNullOrWhiteSpace(Email)) missing.Add("Email");

            if (missing.Count > 0)
            {
                await Shell.Current.DisplayAlert("Error", "Los siguientes campos son obligatorios: " + string.Join(", ", missing), "OK");
                return;
            }

            var contact = new AgendaMAUI.Models.Contact
            {
                Id = ContactId,
                Name = Name,
                Phone = Phone,
                Email = Email,
                CreatedAt = DateTime.Now
            };

            await _database.SaveContactAsync(contact);
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
