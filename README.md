# MonoGameAdMob

Sample of adding an AdMob banner to an Android MonoGame game.

## How to use it

### 1 - NuGet packages

The code in *MonoGameAdMob.cs* needs *Xamarin.GooglePlayServices.Ads.Lite* to be installed from NuGet.

Is the Target SDK set to 31 [Android S 12] or newer, *Xamarin.AndroidX.Work.Runtime* version 2.7.0 or newer 
alsa has to be installed from NuGet, otherwise there will be errors about FLAG_IMMUTABLE.

### 2 - MonoGameAdMob.cs

Add this code as it is to the project.

### 3 - AndroidManifest.xml

Add the following lines to the `<application>` section in the *AndroidManifest.xml* file. Change the Application ID 
to the correct Application ID.

```
<meta-data android:name="com.google.android.gms.ads.APPLICATION_ID" 
           android:value="ca-app-pub-3940256099942544~3347511713" />
<activity android:name="com.google.android.gms.ads.AdActivity" 
          android:configChanges="keyboard|keyboardHidden|orientation|screenLayout|uiMode|screenSize|smallestScreenSize" 
          android:theme="@android:style/Theme.Translucent" />
```

Add the following permissions.

```
<uses-permission android:name="android.permission.INTERNET" />
<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
```

### 4 - Game1.cs

To use a banner at the top of the screen, the game has to be in full screen mode, otherwise the banner will be covered
from the icons bar at the top of the screen and that's not allowed.

Add this line in `Game1()` for full screen mode.

```
_graphics.IsFullScreen = true;
```

### 5 - To show the banner

These to lines will show the banner. Change the Advertisement ID to the correct Advertisement ID. 

```
MonoGameAdMob.IAdManager ads = new MonoGameAdMob.AdMobAdapter(this, "ca-app-pub-3940256099942544/6300978111");
ads.ShowBannerAd(MonoGameAdMob.BannerPosition.TopBanner);
```

Change parameter in second line to `MonoGameAdMob.BannerPosition.BottomBanner` to position the banner at the bottom of the screen.

If some margin is wanted, under a bottom banner or above a top banner, add the margin to the `ShowBannerAd()` function.

```
ads.ShowBannerAd(MonoGameAdMob.BannerPosition.BottomBanner, 46);
```

### 6 - Hide the banner

To hide the banner, use this line.

```
ads.HideBannerAd();
```

### 7 - Calculate banner height

The banner is not allowed to cover any part of the game. The following line will calculate the height of the banner
so start position of game content can be calculated.

```
int height = ads.BannerHeight();
```
