using ListaTareaMAUI.ViewModels;

namespace ListaTareaMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Inyectamos el ViewModel y nada más. ¡Adiós código del contador viejo!
            BindingContext = new MainViewModel();
        }
    }
}
