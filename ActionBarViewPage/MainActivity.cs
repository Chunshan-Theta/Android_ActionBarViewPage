﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Content.PM;

namespace ActionBarViewPage
{
    [Activity(Label = "ActionBarViewPage", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FragmentActivity
    {
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            SetContentView(Resource.Layout.Main);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            var pager = FindViewById<ViewPager>(Resource.Id.pager);
            var adaptor = new GenericFragmentPagerAdaptor(SupportFragmentManager);

            adaptor.AddFragmentView((i, v, b) =>
            {
                var view = i.Inflate(Resource.Layout.tab, v, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.textView1);
                sampleTextView.Text = "This is content";
                return view;
            }
            );

            adaptor.AddFragmentView((i, v, b) =>
            {
                var view = i.Inflate(Resource.Layout.tab, v, false);
                var sampleTextView = view.FindViewById<TextView>(Resource.Id.textView1);
                sampleTextView.Text = "This is more content";
                return view;
            }
            );

            pager.Adapter = adaptor;
            //pager.SetOnPageChangeListener(new ViewPageListenerForActionBar(ActionBar));
            pager.AddOnPageChangeListener(new ViewPageListenerForActionBar(ActionBar));



            ActionBar.AddTab(pager.GetViewPageTab(ActionBar, "Tab1"));
            ActionBar.AddTab(pager.GetViewPageTab(ActionBar, "Tab2"));
        }
    }
}

