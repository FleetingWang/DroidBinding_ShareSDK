
using Android.App;
using Android.Content;
using Android.Widget;
using CN.Sharesdk.Wechat.Utils;

namespace OneKeyShareSample.wxapi
{
    [Activity(
        Name = "onekeysharesample.wxapi.WXEntryActivity",
        Theme = "@android:style/Theme.Translucent.NoTitleBar",
        ConfigurationChanges = Android.Content.PM.ConfigChanges.KeyboardHidden| Android.Content.PM.ConfigChanges.Orientation| Android.Content.PM.ConfigChanges.ScreenSize,
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        Exported = true)]
    public class WXEntryActivity : WechatHandlerActivity
    {
        /**
	     * ����΢�ŷ������������Ӧ������app message
	     * <p>
	     * ��΢�ſͻ����е�����ҳ���С���ӹ��ߡ������Խ���Ӧ�õ�ͼ����ӵ�����
	     * �˺���ͼ�꣬����Ĵ���ᱻִ�С�Demo����ֻ�Ǵ��Լ����ѣ������
	     * �������������飬�������������κ�ҳ��
	     */
        public void onGetMessageFromWXReq(WXMediaMessage msg)
        {
            Intent iLaunchMyself = PackageManager.GetLaunchIntentForPackage(PackageName);
            StartActivity(iLaunchMyself);
        }

        /**
         * ����΢���������Ӧ�÷������Ϣ
         * <p>
         * �˴��������մ�΢�ŷ��͹�������Ϣ���ȷ�˵��demo��wechatpage�������
         * Ӧ��ʱ���Բ�����Ӧ���ļ���������һ��Ӧ�õ��Զ�����Ϣ�����ܷ���΢��
         * �ͻ��˻�ͨ������������������Ϣ���ͻؽ��շ��ֻ��ϵı�demo�У�����
         * �ص���
         * <p>
         * ��Demoֻ�ǽ���Ϣչʾ������������������������飬��������ֻ��Toast
         */
        public void onShowMessageFromWXReq(WXMediaMessage msg)
        {
            if (msg != null && msg.Media != null
                    && (msg.Media is WXAppExtendObject))
            {
                WXAppExtendObject obj = (WXAppExtendObject)msg.Media;
                Toast.MakeText(this, obj.ExtInfo, ToastLength.Short).Show();
            }
        }
    }
}