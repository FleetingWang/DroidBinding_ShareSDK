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
using static Android.OS.Handler;
using CN.Sharesdk.Framework;
using Java.Lang;

namespace ShareSDKLoginSample.login
{
    public class LoginApi
    {
        private static int MSG_AUTH_CANCEL = 1;
        private static int MSG_AUTH_ERROR = 2;
        private static int MSG_AUTH_COMPLETE = 3;

        private Context context;

        private string CurrentPlatform { get; set; }
        private IOnLoginListener loginListener { get; set; }

        public void Login(Context context)
        {
            this.context = context.ApplicationContext;
            if (string.IsNullOrEmpty(CurrentPlatform)) return;

            // 初始化SDK
            ShareSDK.InitSDK(this.context);
            Platform plat = ShareSDK.GetPlatform(CurrentPlatform);
            if (plat == null) return;

            if (plat.IsAuthValid)
            {
                plat.RemoveAccount(true);
                return;
            }

            //使用SSO授权，通过客户单授权
            plat.SSOSetting(false);

            plat.Complete += (sender, e) => {
                var platName = e.P0.Name;

            };

            plat.Error += (sender, e) => {

            };

            plat.Cancel += (sender, e) => {

            };

            plat.ShowUser(null);
        }
    }
}