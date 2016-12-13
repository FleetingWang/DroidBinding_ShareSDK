using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CN.Sharesdk.Onekeyshare;
using Android.Graphics;
using static Android.Views.View;
using CN.Sharesdk.Framework;

namespace OneKeyShareSample
{
    [Activity(MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : Activity, IOnClickListener
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            FindViewById(Resource.Id.button1).SetOnClickListener(this);
            FindViewById(Resource.Id.button2).SetOnClickListener(this);
            FindViewById(Resource.Id.button3).SetOnClickListener(this);
            FindViewById(Resource.Id.button4).SetOnClickListener(this);

            // 初始化ShareSDK
            ShareSDK.InitSDK(this);
        }
        
        public void OnClick(View v)
        {
            switch (v.Id)
            {
                case Resource.Id.button1:
                    ShowShare(this, null, true);
                    break;
                case Resource.Id.button2:
                    ShowShare(this, null, false);
                    break;
                case Resource.Id.button3:
                    StartActivity(new Intent(this, typeof(DerectShareWithEditActivity)));
                    break;
                case Resource.Id.button4:
                    StartActivity(new Intent(this, typeof(DerectShareWithoutEditActivity)));
                    break;
            }
        }

        /**
	 * 演示调用ShareSDK执行分享
	 *
	 * @param context
	 * @param platformToShare  指定直接分享平台名称（一旦设置了平台名称，则九宫格将不会显示）
	 * @param showContentEdit  是否显示编辑页
	 */
        public static void ShowShare(Context context, string platformToShare, bool showContentEdit)
        {
            OnekeyShare oks = new OnekeyShare();
            oks.SetSilent(!showContentEdit);
            if (platformToShare != null)
            {
                oks.SetPlatform(platformToShare);
            }
            //ShareSDK快捷分享提供两个界面第一个是九宫格 CLASSIC  第二个是SKYBLUE
            oks.SetTheme(OnekeyShareTheme.Classic);
            // 令编辑页面显示为Dialog模式
            oks.SetDialogMode();
            // 在自动授权时可以禁用SSO方式
            oks.DisableSSOWhenAuthorize();
            //oks.setAddress("12345678901"); //分享短信的号码和邮件的地址
            oks.SetTitle("ShareSDK--Title");
            oks.SetTitleUrl("http://mob.com");
            //oks.SetText("ShareSDK--文本");
            oks.Text = "ShareSDK--文本";
            //oks.setImagePath("/sdcard/test-pic.jpg");  //分享sdcard目录下的图片
            oks.SetImageUrl("http://img1.2345.com/duoteimg/qqTxImg/2012/04/09/13339485237265.jpg");
            oks.SetUrl("http://www.mob.com"); //微信不绕过审核分享链接
                                              //oks.setFilePath("/sdcard/test-pic.jpg");  //filePath是待分享应用程序的本地路劲，仅在微信（易信）好友和Dropbox中使用，否则可以不提供
            oks.SetComment("分享"); //我对这条分享的评论，仅在人人网和QQ空间使用，否则可以不提供
            oks.SetSite("ShareSDK");  //QZone分享完之后返回应用时提示框上显示的名称
            oks.SetSiteUrl("http://mob.com");//QZone分享参数
            oks.SetVenueName("ShareSDK");
            oks.SetVenueDescription("This is a beautiful place!");
            // 将快捷分享的操作结果将通过OneKeyShareCallback回调
            //oks.setCallback(new OneKeyShareCallback());
            // 去自定义不同平台的字段内容
            //oks.setShareContentCustomizeCallback(new ShareContentCustomizeDemo());
            // 在九宫格设置自定义的图标
            Bitmap logo = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.ic_launcher);
            String label = "ShareSDK";
            var listener = new CustomOnClickListener();
            oks.SetCustomerLogo(logo, label, listener);

		    // 为EditPage设置一个背景的View
		    //oks.setEditPageBackground(getPage());
		    // 隐藏九宫格中的新浪微博
		    // oks.addHiddenPlatform(SinaWeibo.NAME);

		    // String[] AVATARS = {
				// 		"http://99touxiang.com/public/upload/nvsheng/125/27-011820_433.jpg",
				// 		"http://img1.2345.com/duoteimg/qqTxImg/2012/04/09/13339485237265.jpg",
				// 		"http://diy.qqjay.com/u/files/2012/0523/f466c38e1c6c99ee2d6cd7746207a97a.jpg",
				// 		"http://diy.qqjay.com/u2/2013/0422/fadc08459b1ef5fc1ea6b5b8d22e44b4.jpg",
				// 		"http://img1.2345.com/duoteimg/qqTxImg/2012/04/09/13339510584349.jpg",
				// 		"http://diy.qqjay.com/u2/2013/0401/4355c29b30d295b26da6f242a65bcaad.jpg" };
				// oks.setImageArray(AVATARS);              //腾讯微博和twitter用此方法分享多张图片，其他平台不可以

		    // 启动分享
		    oks.Show(context);
	    }

        private class CustomOnClickListener : Java.Lang.Object, IOnClickListener
        {
            public void OnClick(View v)
            {

            }
        }

        public static String[] randomPic()
        {
            String url = "http://git.oschina.net/alexyu.yxj/MyTmpFiles/raw/master/kmk_pic_fld/";
            String urlSmall = "http://git.oschina.net/alexyu.yxj/MyTmpFiles/raw/master/kmk_pic_fld/small/";
            String[] pics = new String[] {
                "120.JPG",
                "127.JPG",
                "130.JPG",
                "18.JPG",
                "184.JPG",
                "22.JPG",
                "236.JPG",
                "237.JPG",
                "254.JPG",
                "255.JPG",
                "263.JPG",
                "265.JPG",
                "273.JPG",
                "37.JPG",
                "39.JPG",
                "IMG_2219.JPG",
                "IMG_2270.JPG",
                "IMG_2271.JPG",
                "IMG_2275.JPG",
                "107.JPG"
            };
            int index = (int)(DateTime.Now.Millisecond % pics.Length);
            return new String[] {
                url + pics[index],
                urlSmall + pics[index]
            };
        }
    }
}

