using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Ego.ViewModels
{
    public class MyEntry : Entry
    {
        public static readonly BindableProperty BorderStyleProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(MyEntry), Color.Transparent);

        public Color BorderColor
        {
            get => (Color) GetValue(BorderStyleProperty);
            set => SetValue(BorderStyleProperty, value);
        }
    };
}
