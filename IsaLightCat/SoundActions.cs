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
    public class SoundActions
    {
        public static void PlaySound(Android.Content.Context context, MediaPlayer mp)
        {
            int randomCatSound = getRandomCatSound();
            mp = MediaPlayer.Create(context, randomCatSound);//.Create(MainActivity.this, randomCatSound);

            mp.Completion += delegate
            {

                OnCompletion(mp);
            };
               
            mp.Start();
        }

        public static void OnCompletion(MediaPlayer mp)
        {
            mp.Release();
        }

        private static int getRandomCatSound()
        {
            var totoList = new List<int>();
            totoList.Add(Resource.Raw.tone_cat_meow);
            totoList.Add(Resource.Raw.tone_cat_meow2);
            totoList.Add(Resource.Raw.tone_cat_meow3);
            totoList.Add(Resource.Raw.tone_cat_meow4);

            int randomCatSound = totoList[getRandomNumber(0, totoList.Count - 1)];
            return randomCatSound;
        }

        public static int getRandomNumber(int min, int max)
        {
            var random = new Random();
            int randomNumber = random.Next((max - min) + 1) + min;
            return randomNumber;
        }
    }
}

