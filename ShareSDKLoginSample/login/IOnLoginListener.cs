using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ShareSDKLoginSample.login
{
    public interface IOnLoginListener
    {
        bool onLogin(string platform, JavaDictionary<string, object> res);
        bool onRegister(UserInfo info);
    }
}