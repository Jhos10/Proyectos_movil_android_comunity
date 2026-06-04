using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClimaAppMAUI
{
    // Implementamos INotifyPropertyChanged para que la UI sepa cuándo actualizarse
    public class WeatherData : INotifyPropertyChanged
    {
        private double temperature;
        private int humidity;
        private string condition;

        public double Temperature
        {
            get => temperature;
            set
            {
                temperature = value;
                OnPropertyChanged(); // Notifica el cambio
            }
        }

        public int Humidity
        {
            get => humidity;
            set
            {
                humidity = value;
                OnPropertyChanged(); // Notifica el cambio
            }
        }

        public string Condition
        {
            get => condition;
            set
            {
                condition = value;
                OnPropertyChanged(); // Notifica el cambio
            }
        }

        // Evento requerido por la interfaz INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
