using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using Android.Support.V4.Widget;
using Libraries;

namespace UFSBook
{
    [Activity(Label = "Main")]
    public class MainActivity : Activity, DrawerLayout.IDrawerListener
    {
        public DrawerArrowDrawable drawerArrowDrawable;
        public float offset;
        public Boolean flipped;
        DrawerLayout layout;
        View main;
        View panel;
        ImageView imageView;
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            InitializeComponents();

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
            layout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            imageView = FindViewById<ImageView>(Resource.Id.drawer_indicator);
            //main = FindViewById<View>(Resource.Id.listView1);
            panel = FindViewById<View>(Resource.Id.listView);
            Resources resources = Resources;
            
            drawerArrowDrawable = new DrawerArrowDrawable(resources);
            drawerArrowDrawable.setStrokeColor(Resource.Color.light_gray);
            imageView.SetImageDrawable(drawerArrowDrawable);

            layout.SetDrawerListener(this);
            imageView.Click += ImageView_Click;
        }

       

        private void ImageView_Click(object sender, EventArgs e)
        {
            if (layout.IsDrawerVisible(panel))
            {
                layout.CloseDrawer(panel);
            }
            else
            {
                layout.OpenDrawer(panel);
            }
            
        }



        public void OnDrawerClosed(View drawerView)
        {
            //throw new NotImplementedException ();
        }

        public void OnDrawerOpened(View drawerView)
        {
            //throw new NotImplementedException ();
        }

        public void OnDrawerSlide(View drawerView, float slideOffset)
        {
            offset = slideOffset;

            // Sometimes slideOffset ends up so close to but not quite 1 or 0.
            if (slideOffset >= .995)
            {
                flipped = true;
                drawerArrowDrawable.setFlip(flipped);
            }
            else if (slideOffset <= .005)
            {
                flipped = false;
                drawerArrowDrawable.setFlip(flipped);
            }

            drawerArrowDrawable.setParameter(offset);
            //throw new NotImplementedException ();
        }

        public void OnDrawerStateChanged(int newState)
        {
            //throw new NotImplementedException ();
        }

        private void InitializeComponents()
        {
            InitializeControls();
            InitializeEvents();
        }

        private void InitializeControls()
        {
           
        }

        private void InitializeEvents()
        {

        }
    }
}