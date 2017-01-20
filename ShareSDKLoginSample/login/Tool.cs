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
using CN.Sharesdk.Framework;
using Android.Graphics;
using static Android.Graphics.Bitmap;

namespace ShareSDKLoginSample.login
{
    public class Tool
    {
        /** 判断指定平台是否可以用来获取用户资料  */
        public static bool canGetUserInfo(Platform plat)
        {
            if (plat == null)
            {
                return false;
            }
            //手机未安装以下两个平台的客户端的时候，对应平台的登陆按钮不显示出来
            String platform = plat.Name;
            if ("Wechat".Equals(platform) && !plat.IsClientValid)
            {
                return false;
            }

            //以下平台不支持登陆功能
            return !("WechatMoments".Equals(platform)
                    || "WechatFavorite".Equals(platform) || "ShortMessage".Equals(platform)
                    || "Email".Equals(platform)
                    || "Pinterest".Equals(platform) || "Yixin".Equals(platform)
                    || "YixinMoments".Equals(platform) || "Line".Equals(platform)
                    || "Bluetooth".Equals(platform) || "WhatsApp".Equals(platform)
                    || "Pocket".Equals(platform) || "BaiduTieba".Equals(platform)
                    || "Laiwang".Equals(platform) || "LaiwangMoments".Equals(platform)
                    || "Alipay".Equals(platform));
        }

        /**
         *  将action转换为String   action表示当前的动作
         */
        public static String actionToString(int action)
        {
            switch (action)
            {
                case Platform.ActionAuthorizing: return "ACTION_AUTHORIZING";
                case Platform.ActionGettingFriendList: return "ACTION_GETTING_FRIEND_LIST";
                case Platform.ActionFollowingUser: return "ACTION_FOLLOWING_USER";
                case Platform.ActionSendingDirectMessage: return "ACTION_SENDING_DIRECT_MESSAGE";
                case Platform.ActionTimeline: return "ACTION_TIMELINE";
                case Platform.ActionUserInfor: return "ACTION_USER_INFOR";
                case Platform.ActionShare: return "ACTION_SHARE";
                default:
                    {
                        return "UNKNOWN";
                    }
            }
        }

        //图片压缩
        public static Bitmap compressImageFromFile(String srcPath)
        {
            BitmapFactory.Options newOpts = new BitmapFactory.Options();
            newOpts.InJustDecodeBounds = true;//只读边,不读内容
            Bitmap bitmap = BitmapFactory.DecodeFile(srcPath, newOpts);

            newOpts.InJustDecodeBounds = false;
            int w = newOpts.OutWidth;
            int h = newOpts.OutHeight;
            float hh = 800f;//
            float ww = 480f;//
            int be = 1;
            if (w > h && w > ww)
            {
                be = (int)(newOpts.OutWidth / ww);
            }
            else if (w < h && h > hh)
            {
                be = (int)(newOpts.OutHeight / hh);
            }
            if (be <= 0)
                be = 1;
            newOpts.InSampleSize = be;//设置采样率

            newOpts.InPreferredConfig = Config.Argb8888;//该模式是默认的,可不设
            newOpts.InPurgeable = true;// 同时设置才会有效
            newOpts.InInputShareable = true;//。当系统内存不够时候图片自动被回收

            bitmap = BitmapFactory.DecodeFile(srcPath, newOpts);
            //		return compressBmpFromBmp(bitmap);//原来的方法调用了这个方法企图进行二次压缩
            //其实是无效的,大家尽管尝试
            return bitmap;
        }
    }
}