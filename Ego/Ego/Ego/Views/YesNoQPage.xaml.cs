using System;
using System.Collections.Generic;
using Ego.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ego
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YesNoQPage : ContentPage
    {
        public static Player ActiveP;
        public static string ActiveQ;
        public static int AnswerCount;

        public YesNoQPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new ModsPage();

            return true;
        }
        protected override void OnAppearing()
        {
            Activeplayer.Text = MyPopupPage.ListOfPlayers[0].Nick;
            AnsweringPlayer.Text = MyPopupPage.ListOfPlayers[MyPopupPage.NumberOfActivePlayer].Nick;
            if (MyPopupPage.NumberOfActivePlayer < MyPopupPage.ListOfPlayers.Count - 1)
            {
                MyPopupPage.NumberOfActivePlayer++;
            }
            ActiveP = MyPopupPage.ListOfPlayers[0];
            QuestionLabel.Text = ActiveQ;
            RandomImage();

            base.OnAppearing();

        }
        private void RandomImage()
        {
            var images = new List<View> { yesImage, noImage };
            Stack1.Children.Clear();

            var rnd = new Random();
            var r = rnd.Next(2);

            Stack1.Children.Add(images[r]);

            Stack1.Children.Add(r == 0 ? noImage : yesImage);

        }
        private void TapGestureRecognizer_OnTappedFrame(object sender, EventArgs e)
        {
            if (Math.Abs(yesImage.Opacity - 1.0) < 0.05 || Math.Abs(noImage.Opacity - 1.0) < 0.05)
            {
                if (AnswerCount < MyPopupPage.ListOfPlayers.Count - 1)
                {
                    AnswerCount++;
                    Application.Current.MainPage = new YesNoQPage();
                }
                else
                {
                    AnswerCount = 0;
                    Application.Current.MainPage = new StatsPage();
                }
            }
            else
            {
                DisplayAlert(" ", "Zaznacz swoją odpowiedź !", "OK");
            }

        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            var image = (Image)sender;
            var x = image.ClassId;
            Gif1.IsVisible = false;
            Gif2.IsVisible = true;

            switch (x)
            {
                case "yes":
                    image.Opacity = 1.0;
                    noImage.Opacity = 0.3;
                    foreach (var v in MyPopupPage.ListOfPlayers)
                    {
                        if (v.Nick == AnsweringPlayer.Text)
                        {
                            v.Answer = "Yes";
                        }
                    }
                    break;
                case "no":
                    image.Opacity = 1.0;
                    yesImage.Opacity = 0.3;
                    foreach (var v in MyPopupPage.ListOfPlayers)
                    {
                        if (v.Nick == AnsweringPlayer.Text)
                        {
                            v.Answer = "No";
                        }
                    }
                    break;
            }
        }
    }
}