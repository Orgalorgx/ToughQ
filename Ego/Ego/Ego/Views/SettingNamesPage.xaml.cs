using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Ego.ViewModels;
using Ego.Views;
using FFImageLoading.Forms;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ego
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingNamesPage : ContentPage
    {
        public int NumberOfPlayers = 1;
        public static ObservableCollection<Player> ListOfPlayers { get; set; }


        public SettingNamesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            ListOfPlayers = new ObservableCollection<Player>();

            NumberOfPlayers = 1;

            var ent = new MyEntry { Placeholder = "Player" + NumberOfPlayers, PlaceholderColor = Color.LightCyan, TextColor = Color.LightCyan };
            NumberOfPlayers++;
            var ent1 = new MyEntry { Placeholder = "Player" + NumberOfPlayers, PlaceholderColor = Color.LightCyan, TextColor = Color.LightCyan };

            ent.TextChanged += Ent_TextChanged;
            ent1.TextChanged += Ent_TextChanged;

            StkContent.Children.Add(ent);
            StkContent.Children.Add(ent1);
        }
        
        private async void Clicked(object o, EventArgs eventArgs)
        {
            await Task.Delay(300);
            foreach (var v in StkContent.Children)
            {
                var entry = (MyEntry)v;
                if (entry.Text == "")
                {
                    entry.Text = entry.Placeholder;
                }
                ListOfPlayers.Add(new Player
                {
                    LabelVisible = false,
                    Answer = null,
                    Nick = entry.Text ?? entry.Placeholder,
                    DifferenceScore = 0,
                });
            }
            Application.Current.MainPage = new SettingTokensPage();
        }
        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            await Task.Delay(300);

            var imageSender = (CachedImage)sender;
            if (imageSender.ClassId == "plus")
            {
                NumberOfPlayers++;

                var ent = new MyEntry { Placeholder = "Player" + NumberOfPlayers, TextColor = Color.LightCyan, PlaceholderColor = Color.LightCyan };
                ent.TextChanged += Ent_TextChanged;
                StkContent.Children.Add(ent);
            }
            else
            {
                if (NumberOfPlayers <= 2) return;
                StkContent.Children.RemoveAt(NumberOfPlayers - 1);
                NumberOfPlayers--;
            }
        }
        private static void Ent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var ent = (MyEntry)sender;
            if (ent.Text.Length > 10)
            {
                ent.Text = e.OldTextValue;
                ent.TextColor = Color.Red;
                ent.BorderColor = Color.Red;
            }
            else if (ent.Text.Length < 10)  
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