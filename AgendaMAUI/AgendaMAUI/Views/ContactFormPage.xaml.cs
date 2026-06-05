using AgendaMAUI.ViewModels;
using Microsoft.Maui.Controls;

namespace AgendaMAUI.Views
{
    public partial class ContactFormPage : ContentPage, IQueryAttributable
    {
        private readonly ContactFormViewModel _vm;

        public ContactFormPage(ContactFormViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            _vm = vm;
        }

        public async void ApplyQueryAttributes(System.Collections.Generic.IDictionary<string, object> query)
        {
            if (query.TryGetValue("contactId", out var idObj))
            {
                if (int.TryParse(idObj?.ToString(), out int id) && id > 0)
                {
                    await _vm.LoadContactAsync(id);
                }
            }
        }
    }
}
