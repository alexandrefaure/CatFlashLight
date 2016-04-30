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
        int count = 1;

        private Camera camera;
        //        private Camera.Parameters parameters;
        private bool isFlashOn = false;
        private ImageButton swithButton;
        //        private MediaPlayer mp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
			
            button.Click += delegate
            {
                button.Text = string.Format("{0} clicks!", count++);
            };
        }

        public static int randInt(int min, int max)
        {
            var rand = new Random();
            int randomNum = rand.Next((max - min) + 1) + min;
            return randomNum;
        }

        //        void getCamera()
        //        {
        //            if (camera == null)
        //            {
        //                try
        //                {
        //                    camera = Camera.Open();
        //                    parameters = camera.GetParameters();
        //                }
        //                catch (Exception e)
        //                {
        //                    Log.Info("Failed to Open Camera");
        //                }
        //            }
        //        }

        //        public void turnOnFlash()
        //        {
        //            if (!isFlashOn)
        //            {
        //                if (camera == null && parameters == null)
        //                {
        //                    return;
        //                }
        //                //Camera camera = getCamera();
        //                parameters = camera.GetParameters();
        //                parameters.Set(Camera.Parameters.FlashModeOn);
        //                camera.SetParameters(parameters);
        ////                playSound();
        //                isFlashOn = true;
        ////                toggleButtonImage();
        //                camera.StartPreview();
        //
        //            }
        //        }
        //
        //        public void turnOffFlash()
        //        {
        //            if (isFlashOn != false)
        //            {
        //                if (camera == null && parameters == null)
        //                {
        //                    return;
        //                }
        //                //Camera camera = getCamera();
        //                parameters = camera.GetParameters();
        //                parameters.Set(Camera.Parameters.FlashModeOn);
        //                camera.SetParameters(parameters);
        //                isFlashOn = false;
        ////                toggleButtonImage();
        //                camera.StopPreview();
        //            }
        //        }

        //            public void playSound()
        //    {
        //        int randomCatSound = getRandomCatSound();
        //        mp = MediaPlayer.create(MainActivity.this, randomCatSound);
        //        mp.setOnCompletionListener(new MediaPlayer.OnCompletionListener() {
        //            @Override
        //            public void onCompletion(MediaPlayer mp)
        //            {
        //                mp.release();
        //            }
        //        });
        //        mp.start();
        //    }

        public void toggleButtonImage()
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

        protected void onDestroy()
        {
            base.OnDestroy();
        }

        protected void onPause()
        {
            base.OnPause();

            // on pause turn off the flash
//            CameraActions.TurnOffFlash(isFlashOn);
        }

        protected void onRestart()
        {
            base.OnRestart();
        }

        protected  void onResume()
        {
            base.OnResume();

            // on resume turn on the flash
            if (isFlashOn)
            {
                CameraActions.TurnOnFlash(camera, isFlashOn);
            }
        }

        protected void onStart()
        {
            base.OnStart();

            // on starting the app get the camera params
            CameraActions.GetCamera(camera);
        }

        protected void onStop()
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


