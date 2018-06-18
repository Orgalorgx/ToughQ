using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.OS;
using FFImageLoading.Forms.Droid;

namespace Ego.Droid
{
    [Activity(Label = "ToughQ",
        Icon = "@drawable/icon",
        Theme = "@style/splashscreen",
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        LaunchMode = LaunchMode.SingleTop)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
           // TabLayoutResource = Resource.Layout.Tabbar;
          //  ToolbarResource = Resource.Layout.Toolbar;
            base.Window.RequestFeature(WindowFeatures.ActionBar);
            SetTheme(Resource.Style.MainTheme);
            base.OnCreate(bundle);
            CachedImageRenderer.Init(false);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
    
}

