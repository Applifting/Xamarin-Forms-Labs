using System;
using Android.Support.V4.View;

namespace Xamarin.Forms.Labs.Droid
{
    public class CalendarMonthPageTransformer : Java.Lang.Object ,ViewPager.IPageTransformer
    {


        private const float MIN_SCALE = 0.75f;

        public CalendarMonthPageTransformer()
        {
        }

        #region IPageTransformer implementation

        public void TransformPage(Android.Views.View page, float position)
        {
            int pageWidth = page.Width;
            if(position < -1)
            {
                page.Alpha = 0;
            } else if(position <= 0)
            {
                page.Alpha = (1);
                page.TranslationX = 0;
                page.ScaleX = 1;
                page.ScaleY = 1;
            } else if(position <= 1)
            {
                page.Alpha = 1 - position;
                page.TranslationX = (pageWidth * -position);
                float scaleFactor = MIN_SCALE + (1 - MIN_SCALE) * (1 - Math.Abs(position));
                page.ScaleX = (scaleFactor);
                page.ScaleY = (scaleFactor);


            } else
            {
                page.Alpha = 0;
            }

        }

        #endregion

    }
}

