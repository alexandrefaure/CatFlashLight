using System;
using Android.Hardware;
using Android.Util;

namespace IsaLightCat
{
    public class CameraActions
    {
        //        private Camera camera;
        //        private Camera.Parameters parameters;

        //        public CameraActions()
        //        {
        //        }

        public static void GetCamera(Camera camera)
        {
            if (camera == null)
            {
                try
                {
                    camera = Camera.Open();
                    camera.GetParameters();
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString(), "Impossible to get camera");
                }
            }
        }

        public static void TurnOnFlash(Camera camera, bool isFlashOn)
        {
            if (!isFlashOn)
            {
                if (camera == null) // && parameters == null)
                {
                    return;
                }
                //Camera camera = getCamera();
                var parameters = camera.GetParameters();
                parameters.Set(Camera.Parameters.FlashModeOn, 1);
                camera.SetParameters(parameters);
//                playSound();
                isFlashOn = true;
//                toggleButtonImage();
                camera.StartPreview();
            }
        }

        public static void TurnOffFlash(Camera camera, bool isFlashOn)
        {
            if (isFlashOn != false)
            {
                if (camera == null)// && parameters == null)
                {
                    return;
                }
                //Camera camera = getCamera();
                var parameters = camera.GetParameters();
                parameters.Set(Camera.Parameters.FlashModeOn, 1);
                camera.SetParameters(parameters);
                isFlashOn = false;
//                toggleButtonImage();
                camera.StopPreview();
            }
        }
    }
}

