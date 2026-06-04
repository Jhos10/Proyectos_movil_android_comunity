namespace MiniCalculadora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalcularClicked(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar que las entradas de texto no estén vacías
                if (string.IsNullOrWhiteSpace(numero1Entry.Text) ||
                    string.IsNullOrWhiteSpace(numero2Entry.Text))
                {
                    resultadoLabel.Text = "Ingrese ambos números";
                    resultadoLabel.TextColor = Colors.Red;
                    return; // Detenemos la ejecución aquí
                }

                // 2. Validar que se haya seleccionado una opción en el Picker (-1 es vacío)
                if (operacionPicker.SelectedIndex == -1)
                {
                    resultadoLabel.Text = "Seleccione una operación";
                    resultadoLabel.TextColor = Colors.Red;
                    return;
                }

                // Convertir textos a valores numéricos (double)
                double num1 = double.Parse(numero1Entry.Text);
                double num2 = double.Parse(numero2Entry.Text);
                double resultado = 0;

                // 3. Ejecutar la matemática según el índice del Picker
                switch (operacionPicker.SelectedIndex)
                {
                    case 0: resultado = num1 + num2; break;
                    case 1: resultado = num1 - num2; break;
                    case 2: resultado = num1 * num2; break;
                    case 3:
                        // Validación especial: Evitar división entre cero
                        if (num2 == 0)
                        {
                            resultadoLabel.Text = "División entre cero";
                            resultadoLabel.TextColor = Colors.Red;
                            return;
                        }
                        resultado = num1 / num2;
                        break;
                }

                // Si todo sale bien, mostramos el resultado formateado a 2 decimales (F2)
                resultadoLabel.Text = $"= {resultado:F2}";
                resultadoLabel.TextColor = Colors.Green;
            }
            catch (Exception ex)
            {
                // Capturamos cualquier otro error inesperado (ej. letras en el campo) para evitar que la app crashee
                resultadoLabel.Text = $"Error: {ex.Message}";
                resultadoLabel.TextColor = Colors.Red;
            }
        }
    }
}
