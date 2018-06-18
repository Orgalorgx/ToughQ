using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Ego.Views;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace Ego
{
    public partial class ModsPage : ContentPage
    {
        public static List<string> Lines;
        public static List<int> ListofNumbers = new List<int>();

        public ModsPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new SettingNamesPage();

            return true;
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            await Task.Delay(300);

            var image = (CachedImage)sender;

            var assembly = typeof(SettingNamesPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(image.ClassId);
            if (stream == null)
            {
               await DisplayAlert(" ", "Nie wczytano pytań!", "Ok");
                return;
            }
            Lines = new List<string>();
            using (var sr = new StreamReader(stream))
            {
                while (sr.Peek() >= 0)
                    Lines.Add(sr.ReadLine());
            }

            if (SettingNamesPage.ListOfPlayers != null)
            {
                foreach (var z in SettingNamesPage.ListOfPlayers)
                {
                    z.Score = SettingTokensPage.MaxScoreSetting.StartingScore;
                    z.DifferenceScore = 0;
                }
                YesNoQPage.AnswerCount = 0;
            }
            Application.Current.MainPage = new MyPopupPage();
        }
    }
}
