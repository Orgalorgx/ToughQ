using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Ego.Droid;
using Ego.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace Ego.Droid
{
   public class MyEntryRenderer : EntryRenderer
   {
        public MyEntryRenderer(Context context) : base(context)
        {
            
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Element == null) return;

            var z = (MyEntry)this.Element;

            if (e.PropertyName != MyEntry.BorderStyleProperty.PropertyName) return;

            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetCornerRadius(60f);
            gradientDrawable.SetStroke(8, z.BorderColor.ToAndroid());
            gradientDrawable.SetColor(Color.LightGray);
            gradientDrawable.SetAlpha(100);

            Control.SetBackground(gradientDrawable);
            Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null) return;

            var gradientDrawable = new GradientDrawable();
            gradientDrawable.SetCornerRadius(60f);
            gradientDrawable.SetStroke(5, Android.Graphics.Color.LightGray);
            gradientDrawable.SetColor(Android.Graphics.Color.LightGray);
            gradientDrawable.SetAlpha(100);

            Control.SetBackground(gradientDrawable);
            Control.SetPadding(50,Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
        }
    }
}