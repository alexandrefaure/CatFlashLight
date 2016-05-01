using System;
using Android.Hardware;
using Android.Util;

namespace IsaLightCat
{
    public static class CameraActions
    {
        //        public static Camera GetCamera()
        //        {
        ////            if (camera == null)
        ////            {
        //            Camera camera = null;
        //            try
        //            {
        //                camera = Camera.Open();
        ////                camera.GetParameters();
        //                return camera;
        //            }
        //            catch (Exception e)
        //            {
        //                Log.Error(e.ToString(), "Impossible to get camera");
        //            }
        //            return camera;
        ////            }
        //        }
        //
        //        public static void TurnOnFlash(Camera camera, bool isFlashOn)
        //        {
        //            if (!isFlashOn)
        //            {
        //                if (camera == null) // && parameters == null)
        //                {
        //                    return;
        //                }
        //                //Camera camera = getCamera();
        //                var parameters = camera.GetParameters();
        //                parameters.FlashMode = Camera.Parameters.FlashModeOn;//.Set(Camera.Parameters.FlashModeOn, 1);
        //                camera.SetParameters(parameters);
        ////                playSound();
        //                isFlashOn = true;
        ////                toggleButtonImage();
        //                camera.StartPreview();
        //            }
        //        }
        //
        //        public static void TurnOffFlash(Camera camera, bool isFlashOn)
        //        {
        //            if (isFlashOn != false)
        //            {
        //                if (camera == null)// && parameters == null)
        //                {
        //                    return;
        //                }
        //                //Camera camera = getCamera();
        //                var parameters = camera.GetParameters();
        ////                parameters.Set(Camera.Parameters.FlashModeOn, 1);
        //                parameters.FlashMode = Camera.Parameters.FlashModeOff;
        //                camera.SetParameters(parameters);
        //                isFlashOn = false;
        ////                toggleButtonImage();
        //                camera.StopPreview();
        //            }
        //        }
    }
}

