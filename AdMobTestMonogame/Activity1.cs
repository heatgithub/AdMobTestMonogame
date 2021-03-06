using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Microsoft.Xna.Framework;

namespace AdMobTestMonogame
{
    [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        Icon = "@drawable/icon",
        AlwaysRetainTaskState = true,
        LaunchMode = LaunchMode.SingleInstance,
        ScreenOrientation = ScreenOrientation.FullUser,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize
    )]
    public class Activity1 : AndroidGameActivity
    {
        private Game1 _game;
        private View _view;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _game = new Game1();
            _view = _game.Services.GetService(typeof(View)) as View;
            SetContentView(_view);

            //***** add ad ********************************************************************************************

            MonoGameAdMob.IAdManager ads = new MonoGameAdMob.AdMobAdapter(this, "ca-app-pub-3940256099942544/6300978111");
            ads.ShowBannerAd(MonoGameAdMob.BannerPosition.BottomBanner, 46);

            //*********************************************************************************************************

            _game.Run();
        }
    }
}
