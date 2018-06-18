using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Ego.ViewModels;
using Ego.Views;
using Xamarin.Forms;

namespace Ego.Converters
{
    internal class AddTextConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var score = int.Parse(value.ToString());
            return score == 0|| score == SettingTokensPage.MaxScoreSetting.MaxScore ? "Auto" : "0.00001";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
