namespace Mi_primera_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSaludarClicked(object sender, EventArgs e)
        {
            // Validación: Comprobamos que el usuario no haya ingresado un texto vacío o solo espacios
            if (!string.IsNullOrWhiteSpace(nombreEntry.Text))
            {
                mensajeLabel.Text = $"¡Hola, {nombreEntry.Text}!";
                mensajeLabel.TextColor = Colors.DarkGreen;
            }
            else
            {
                // Manejo de error si la entrada está vacía
                mensajeLabel.Text = "Por favor ingresa tu nombre";
                mensajeLabel.TextColor = Colors.Red;
            }
        }
    }
}
