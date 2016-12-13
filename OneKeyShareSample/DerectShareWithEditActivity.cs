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
using static Android.Views.View;
using static Android.Widget.LinearLayout;
using CN.Sharesdk.Framework;

namespace OneKeyShareSample
{
    [Activity]
    public class DerectShareWithEditActivity : Activity, IOnClickListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_derect_share);

            LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            Platform[] platforms = ShareSDK.GetPlatformList();
            foreach(Platform p in platforms)
            {
                Button btn = new Button(this);
                btn.SetText(p.Name, TextView.BufferType.Normal);
                btn.SetTag(btn.Id, p);
                btn.SetOnClickListener(this);
                layout.AddView(btn, new LayoutParams(
                        LayoutParams.MatchParent, LayoutParams.WrapContent));
            }
        }

        public void OnClick(View v)
        {
            Object tag = v.GetTag(v.Id);
            if (tag != null)
            {
                Platform platform = (Platform)tag;
                MainActivity.ShowShare(this, platform.Name, true);
            }
        }
    }
}