using Android.Widget;

namespace CatFlashLight
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

