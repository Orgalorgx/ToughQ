using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Ego.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ego
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPopupPage
    {
        public static ObservableCollection<Player> ListOfPlayers { get; set; }
        public static int NumberOfActivePlayer = 0;
        public static string MainPlayer;

        public MyPopupPage()
        {
            InitializeComponent();

            NumberOfActivePlayer = 0;
            ListOfPlayers = new ObservableCollection<Player>(SettingNamesPage.ListOfPlayers); 
        }
        public MyPopupPage(ObservableCollection<Player> x)
        {
            InitializeComponent();
            ListOfPlayers = x;
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        protected override async void OnAppearing()
        {
            PreparingNextPage();
            Activeplayer.Text = ListOfPlayers[0].Nick;

            for (var x = 2; x >=0; x--)
            {
                await Task.Delay(1000);
                timer.Text = x.ToString();
            }
            Application.Current.MainPage = new YesNoQPage();

            base.OnAppearing();
        }

        private static void PreparingNextPage()
        {
            MainPlayer = ListOfPlayers[0].Nick;

            while (true)
            {
                var rnd = new Random();
                var r = rnd.Next(ModsPage.Lines.Count);
                ModsPage.ListofNumbers.Add(r);

                if (ModsPage.ListofNumbers.Count == ModsPage.ListofNumbers.Distinct().Count())
                {
                    YesNoQPage.ActiveQ = ModsPage.Lines[r];
                    break;
                }
                ModsPage.ListofNumbers.RemoveAt(ModsPage.ListofNumbers.Count - 1);
            }
        }
    }
}