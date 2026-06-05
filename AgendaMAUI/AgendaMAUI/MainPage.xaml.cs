using AgendaMAUI.ViewModels;
using Microsoft.Maui.Controls;

namespace AgendaMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(ContactsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is AgendaMAUI.ViewModels.ContactsViewModel vm)
            {
                await vm.RefreshAsync();
            }
        }

        private async void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            if (BindingContext is AgendaMAUI.ViewModels.ContactsViewModel vm)
            {
                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                {
                    await vm.RefreshAsync();
                }
            }
        }
    }
}
