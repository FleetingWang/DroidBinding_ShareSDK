using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CN.Sharesdk.Framework;
using ShareSDKLoginSample.login;
using static Android.Views.View;

namespace ShareSDKLoginSample
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class LoginPage : Activity, IOnClickListener
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.login_page);
            initPlatformList();
        }

        /* 获取平台列表,显示平台按钮*/
        private void initPlatformList()
        {
            ShareSDK.InitSDK(this);
            Platform[] Platformlist = ShareSDK.GetPlatformList();
            if (Platformlist != null)
            {
                LinearLayout linear = FindViewById<LinearLayout>(Resource.Id.linear);
                LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
                lp.Weight = 1;
                foreach (Platform platform in Platformlist)
                {
                    if (!Tool.canGetUserInfo(platform))
                    {
                        continue;
                    }

                    if (platform is CustomPlatform)
                    {
                        continue;
                    }

                    Button btn = new Button(this);
                    btn.SetSingleLine();
                    String name = platform.Name;
                    Console.WriteLine("名字" + name);
                    if (platform.IsAuthValid)
                    {
                        btn.Text = GetString(Resource.String.remove_to_format, name);
                    }
                    else
                    {
                        btn.Text = GetString(Resource.String.login_to_format, name);
                    }
                    btn.TextSize = 16;
                    btn.Tag = platform;
                    btn.Visibility = ViewStates.Visible;
                    btn.SetOnClickListener(this);
                    linear.AddView(btn, lp);
                }
            }
        }


        public void OnClick(View v)
        {
            Button btn = (Button)v;
            Object tag = v.Tag;
            if (tag != null)
            {
                Platform platform = (Platform)tag;
                String name = platform.Name;
                Console.WriteLine($"名字{name} {GetString(Resource.String.login_to_format, name)}");
                if (!platform.IsAuthValid)
                {
                    btn.Text = GetString(Resource.String.remove_to_format, name);
                }
                else
                {
                    btn.Text = GetString(Resource.String.login_to_format, name);
                    String msg = GetString(Resource.String.remove_to_format_success, name);
                    Toast.MakeText(this, msg, ToastLength.Short).Show();
                }
                //登陆逻辑的调用
                login(name);
            }
        }

        /*
	     * 演示执行第三方登录/注册的方法
	     * <p>
	     * 这不是一个完整的示例代码，需要根据您项目的业务需求，改写登录/注册回调函数
	     *
	     * @param platformName 执行登录/注册的平台名称，如：SinaWeibo.NAME
	     */
        private void login(string platformName)
        {
            LoginApi api = new LoginApi();
            // 初始化SDK
            ShareSDK.InitSDK(ApplicationContext);
            Platform plat = ShareSDK.GetPlatform(platformName);
            if (plat == null) return;

            if (plat.IsAuthValid)
            {
                plat.RemoveAccount(true);
                return;
            }

            //使用SSO授权，通过客户单授权
            plat.SSOSetting(false);

            plat.Complete += (sender, e) => {
                // 填写处理注册信息的代码，返回true表示数据合法，注册页面可以关闭
                Toast.MakeText(this, "登录成功。", ToastLength.Short).Show();
            };

            plat.Error += (sender, e) => {

            };

            plat.Cancel += (sender, e) => {

            };

            plat.ShowUser(null);
        }
    }
}

