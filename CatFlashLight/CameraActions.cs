using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CatFlashLight
{
    public static class CameraActions
    {
        public static async Task<bool> TurnOnFlash(bool isFlashOn)
        {
            if (!isFlashOn)
            {
                try
                {
                    // Turn On
                    await Flashlight.TurnOnAsync();
                    isFlashOn = true;
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Handle not supported on device exception
                }
                catch (PermissionException pEx)
                {
                    // Handle permission exception
                }
                catch (Exception ex)
                {
                    // Unable to turn on/off flashlight
                }
            }
            return isFlashOn;
        }

        public static async Task<bool> TurnOffFlash(bool isFlashOn)
        {
            if (isFlashOn)
            {
                try
                {
                    // Turn Off
                    await Flashlight.TurnOffAsync();
                    isFlashOn = false;
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // Handle not supported on device exception
                }
                catch (PermissionException pEx)
                {
                    // Handle permission exception
                }
                catch (Exception ex)
                {
                    // Unable to turn on/off flashlight
                }
            }
            return isFlashOn;
        }
    }
}

