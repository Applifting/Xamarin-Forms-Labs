using System;
using Android.App;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Droid.Services;
using Android.Util;
using Android.Content.Res;

namespace Xamarin.Forms.Labs
{
    /// <summary>
    /// Android Display implements <see cref="IDisplay"/>.
    /// </summary>
    public class Display : IDisplay
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Xamarin.Forms.Labs.Display"/> class.
        /// </summary>
        public Display()
        {
            var dm = Metrics;
            this.Height = dm.HeightPixels;
            this.Width = dm.WidthPixels;
            this.Xdpi = dm.Xdpi;
            this.Ydpi = dm.Ydpi;

            this.FontManager = new FontManager(this);
        }

        public static Android.Util.DisplayMetrics Metrics
        {
            get
            {
                return Application.Context.Resources.DisplayMetrics;
            }
        }

        #region IScreen implementation
        /// <summary>
        /// Gets the screen height in pixels
        /// </summary>
        public int Height
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the screen width in pixels
        /// </summary>
        public int Width
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the screens X pixel density per inch
        /// </summary>
        public double Xdpi
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the screens Y pixel density per inch
        /// </summary>
        public double Ydpi
        {
            get;
            private set;
        }

        public int DipHeight {
            get {
                return (int)Math.Round(Height/Resources.System.DisplayMetrics.Density);
            }
        }

        public int DipWidth {
            get {
                return (int)Math.Round(Width/Resources.System.DisplayMetrics.Density);
            }
        }

        public IFontManager FontManager
        {
            get;
            private set;
        }

        /// <summary>
        /// Convert width in inches to runtime pixels
        /// </summary>
        public double WidthRequestInInches(double inches)
        {
            return inches * this.Xdpi / Metrics.Density;
        }

        /// <summary>
        /// Convert height in inches to runtime pixels
        /// </summary>
        public double HeightRequestInInches(double inches)
        {
            return inches * this.Ydpi / Metrics.Density;
        }
        #endregion

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="Xamarin.Forms.Labs.Display"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="Xamarin.Forms.Labs.Display"/>.</returns>
        public override string ToString()
        {
            return string.Format("[Screen: Height={0}, Width={1}, Xdpi={2:0.0}, Ydpi={3:0.0}]", Height, Width, Xdpi, Ydpi);
        }
    }
}

