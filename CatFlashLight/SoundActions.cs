using System;
using System.Collections.Generic;
using Android.Media;

namespace CatFlashLight
{
    public class SoundActions
    {
        public static void PlaySound(Android.Content.Context context, MediaPlayer mp)
        {
            var randomCatSound = GetRandomCatSound();
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

        private static int GetRandomCatSound()
        {
            var totoList = new List<int>
            {
                Resource.Raw.tone_cat_meow,
                Resource.Raw.tone_cat_meow2,
                Resource.Raw.tone_cat_meow3,
                Resource.Raw.tone_cat_meow4
            };

            var randomCatSound = totoList[GetRandomNumber(0, totoList.Count - 1)];
            return randomCatSound;
        }

        public static int GetRandomNumber(int min, int max)
        {
            var random = new Random();
            var randomNumber = random.Next((max - min) + 1) + min;
            return randomNumber;
        }
    }
}

