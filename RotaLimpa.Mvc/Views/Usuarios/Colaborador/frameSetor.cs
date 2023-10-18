using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace RotaLimpa.Mvc.Views.Usuarios.Colaborador;

public class frameSetor : ContentView
{
    public frameSetor()
    {
        var frame = new Frame
        {
            MaximumHeightRequest = 250,
            WidthRequest = 250,
            BackgroundColor = Color.FromRgb(2, 163, 199),
            Padding = 10,
            HasShadow = false,
            CornerRadius = 5,
            Content = new StackLayout
            {
                Spacing = 10,
                Children = {
                    new Label
                    {
                        FontAttributes = FontAttributes.Bold,
                        Text = "SETOR: ",
                        FontSize = 18,
                        FontFamily = "Comfortaa",
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
                        Text = "MOTORISTAS",
                        FontSize = 16,
                        FontFamily = "Comfortaa",
                        TextColor = Color.FromRgb(0, 0, 0),
                        HorizontalOptions = LayoutOptions.Start
                    },
                    new Frame
                    {
                        CornerRadius = 5,
                        BackgroundColor = Color.FromRgb(2, 132, 199),
                        Padding = 5,
                        Content = new StackLayout
                        {
                            Spacing = 10,
                            Children =
                            {
                                new Label { Text = "MOTORISTA 1", FontSize = 12, TextColor = Color.FromRgb(0, 0, 0), FontFamily = "Comfortaa" },
                                new Label { Text = "MOTORISTA 2", FontSize = 12, TextColor = Color.FromRgb(0, 0, 0), FontFamily = "Comfortaa" },
                                new Label { Text = "MOTORISTA 3", FontSize = 12, TextColor = Color.FromRgb(0, 0, 0), FontFamily = "Comfortaa" }
                            }
                        }
                    }
                }
            }
        };

        Content = frame;
    }
}
