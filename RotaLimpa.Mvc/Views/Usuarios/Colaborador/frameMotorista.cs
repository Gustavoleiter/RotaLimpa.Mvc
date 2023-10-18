namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public class frameMotorista : ContentView
{
	public frameMotorista()
	{
        var frame = new Frame
        {
            MaximumHeightRequest = 190,
            WidthRequest = 250,
            BackgroundColor = Color.FromRgb(21, 173, 207),
            Padding = 10,
            HasShadow = false,
            CornerRadius = 5,
            Content = new StackLayout
            {
                Spacing = 10,
                Children = {
                        
                        
                        new Label
                        {
                            Text = "MOTORISTA",
                            FontSize = 16,
                            FontFamily = "Comfortaa",
                            TextColor = Color.FromRgb(0, 0, 0),
                            HorizontalOptions = LayoutOptions.Start
                        },
                        new Frame
                        {
                            CornerRadius = 2,
                            BackgroundColor = Color.FromRgb(2, 132, 199),
                            Padding = 5,
                            Content = new StackLayout
                            {
                                Spacing = 10,
                                Children =
                                {
                                    new Label { Text = "RG: ", FontSize = 14, TextColor = Color.FromRgb(0, 0, 0), FontFamily = "Comfortaa" },
                                    new Label { Text = "CPF: ", FontSize = 14, TextColor = Color.FromRgb(0, 0, 0), FontFamily = "Comfortaa" }
                                }
                            }
                        },
                        new BoxView
                        {
                            Color = Color.FromRgb(0, 0, 0),
                            HeightRequest = 2,
                            CornerRadius = 5,
                            WidthRequest = 230
                        },
                        new Label
                        {
                            FontAttributes = FontAttributes.Bold,
                            Text = "SETOR: ",
                            FontFamily = "Comfortaa",
                            FontSize = 16,
                            TextColor = Color.FromRgb(0, 0, 0),
                            HorizontalOptions = LayoutOptions.Start
                        },
                        new Label
                        {
                            Text = "PLACA: ",
                            FontAttributes = FontAttributes.Bold,
                            FontSize = 16,
                            FontFamily = "Comfortaa",
                            TextColor = Color.FromRgb(0, 0, 0),
                            HorizontalOptions = LayoutOptions.Start
                        }
                    }
            }
        };

        Content = frame;
    }
}