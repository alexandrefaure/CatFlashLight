using Android.App;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using Android.Media;
using Android.Content.PM;

namespace IsaLightCat
{
    [Android.App.Activity(Label = "IsaLightCat", MainLauncher = true, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        private static Camera camera;
        private bool isFlashOn = false;
        private ImageButton switchButton;
        private Button infoButton;
        private TextView infoTextView;
        private static Camera.Parameters parameters = null;
        private static MediaPlayer mediaPlayer = null;
        private bool isInfoShown = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            switchButton = (ImageButton)FindViewById<ImageButton>(Resource.Id.imageButton);
            camera = CameraActions.GetCamera(camera, parameters);
            ImageActions.SwitchImage(switchButton, isFlashOn);

            switchButton.Click += delegate
            {
                isFlashOn = onClick(isFlashOn);
                ImageActions.SwitchImage(switchButton, isFlashOn);
            };
            infoButton = (Button)FindViewById<Button>(Resource.Id.infoButton);
            infoTextView = (TextView)FindViewById<TextView>(Resource.Id.textView1);
            infoTextView.Visibility = Android.Views.ViewStates.Gone;
            infoButton.Click += delegate
            {
                if (isInfoShown)
                {
                    isInfoShown = false;
                    infoTextView.Visibility = Android.Views.ViewStates.Gone;
                    switchButton.Visibility = Android.Views.ViewStates.Visible;
                    infoButton.Text = "Info";
                }
                else
                {
                    isInfoShown = true;
                    infoTextView.Visibility = Android.Views.ViewStates.Visible;
                    switchButton.Visibility = Android.Views.ViewStates.Gone;
                    infoButton.Text = "Back";
                }
            };
        }

        public bool onClick(bool isFlashOn)
        {
            if (isFlashOn)
            {
                isFlashOn = CameraActions.TurnOffFlash(camera, parameters, isFlashOn);
                ImageActions.SwitchImage(switchButton, isFlashOn);
            }
            else
            {

                SoundActions.PlaySound(this, mediaPlayer);
                isFlashOn = CameraActions.TurnOnFlash(camera, parameters, isFlashOn);
                ImageActions.SwitchImage(switchButton, isFlashOn);
            }
            return isFlashOn;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected override void OnPause()
        {
            base.OnPause();

            // on pause turn off the flash
            isFlashOn = CameraActions.TurnOffFlash(camera, parameters, isFlashOn);
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
                isFlashOn = CameraActions.TurnOnFlash(camera, parameters, isFlashOn);
            }
        }

        protected override void OnStart()
        {
            base.OnStart();

            // on starting the app get the camera params
//            GetCamera();
            camera = CameraActions.GetCamera(camera, parameters);
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


