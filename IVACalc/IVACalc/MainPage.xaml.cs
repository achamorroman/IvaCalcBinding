using System;
using System.Globalization;
using IVACalc.Models;
using Xamarin.Forms;

namespace IVACalc
{
    public partial class MainPage : ContentPage
    {
        private VatSummary _vatSummary = new VatSummary(100, 1);

        public MainPage()
        {
            InitializeComponent();

            AmountEntry.Text = _vatSummary.Amount.ToString();
            UnitsEntry.Text = _vatSummary.Units.ToString();

            VatInfoListView.ItemsSource = _vatSummary.VatInfos;

            AmountEntry.TextChanged += (sender, args) =>
            {
                double newAmount;
                double.TryParse(AmountEntry.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out newAmount);
                _vatSummary.Amount = newAmount;
            };

            UnitsEntry.TextChanged += (sender, args) =>
            {
                if (!string.IsNullOrEmpty(UnitsEntry.Text))
                {
                    _vatSummary.Units = Convert.ToInt32(UnitsEntry.Text);
                }
            };

            _vatSummary.VatInfoChanged += (sender, args) =>
            {
                VatInfoListView.ItemsSource = null;
                VatInfoListView.ItemsSource = _vatSummary.VatInfos;
            };
        }
    }
}
