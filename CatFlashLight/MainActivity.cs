using Android.App;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Widget;

namespace CatFlashLight
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private bool _isFlashOn = false;
        private ImageButton _switchButton;
        private Button _infoButton;
        private TextView _infoTextView;
        private static readonly MediaPlayer MediaPlayer = null;
        private bool _isInfoShown = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState); // Obligatoire pour l'utilisation de Xamarin.Essentials
            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.activity_main);

            _switchButton = (ImageButton)FindViewById<ImageButton>(Resource.Id.imageButton);
            ImageActions.SwitchImage(_switchButton, _isFlashOn);

            _switchButton.Click += delegate
            {
                OnClick();
                ImageActions.SwitchImage(_switchButton, _isFlashOn);
            };

            _infoTextView = (TextView)FindViewById<TextView>(Resource.Id.textView);
            _infoTextView.Visibility = Android.Views.ViewStates.Gone;

            _infoButton = (Button)FindViewById<Button>(Resource.Id.button);
            _infoButton.Click += delegate
            {
                if (_isInfoShown)
                {
                    _isInfoShown = false;
                    _infoTextView.Visibility = Android.Views.ViewStates.Gone;
                    _switchButton.Visibility = Android.Views.ViewStates.Visible;
                    _infoButton.Text = "Info";
                }
                else
                {
                    _isInfoShown = true;
                    _infoTextView.Visibility = Android.Views.ViewStates.Visible;
                    _switchButton.Visibility = Android.Views.ViewStates.Gone;
                    _infoButton.Text = "Back";
                }
            };
        }

        public async void OnClick()
        {
            if (_isFlashOn)
            {
                _isFlashOn = await CameraActions.TurnOffFlash(_isFlashOn);
                ImageActions.SwitchImage(_switchButton, _isFlashOn);
            }
            else
            {

                SoundActions.PlaySound(this, MediaPlayer);
                _isFlashOn = await CameraActions.TurnOnFlash(_isFlashOn);
                ImageActions.SwitchImage(_switchButton, _isFlashOn);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected override async void OnPause()
        {
            base.OnPause();

            // on pause turn off the flash
            _isFlashOn = await CameraActions.TurnOffFlash(_isFlashOn);
        }

        protected override void OnRestart()
        {
            base.OnRestart();
        }

        protected override async void OnResume()
        {
            base.OnResume();

            // on resume turn on the flash
            if (_isFlashOn)
            {
                _isFlashOn = await CameraActions.TurnOnFlash(_isFlashOn);
            }
        }

        protected override void OnStart()
        {
            base.OnStart();

            // on starting the app get the camera params
            //            GetCamera();
            //_camera = CameraActions.GetCamera(_camera, _parameters);
        }

        protected override void OnStop()
        {
            base.OnStop();

            // on stop release the camera
            //if (_camera != null)
            //{
            //    _camera.Release();
            //    _camera = null;
            //}
        }

        /// <summary>
        /// Initialization des permissions pour Xamarin.Essentials
        /// </summary>
        /// <param name="requestCode"></param>
        /// <param name="permissions"></param>
        /// <param name="grantResults"></param>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}