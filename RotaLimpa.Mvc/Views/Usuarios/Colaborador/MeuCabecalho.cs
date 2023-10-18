namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public class MeuCabecalho : ContentView
{
    public MeuCabecalho()
    {
        var stackLayout = new HorizontalStackLayout
        {
            Padding = new Thickness(0, 0, 0, 0),
            HeightRequest = 50
            
        };

        var logoImage = new Image
        {
            Source = "logo.png",
            HeightRequest = 48,
            Margin = new Thickness(15, 0, 0, 0)
        };

        var setoresButton = new Button
        {
            Text = "SETORES",
            FontFamily = "Comfortaa",
            TextColor = Color.FromRgb(0, 0, 0),
            BackgroundColor = Color.FromRgb(169, 169, 169),
            Margin = new Thickness(10, 0, 10, 0),
            CornerRadius = 4
        };
        setoresButton.Clicked += async (sender, e) =>
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ListaSetores());
        };


        var motoristasButton = new Button
        {
            Text = "MOTORISTAS",
            FontFamily = "Comfortaa",
            TextColor = Color.FromRgb(0, 0, 0),
            BackgroundColor = Color.FromRgb(169, 169, 169),
            Margin = new Thickness(0, 0, 10, 0),
            CornerRadius = 4
        };
        motoristasButton.Clicked += async (sender, e) =>
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ListaMotoristas());
        };

        var veiculosButton = new Button
        {
            Text = "VEICULOS",
            FontFamily = "Comfortaa",
            TextColor = Color.FromRgb(0, 0, 0),
            BackgroundColor = Color.FromRgb(169, 169, 169),
            Margin = new Thickness(0, 0, 10, 0),
            CornerRadius = 4
        };

        var dropDownPicker = new Picker
        {
            HeightRequest = 48,
            FontFamily = "Comfortaa",
            TextColor = Color.FromRgb(0, 0, 0),
            BackgroundColor = Color.FromRgb(169, 169, 169),
            Margin = new Thickness(0, 0, 10, 0)
        };

        // Lista de itens para o Picker
        var listaDeCadastros = new List<string>
        {
            "CADASTRO",
            "MOTORISTA",
            "VEICULO",
            "ROTA",
            "SETOR"
        };

        foreach (var item in listaDeCadastros)
        {
            dropDownPicker.Items.Add(item);
        }
        dropDownPicker.SelectedIndex = 0;

        dropDownPicker.SelectedIndexChanged += DropDown_SelectedIndexChanged;

        var contaButton = new Button
        {
            Text = "CONTA",
            FontFamily = "Comfortaa",
            TextColor = Color.FromRgb(0, 0, 0),
            BackgroundColor = Color.FromRgb(169, 169, 169),
            Margin = new Thickness(0, 0, 10, 0),
            CornerRadius = 4
        };

        var pesquisaEntry = new Entry
        {
            Placeholder = "PESQUISAR",
            FontFamily = "Comfortaa",
            PlaceholderColor = Color.FromRgb(0, 0, 0),
            BackgroundColor = Color.FromRgb(218, 218, 218),
            TextColor = Color.FromRgb(0, 0, 0),
            WidthRequest = 250,
            HeightRequest = 40,
            
            
        };

        stackLayout.Children.Add(logoImage);
        stackLayout.Children.Add(setoresButton);
        stackLayout.Children.Add(motoristasButton);
        stackLayout.Children.Add(veiculosButton);
        stackLayout.Children.Add(dropDownPicker);
        stackLayout.Children.Add(contaButton);
        stackLayout.Children.Add(pesquisaEntry);

        Content = stackLayout;
    }

    private async void DropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = sender as Picker;

        if (picker != null)
        {
            var selectedOption = picker.SelectedItem as string;

            switch (selectedOption)
            {
                case "MOTORISTA":
                    await Navigation.PushAsync(new CadastroColaborador());
                    break;
                case "VEICULO":
                    await Navigation.PushAsync(new CadastroVeiculo());
                    break;
                case "ROTA":
                    await Navigation.PushAsync(new CadastroRota());
                    break;
                case "SETOR":
                    await Navigation.PushAsync(new CadastroSetor());
                    break;
                default:
                    break;
            }
        }
    }
}
