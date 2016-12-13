
using Android.App;
using CN.Sharesdk.Wechat.Utils;

namespace UniHanApps.Droid.wxapi
{
    [Activity(
        Name = "unihanapps.droid.wxapi.WXEntryActivity",
        Theme = "@android:style/Theme.Translucent.NoTitleBar",
        ConfigurationChanges = Android.Content.PM.ConfigChanges.KeyboardHidden| Android.Content.PM.ConfigChanges.Orientation| Android.Content.PM.ConfigChanges.ScreenSize,
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        Exported = true)]
    public class WXEntryActivity : WechatHandlerActivity
    {
    }
}