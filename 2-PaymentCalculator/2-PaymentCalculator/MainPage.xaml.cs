namespace _2_PaymentCalculator
{
    public partial class MainPage : ContentPage
    {
        decimal bill = 0;
        int tip = 0;
        int numPersons = 1;


        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateTotal()
        {
            var totalTip = (bill * tip) / 100;

            var tipByPerson = (totalTip / numPersons);
            LblTipPerPerson.Text = $"{tipByPerson:C}";

            var subtotal = (bill / numPersons);
            LblSubtotal.Text = $"{subtotal:C}";

            var totalByPerson = (bill + totalTip)/numPersons;
            LblTotal.Text = $"{totalByPerson:C}";

        }
        private void TxtBill_Completed(object sender, EventArgs e)
        {
            bill = decimal.Parse(TxtBill.Text);
            CalculateTotal();
        }

        private void SldTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)SldTip.Value;
            LblTip.Text = $"Tip: {tip}%";
            CalculateTotal();
        }

        private void PercentButton_Clicked(object sender, EventArgs e)
        {
            if(sender is not Button) { return; }

            var btn = (Button)sender;
            var percent = int.Parse(btn.Text.Replace("%", ""));
            SldTip.Value = percent;
        }

        private void BtnMinus_Clicked(object sender, EventArgs e)
        {
            if(sender is not Button) { return; }

            var lclTotalPersons = int.Parse(LblNumPersons.Text);
            if(lclTotalPersons <= 1) { return; }
            
            numPersons--;
            LblNumPersons.Text = numPersons.ToString();
            CalculateTotal();
            
        }

        private void BtnPlus_Clicked(object sender, EventArgs e)
        {
            if (sender is not Button) { return; }

            numPersons++;
            LblNumPersons.Text = numPersons.ToString();
            CalculateTotal();

        }
    }

}
