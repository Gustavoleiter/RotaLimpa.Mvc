namespace RotaLimpa.Mvc.Views.Usuarios.Gestor
{
    public class MeuCabecalho : ContentView
    {
        public MeuCabecalho()
        {
            var stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.End,
                Padding = new Thickness(0, 0, 0, 0)
            };

            var logoImage = new Image
            {
                Source = "logo.png",
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Start,
                Margin = new Thickness(15, 0, 0, 0)
            };

            var setoresButton = new Button
            {
                Text = "SETORES",
                TextColor = Color.FromRgb(0, 0, 0), // Cor preta em RGB
                BackgroundColor = Color.FromRgb(169, 169, 169), // Cinza em RGB
                Margin = new Thickness(10, 0, 10, 0),
                CornerRadius = 0
            };

            var motoristasButton = new Button
            {
                Text = "MOTORISTAS",
                TextColor = Color.FromRgb(0, 0, 0), // Cor preta em RGB
                BackgroundColor = Color.FromRgb(169, 169, 169), // Cinza em RGB
                Margin = new Thickness(0, 0, 10, 0),
                CornerRadius = 0
            };

            var veiculosButton = new Button
            {
                Text = "VEICULOS",
                TextColor = Color.FromRgb(0, 0, 0), // Cor preta em RGB
                BackgroundColor = Color.FromRgb(169, 169, 169), // Cinza em RGB
                Margin = new Thickness(0, 0, 10, 0),
                CornerRadius = 0
            };

            var dropDownPicker = new Picker
            {
                BindingContext = "CADASTROS",
                TextColor = Color.FromRgb(0, 0, 0), // Cor preta em RGB
                BackgroundColor = Color.FromRgb(169, 169, 169), // Cinza em RGB
                Margin = new Thickness(0, 0, 10, 0)
            };

            // Defina a lista de itens para o Picker
            var listaDeCadastros = new List<string>
            {
                "COLABORADOR",
                "VEICULO",
                "ROTA",
                "SETOR"
            };

            // Atribua a lista de itens como a origem dos itens do Picker
            dropDownPicker.ItemsSource = listaDeCadastros;


            dropDownPicker.SelectedIndexChanged += DropDown_SelectedIndexChanged;

            var contaButton = new Button
            {
                Text = "CONTA",
                TextColor = Color.FromRgb(0, 0, 0), // Cor preta em RGB
                BackgroundColor = Color.FromRgb(169, 169, 169), // Cinza em RGB
                Margin = new Thickness(0, 0, 10, 0),
                CornerRadius = 0
            };

            var pesquisaEntry = new Entry
            {
                Placeholder = "PESQUISAR",
                PlaceholderColor = Color.FromRgb(255, 255, 255), // Cor branca em RGB
                BackgroundColor = Color.FromRgb(169, 169, 169), // Cinza em RGB
                TextColor = Color.FromRgb(255, 255, 255), // Cor branca em RGB
                WidthRequest = 200
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
            var picker = sender as Picker; // Obtenha a instância correta do Picker

            if (picker != null)
            {
                var selectedOption = picker.SelectedItem as string;

                switch (selectedOption)
                {
                    case "COLABORADOR":
                        await Navigation.PushAsync(new CadastroColaborador()); // Substitua "Pagina1" pelo nome da sua página
                        break;
                    case "VEICULO":
                        await Navigation.PushAsync(new CadastroVeiculo()); // Substitua "Pagina2" pelo nome da sua página
                        break;
                    case "ROTA":
                        await Navigation.PushAsync(new CadastroRota()); // Substitua "Pagina3" pelo nome da sua página
                        break;
                    case "SETOR":
                        await Navigation.PushAsync(new CadastroSetor()); // Substitua "Pagina3" pelo nome da sua página
                        break;
                    // Adicione mais casos conforme necessário para outras páginas
                    default:
                        break;
                }
            }
        }

    }
}
