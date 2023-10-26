using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace RotaLimpa.Mvc.Views.Usuarios.Motorista;

public class frameSetorM : ContentView
{
    public frameSetorM()
    {
        var frame = new Frame
        {
            HeightRequest = 300,
            WidthRequest = 350,
            BackgroundColor = Color.FromRgb(161, 219, 182),
            Padding = 10,
            HasShadow = false,
            CornerRadius = 2,
            Margin = new Thickness(0, 15, 0, 0),
            Content = new StackLayout
            {
                Spacing = 10,
                Children = {
                    new Label
                    {
                        FontAttributes = FontAttributes.Bold,
                        Text = "SETOR: ",
                        FontSize = 20,
                        FontFamily = "Comfortaa",
                        TextColor = Color.FromRgb(0, 0, 0),
                        HorizontalOptions = LayoutOptions.Start
                    },
                    new Label
                    {
                        Text = "PLACA: ",
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 20,
                        FontFamily = "Comfortaa",
                        TextColor = Color.FromRgb(0, 0, 0),
                        HorizontalOptions = LayoutOptions.Start
                    },
                    new BoxView
                    {
                        Color = Color.FromRgb(0, 0, 0),
                        HeightRequest = 2,
                        CornerRadius = 5,
                        WidthRequest = 400
                    },
                    new Label
                    {
                        Text = "MOTORISTAS",
                        FontSize = 20,
                        FontFamily = "Comfortaa",
                        TextColor = Color.FromRgb(0, 0, 0),
                        HorizontalOptions = LayoutOptions.Start,
                        Margin = new Thickness(0, 15, 0, 0)
                    },
                    new Frame
                    {
                        HeightRequest = 130,
                        CornerRadius = 2,
                        BackgroundColor = Color.FromRgb(22, 163, 74),
                        Padding = 5,
                        Content = new VerticalStackLayout
                        {
                            VerticalOptions = LayoutOptions.Center,
                            Spacing = 20,
                            Children =
                            {
                                new Label { Text = "MOTORISTA 1", FontSize = 16, TextColor = Color.FromRgb(0, 0, 0), FontFamily = "Comfortaa" },
                                new Label { Text = "MOTORISTA 2", FontSize = 16, TextColor = Color.FromRgb(0, 0, 0), FontFamily = "Comfortaa" },
                                new Label { Text = "MOTORISTA 3", FontSize = 16, TextColor = Color.FromRgb(0, 0, 0), FontFamily = "Comfortaa" }
                            }
                        }
                    }
                }
            }
        };

        Content = frame;
    }
}