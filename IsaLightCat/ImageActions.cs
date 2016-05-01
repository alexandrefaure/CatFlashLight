using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using Android.Util;
using Android.Media;
using System.Collections.Generic;

namespace IsaLightCat
{
    public static class ImageActions
    {
        public static ImageButton SwitchImage(ImageButton switchButton, bool isFlashOn)
        {
            if (isFlashOn)
            {
                switchButton.SetImageResource(Resource.Drawable.isa_cat_open);
            }
            else
            {
                switchButton.SetImageResource(Resource.Drawable.isa_cat_close);
            }

            return switchButton;
        }
    }
}

