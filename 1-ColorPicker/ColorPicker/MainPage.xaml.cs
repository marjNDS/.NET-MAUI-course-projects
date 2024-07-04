using System.Diagnostics;
using Microsoft.Maui.ApplicationModel;
using CommunityToolkit.Maui.Alerts;   

namespace ColorPicker
{
    public partial class MainPage : ContentPage
    {
        bool isRandom = false;

        public MainPage()
        {
            InitializeComponent();

        }

        private void SldColor_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (isRandom)
                { return; }
            if(SldBlue == null || SldGreen == null || SldRed == null)
                { return; }

            var red = SldRed.Value;
            var green = SldGreen.Value;
            var blue = SldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);

        }

        private void SetColor(Color color)
        {
            ColorFrame.BackgroundColor = color;
            ColorPickerContainer.BackgroundColor = color;
            lblHex.Text = color.ToHex();

        }

        private void BtnRandomizer_Pressed(object sender, EventArgs e)
        {
            isRandom = true;
            var Random = new Random();
            var color = Color.FromRgb(
                                    Random.Next(0, 256),
                                    Random.Next(0, 256),
                                    Random.Next(0, 256));
            SetColor(color);

            SldRed.Value = color.Red;
            SldGreen.Value = color.Green;
            SldBlue.Value = color.Blue;
            isRandom = false;
        }

        private async void CopyBtn_Clicked(object sender, EventArgs e)
        {
            var copy = lblHex.Text;
            await Clipboard.SetTextAsync(copy);
            var t = Toast.Make("Copied");
            await t.Show();
        }
    }

}
