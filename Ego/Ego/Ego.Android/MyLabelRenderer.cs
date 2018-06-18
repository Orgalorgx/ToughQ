using Android.Content;
using Android.Graphics;
using Ego.Droid;
using Ego.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyLabel), typeof(MyLabelRenderer))]
namespace Ego.Droid
{
    public class MyLabelRenderer : LabelRenderer
    {
        public MyLabelRenderer(Context context) : base(context)
        {

        }
        
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            Control.Typeface = Typeface.CreateFromAsset(Context.Assets, "Mawns_Handwriting.ttf");
        }
    }
}
   

