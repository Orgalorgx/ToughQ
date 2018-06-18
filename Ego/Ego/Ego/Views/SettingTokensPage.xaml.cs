using System;
using System.Threading.Tasks;
using Ego.Models;
using Ego.ViewModels;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ego.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingTokensPage : ContentPage
    {
        public static SettingsModel MaxScoreSetting { get; set; }
        public static SettingsModel StartingScoreSetting { get; set; }


        public SettingTokensPage()
        {
            MaxScoreSetting = new SettingsModel();
            StartingScoreSetting = new SettingsModel();

            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new SettingNamesPage();
            return true;
        }
        private async void Clicked(object sender, EventArgs e)
        {
            await Task.Delay(300);

            var entry = TokenEntry;
            var startentry = StartTokenEntry;
            if (string.IsNullOrEmpty(entry.Text)|| string.IsNullOrEmpty(startentry.Text))
            {
                await DisplayAlert(" ", "Uzupełnij wszystkie pola !", "OK");
                return;
            }

            if (int.Parse(entry.Text) <= int.Parse(startentry.Text))
            {
                await DisplayAlert(" ", "Ilość punktów kończących grę musi być większa od ilości punktów startowych !", "OK");
                return;
            }
            MaxScoreSetting = new SettingsModel
            {
                MaxScore = int.Parse(entry.Text ?? entry.Placeholder),
                StartingScore = int.Parse(startentry.Text ?? startentry.Placeholder),
            };
           
            foreach (var v in SettingNamesPage.ListOfPlayers)
            {
                v.Score = MaxScoreSetting.StartingScore;
            }
            Application.Current.MainPage = new ModsPage();

        }
        private void Ent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var ent = (MyEntry)sender;

            var isNumeric = int.TryParse(ent.Text, out var _);

            if (string.IsNullOrEmpty(ent.Text)) return;

            if (ent.Text.Length > 3)
            {
                ent.Text = e.OldTextValue;
                ent.TextColor = Color.Red;
                ent.BorderColor = Color.Red;
            }
            else if (!isNumeric)
            {
                ent.Text = e.OldTextValue;
            }
            else if (ent.Text.Length < 3)
            {
                ent.BorderColor = Color.LightGray;
                ent.TextColor = Color.LightGray;
            }
        }

        private async void PopupPage_OnClicked(object sender, EventArgs e)
        {
            await Task.Delay(300);

            await PopupNavigation.PushAsync(new FirstPopupPage());
        }
    }
}