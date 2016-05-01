using Android.App;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using System;
using Android.Util;
using Android.Media;
using System.Collections.Generic;

namespace IsaLightCat
{
    [Android.App.Activity(Label = "IsaLightCat", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        private static Camera camera;
        private bool isFlashOn = false;
        private ImageButton swithButton;
        private static Camera.Parameters parameters;
        private MediaPlayer mp;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            swithButton = (ImageButton)FindViewById<ImageButton>(Resource.Id.imageButton);

            GetCamera();

            SwitchImage();

            swithButton.Click += delegate
            {
                SwitchImage();
                onClick(isFlashOn);
            };
        }

        public void onClick(bool isFlashOn)
        {
            if (isFlashOn)
            {
                TurnOffFlash();
            }
            else
            {
                TurnOnFlash();
            }
        }

        public static int getRandomNumber(int min, int max)
        {
            var random = new Random();
            int randomNumber = random.Next((max - min) + 1) + min;
            return randomNumber;
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

        public static void GetCamera()
        {
            if (camera == null)
            {
                try
                {
                    camera = Camera.Open();
                    parameters = camera.GetParameters();
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString(), "Impossible to get camera");
                }
            }
        }

        public void TurnOnFlash()
        {
            if (!isFlashOn)
            {
                if (camera == null && parameters == null)
                {
                    return;
                }
                parameters = camera.GetParameters();
                parameters.FlashMode = Camera.Parameters.FlashModeTorch;
                camera.SetParameters(parameters);
                isFlashOn = true;
                SwitchImage();
                playSound();
                camera.StartPreview();
            }
        }

        public void TurnOffFlash()
        {
            if (isFlashOn != false)
            {
                if (camera == null && parameters == null)
                {
                    return;
                }
                parameters = camera.GetParameters();
                parameters.FlashMode = Camera.Parameters.FlashModeOff;
                camera.SetParameters(parameters);
                isFlashOn = false;
                SwitchImage();
                camera.StopPreview();
            }
        }

        public void playSound()
        {
            int randomCatSound = getRandomCatSound();
            mp = MediaPlayer.Create(this, randomCatSound);//.Create(MainActivity.this, randomCatSound);

            mp.Completion += delegate
            {

                onCompletion(mp);
            };
               
            mp.Start();
        }

        public void onCompletion(MediaPlayer mp)
        {
            mp.Release();
        }

        private int getRandomCatSound()
        {
            var totoList = new List<int>();
            totoList.Add(Resource.Raw.tone_cat_meow);
            totoList.Add(Resource.Raw.tone_cat_meow2);
            totoList.Add(Resource.Raw.tone_cat_meow3);
            totoList.Add(Resource.Raw.tone_cat_meow4);

            int randomCatSound = totoList[getRandomNumber(0, totoList.Count - 1)];
            return randomCatSound;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected void onPause()
        {
            base.OnPause();

            // on pause turn off the flash
            TurnOffFlash();
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
                TurnOnFlash();
            }
        }

        protected override void OnStart()
        {
            base.OnStart();

            // on starting the app get the camera params
            GetCamera();
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


