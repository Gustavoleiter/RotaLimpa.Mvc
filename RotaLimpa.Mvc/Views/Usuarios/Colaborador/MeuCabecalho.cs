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
            Margin = new Thickness(15, 0, 0, 0),
            MaximumHeightRequest = 48,
            VerticalOptions = LayoutOptions.Start,
        };

        var setoresButton = new Button
        {
            Text = "SETORES",
            FontFamily = "Comfortaa",
            TextColor = Color.FromRgb(0, 0, 0),
            BackgroundColor = Color.FromRgb(169, 169, 169),
            Margin = new Thickness(150, 0, 10, 0),
            CornerRadius = 4,
            HeightRequest = 48,
            VerticalOptions = LayoutOptions.Start,
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
            CornerRadius = 4,
            HeightRequest = 48,
            VerticalOptions = LayoutOptions.Start,
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
            CornerRadius = 4,
            HeightRequest = 48,
            VerticalOptions = LayoutOptions.Start,
        };
        veiculosButton.Clicked += async (sender, e) =>
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ListaFrota());
        };

        var dropDownPicker = new Picker
        {
            HeightRequest = 48,
            FontFamily = "Comfortaa",
            TextColor = Color.FromRgb(0, 0, 0),
            BackgroundColor = Color.FromRgb(169, 169, 169),
            Margin = new Thickness(0, 0, 10, 0),
            VerticalOptions = LayoutOptions.Start,
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
            CornerRadius = 4,
            HeightRequest = 48,
            VerticalOptions = LayoutOptions.Start,
        };
        contaButton.Clicked += async (sender, e) =>
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Conta());
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
            VerticalOptions = LayoutOptions.Start,

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
                    await Navigation.PushAsync(new CadastroMotorista());
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
