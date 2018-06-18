using System;
using System.Linq;
using System.Threading.Tasks;
using Ego.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ego
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StatsPage : ContentPage
	{

        public StatsPage()
		{
			InitializeComponent ();
        }
        protected override bool OnBackButtonPressed()
        {
            MyPopupPage.ListOfPlayers.Move(0, MyPopupPage.ListOfPlayers.Count - 1);
            YesNoQPage.AnswerCount = 0;
            MyPopupPage.NumberOfActivePlayer = 0;

            Application.Current.MainPage = new MyPopupPage(MyPopupPage.ListOfPlayers);

            return true;
        }

        protected override void OnAppearing()
        {
	        foreach (var x in MyPopupPage.ListOfPlayers)
	        {
	            if (x.Nick != YesNoQPage.ActiveP.Nick)
	            {
	                if (x.Answer == YesNoQPage.ActiveP.Answer)
	                {
	                    x.DifferenceScore = 1;
	                    x.Score = x.Score + x.DifferenceScore;
	                }
	                else
	                {
	                    x.DifferenceScore = -1;
	                    x.Score = x.Score + x.DifferenceScore;
	                }
	            }
	            else
	            {
	                x.DifferenceScore = 0;
	            }
	        }
            ScoreTable.ItemsSource = MyPopupPage.ListOfPlayers;

            base.OnAppearing();
	    }

	    private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
	    {
	        await Task.Delay(300);

            MyPopupPage.ListOfPlayers.Move(0, MyPopupPage.ListOfPlayers.Count - 1);
	        YesNoQPage.AnswerCount = 0;
	        MyPopupPage.NumberOfActivePlayer = 0;
	        var winner = false;
	        foreach (var x in MyPopupPage.ListOfPlayers)
	        {
	            if (x.Score == 0 || x.Score == SettingTokensPage.MaxScoreSetting.MaxScore)
	            {
	                winner = true;
	            }
	        }
	        if (ModsPage.ListofNumbers.Distinct().Count() == ModsPage.Lines.Count || winner) 
	        { 
	            Application.Current.MainPage = new ModsPage();
	        }
	        else
	        {
	            Application.Current.MainPage = new MyPopupPage(MyPopupPage.ListOfPlayers);
            }
	        
        }
	    private void ScoreTable_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        {
	            if (e == null) return;
                ((ListView)sender).SelectedItem = null; // de-select the row      
            }
        }

	    private async void PopupPage_OnClicked(object sender, EventArgs e)
	    {
	        await Task.Delay(300);

	        await PopupNavigation.PushAsync(new FirstPopupPage());
        }
	}
}