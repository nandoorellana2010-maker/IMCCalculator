namespace IMCCalculator.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


    public partial class IMCCalculatorViewModel : ObservableObject
    {
        [ObservableProperty]
        private double peso;

        [ObservableProperty]
        private double altura;

        [ObservableProperty]
        private double imc;

        [ObservableProperty]
        private string? clasificacion;

        [RelayCommand]
        private async Task Calcular()
        {
            try{

            if (Altura <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Error", "La altura debe ser mayor que cero.", "OK");
            }else if (Peso <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Error", "El peso debe ser mayor que cero.", "OK");
            }
            else
            {
                Imc = Peso / (Altura * Altura);
                Clasificacion = Clasificar(Imc);
                await App.Current.MainPage.DisplayAlert("Resultado", $"Tu IMC es {Imc:F2} y tu clasificación es: {Clasificacion}.", "OK");
            }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }

        [RelayCommand]
        private void Limpiar()
        {
            Peso = 0;
            Altura = 0;
            Imc = 0;
            Clasificacion = string.Empty;
        }

        private static string Clasificar(double imc)
        {
            return imc switch
            {
                <= 0 => string.Empty,
                < 18.5 => "Bajo peso",
                < 25 => "Normal",
                < 30 => "Sobrepeso",
                _ => "Obesidad",
            };
        }
    }