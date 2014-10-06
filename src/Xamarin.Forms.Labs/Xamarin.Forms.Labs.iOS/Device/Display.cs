using System;
using MonoTouch.UIKit;
using Xamarin.Forms.Labs.iOS.Services;
using Xamarin.Forms.Labs.Services;

namespace Xamarin.Forms.Labs
{
    /// <summary>
    /// Apple Display class.
    /// </summary>
    public class Display : IDisplay
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Xamarin.Forms.Labs.Display"/> class.
        /// </summary>
        /// <param name="height">Height in pixels.</param>
        /// <param name="width">Width in pixels.</param>
        /// <param name="xdpi">Pixel density for X.</param>
        /// <param name="ydpi">Pixel density for  Y.</param>
        internal Display (int height, int width, double xdpi, double ydpi)
        {
            this.Height = height;
            this.Width = width;
            this.Xdpi = xdpi;
            this.Ydpi = ydpi;

            this.FontManager = new FontManager(this);
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

        public int DipHeight {
            get {
                return (int)Math.Round(Height / UIScreen.MainScreen.Scale);
            }
        }

        public int DipWidth {
            get {
                return (int)Math.Round(Width / UIScreen.MainScreen.Scale);
            }
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
            return inches * this.Xdpi / UIScreen.MainScreen.Scale;
        }

        /// <summary>
        /// Convert height in inches to runtime pixels
        /// </summary>
        public double HeightRequestInInches(double inches)
        {
            return inches * this.Ydpi / UIScreen.MainScreen.Scale;
        }

        #endregion
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="Xamarin.Forms.Labs.Display"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="Xamarin.Forms.Labs.Display"/>.</returns>
        public override string ToString()
        {
            return string.Format("[Screen: Height={0}, Width={1}, Xdpi={2}, Ydpi={3}]", Height, Width, Xdpi, Ydpi);
        }
    }
}

