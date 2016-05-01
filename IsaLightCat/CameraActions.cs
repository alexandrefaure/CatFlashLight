using System;
using Android.Hardware;
using Android.Util;

namespace IsaLightCat
{
    public static class CameraActions
    {
        public static Camera GetCamera(Camera camera, Camera.Parameters parameters)
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
            return camera;
        }

        public static bool TurnOnFlash(Camera camera, Camera.Parameters parameters, bool isFlashOn)
        {
            if (!isFlashOn)
            {
                if (camera == null && parameters == null)
                {
                    return false;
                }
                parameters = camera.GetParameters();
                parameters.FlashMode = Camera.Parameters.FlashModeTorch;
                camera.SetParameters(parameters);
                isFlashOn = true;
                camera.StartPreview();
            }
            return isFlashOn;
        }

        public static bool TurnOffFlash(Camera camera, Camera.Parameters parameters, bool isFlashOn)
        {
            if (isFlashOn != false)
            {
                if (camera == null && parameters == null)
                {
                    return false;
                }
                parameters = camera.GetParameters();
                parameters.FlashMode = Camera.Parameters.FlashModeOff;
                camera.SetParameters(parameters);
                isFlashOn = false;
                camera.StopPreview();
            }
            return isFlashOn;
        }
    }
}

