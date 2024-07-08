namespace _3_Quotes
{
    public partial class MainPage : ContentPage
    {
        List<string> quotes = [];

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadQuotes();
        }
        async Task LoadQuotes()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
            using var reader = new StreamReader(stream);

            while(reader.Peek() != -1)
            {
                quotes.Add(reader.ReadLine());
            }
        }

        private LinearGradientBrush generateRandomGradient()
        {
            static System.Drawing.Color generateRandomColor()
            {
                Random rand = new Random();
                var color = System.Drawing.Color.FromArgb(
                    rand.Next(0, 256),
                    rand.Next(0, 256),
                    rand.Next(0, 256));
                return color;
            }

            var startColor = generateRandomColor();
            var endColor = generateRandomColor();

            var colors =
                ColorUtility.ColorControls.GetColorGradient(startColor, endColor, 6);

            float stopOffset = .0f;
            var stops = new GradientStopCollection();
            foreach (var color in colors)
            {
                //a cor criada em cima é de um tipo diferente da cor usada para criar um gradiente
                //passa-se o hex da cor para o tipo Color para que seja usado corretamente
                stops.Add(new GradientStop(
                    Color.FromArgb(color.Name), stopOffset)
                    );
                stopOffset += .2f;
            }

            var gradient = new LinearGradientBrush(stops, new Point(0, 0), new Point(1, 1));
            return gradient;
        }
        private String getRandomQuote()
        {
            Random rand = new Random();
            int idx = rand.Next(0, quotes.Count);
            return quotes[idx];
        }

        private void BtnGenerateQuote_Clicked(object sender, EventArgs e)
        {   
            background.Background = generateRandomGradient();
            LblQuote.Text = getRandomQuote();
        }
    }

}
