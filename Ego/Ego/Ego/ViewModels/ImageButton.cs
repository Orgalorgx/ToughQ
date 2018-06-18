using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace Ego.ViewModels
{
    public class ImageButton : CachedImage
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create<ImageButton, ICommand>(p => p.Command, null);
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        private ICommand TransitionCommand
        {
            get
            {
                return new Command(async () =>
                {                   
                    await this.ScaleTo(0.6, 50, Easing.Linear);
                    await this.ScaleTo(1, 50, Easing.Linear);
                    
                });
            }
        }

        public ImageButton()
        {
            Initialize();
        }
        public void Initialize()
        {
            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = TransitionCommand
            });
        }
    }
}
