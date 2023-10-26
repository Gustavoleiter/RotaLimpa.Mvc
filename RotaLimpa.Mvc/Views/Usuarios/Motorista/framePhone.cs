using System;
using Microsoft.Maui.Controls;

namespace RotaLimpa.Mvc.Views.Usuarios.Motorista
{
    public class framePhone : ContentView
    {
        public framePhone()
        {
            var frame = new Frame
            {
                BackgroundColor = Color.FromHex("#16A34A"),
                Padding = new Thickness(5, 40, 5, 0),
                CornerRadius = 0,
                HeightRequest = 675,
                WidthRequest = 370,
                Content = new StackLayout
                {
                    Spacing = 10,
                    Children =
                    {
                        CreateButton("GUINCHO", "00 0000 0001"),
                        CreateButton("SEGURO", "00 0000 0002"),
                        CreateButton("POLÍCIA MILITAR", "190"),
                        CreateButton("SAMU", "192"),
                        CreateButton("BOMBEIROS", "193"),
                        CreateButton("GESTÃO", "00 0000 0006"),
                    }
                }
            };

            Content = frame;
        }

        private Button CreateButton(string label, string phoneNumber)
        {
            var button = new Button
            {
                Text = label,
                BackgroundColor = Color.FromHex("#02C8C7"),
                TextColor = Color.FromHex("#FFFFFF"),
                FontSize = 18,
                FontFamily = "Comfortaa",
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(0, 0, 0, 10),
                WidthRequest = 340,
                HeightRequest = 50
            };

            button.Clicked += (sender, e) =>
            {
                var phoneNumberWithUri = $"tel:{phoneNumber}";
                Launcher.OpenAsync(new Uri(phoneNumberWithUri));
            };

            return button;
        }
    }
}
