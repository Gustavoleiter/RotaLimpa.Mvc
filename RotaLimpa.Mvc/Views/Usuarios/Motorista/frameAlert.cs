using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace RotaLimpa.Mvc.Views.Usuarios.Motorista
{
    public class frameAlert : ContentView
    {
        public frameAlert()
        {
            var flexLayout = new FlexLayout
            {
                Direction = FlexDirection.Row,
                Wrap = FlexWrap.Wrap,
                JustifyContent = FlexJustify.Start,
                AlignContent = FlexAlignContent.Start,
                BackgroundColor = Color.FromHex("#16A34A"),
                Padding = new Thickness(5, 40, 5, 0),
                HeightRequest = 675,
                WidthRequest = 370,
            };

            var imagePaths = new List<string>
            {
                "semlixo.png", 
                "acidente.png",
                "interditado.png",
                "transito.png",
                "alagamento.png",
                // Adicione os caminhos das imagens adicionais aqui
            };

            var texts = new List<string>
            {
                "SEM LIXO",
                "ACIDENTE",
                "INTERDITADO",
                "TRÂNSITO",
                "ALAGAMENTO"
                // Adicione os textos correspondentes aqui
            };

            for (int i = 0; i < Math.Min(imagePaths.Count, texts.Count); i++)
            {
                var image = new ImageButton
                {
                    HeightRequest = 50,
                    WidthRequest = 50,
                    Margin = new Thickness(0, 10, 0, 0),
                    Aspect = Aspect.AspectFit,
                    Source = imagePaths[i],
                };

                var label = new Label
                {
                    Text = texts[i],
                    FontSize = 16,
                    TextColor = Color.FromHex("#FFFFFF"),
                    HorizontalOptions = LayoutOptions.Center,
                };

                var frame = new Frame
                {
                    Margin = new Thickness(0, 10, 0, 0),
                    Padding = 0,
                    HeightRequest = 100,
                    WidthRequest = 120,
                    BackgroundColor = new Color(0, 0, 0, 0),
                    CornerRadius = 0,
                    Content = new StackLayout
                    {
                        Spacing = 0,
                        Children =
                        {
                            image,
                            label
                        }
                    }
                };

                flexLayout.Children.Add(frame);
            }
            Content = flexLayout;
        }
    }
}
