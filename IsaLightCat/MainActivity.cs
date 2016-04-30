using Android.App;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using System;

namespace IsaLightCat
{
    [Activity(Label = "IsaLightCat", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private static Camera camera;
        private bool isFlashOn = false;
        private ImageButton swithButton;
        //        Android.Views.View view;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
//            Button button = FindViewById<Button>(Resource.Id.myButton);
            swithButton = (ImageButton)FindViewById<ImageButton>(Resource.Id.imageButton);

            //camera = CameraActions.GetCamera();

            SwitchImage();

//            swithButton.SetOnClickListener(new Android.Views.View.IOnClickListener{ onClick(view, isFlashOn) });
//
            swithButton.Click += delegate
            {
//                button.Text = string.Format("{0} clicks!", count++);
                if (isFlashOn)
                {
                    CameraActions.TurnOffFlash(camera, isFlashOn);
                }
                else
                {
                    CameraActions.TurnOnFlash(camera, isFlashOn);
                }
            };
        }

        public void onClick(Android.Views.View v, bool isFlashOn)
        {
            if (isFlashOn)
            {
                CameraActions.TurnOffFlash(camera, isFlashOn);
            }
            else
            {
                CameraActions.TurnOnFlash(camera, isFlashOn);
            }
        }

        public static int randInt(int min, int max)
        {
            var rand = new Random();
            int randomNum = rand.Next((max - min) + 1) + min;
            return randomNum;
        }

        public void SwitchImage()
        {
            if (isFlashOn)
            {
                swithButton.SetImageResource(Resource.Drawable.isa_cat_open);
            }
            else
            {
                swithButton.SetImageResource(Resource.Drawable.isa_cat_close);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected void onPause()
        {
            base.OnPause();

            // on pause turn off the flash
            CameraActions.TurnOffFlash(camera, isFlashOn);
        }

        protected override void OnRestart()
        {
            base.OnRestart();
        }

        protected override  void OnResume()
        {
            base.OnResume();

            // on resume turn on the flash
            if (isFlashOn)
            {
                CameraActions.TurnOnFlash(camera, isFlashOn);
            }
        }

        protected override void OnStart()
        {
            base.OnStart();

            // on starting the app get the camera params
            camera = CameraActions.GetCamera();
        }

        protected override void OnStop()
        {
            base.OnStop();

            // on stop release the camera
            if (camera != null)
            {
                camera.Release();
                camera = null;
            }
        }
    }
}


