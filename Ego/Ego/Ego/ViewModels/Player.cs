using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Ego.Models;
using Ego.Views;
using Xamarin.Forms;

namespace Ego.ViewModels
{
    public class Player : INotifyPropertyChanged
    {
        private int _score;

        public string Answer { get; set; }
        public string Nick { get; set; }
        public int DifferenceScore { get; set; }
        public bool LabelVisible { get; set; }

        public string MyTextColorCommand => DifferenceScore >= 0 ? "#00FF00" : "#ff0000";
        public string StatusCommand => Score >= SettingTokensPage.MaxScoreSetting.MaxScore ? "Wygrałeś !" : "Przegrałeś !";


        // public Command ClickCommand => new Command<string>(Login_OnClick);

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        //private void Login_OnClick(string x)
        //{
        //    switch (x)
        //    {
        //        case "plus":
        //            Score = Score + 1;
        //            break;
        //        case "minus":
        //            Score = Score - 1;
        //            break;
        //    }
        //}


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
