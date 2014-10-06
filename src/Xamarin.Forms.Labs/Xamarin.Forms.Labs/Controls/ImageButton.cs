using Xamarin.Forms.Labs.Enums;

namespace Xamarin.Forms.Labs.Controls
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Creates a button with text and an image.
    /// The image can be on the left, above, on the right or below the text.
    /// </summary>
    public class ImageButton : Button
    {
        /// <summary>
        /// Backing field for the Image property.
        /// </summary>
        public static readonly BindableProperty SourceProperty = BindableProperty.Create<ImageButton, ImageSource>((Expression<Func<ImageButton, ImageSource>>)(w => w.Source), (ImageSource)null, BindingMode.OneWay, (BindableProperty.ValidateValueDelegate<ImageSource>)null, (BindableProperty.BindingPropertyChangedDelegate<ImageSource>)((bindable, oldvalue, newvalue) => ((VisualElement)bindable).ToString()), (BindableProperty.BindingPropertyChangingDelegate<ImageSource>)null, (BindableProperty.CoerceValueDelegate<ImageSource>)null);

        /// <summary>
        /// Gets or sets the ImageSource to use with the control.
        /// </summary>
        /// <value>
        /// The Source property gets/sets the value of the backing field, SourceProperty.
        /// </value>
        [TypeConverter(typeof(ImageSourceConverter))]
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        /// <summary>
        /// Backing field for the orientation property.
        /// </summary>
        public static readonly BindableProperty OrientationProperty =
            BindableProperty.Create<ImageButton, ImageOrientation>(
                p => p.Orientation, ImageOrientation.ImageToLeft);

        /// <summary>
        /// Gets or sets The orientation of the image relative to the text.
        /// </summary> 
        /// <value>
        /// The Orientation property gets/sets the value of the backing field, OrientationProperty.
        /// </value> 
        public ImageOrientation Orientation
        {
            get { return (ImageOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        /// <summary>
        /// Backing field for the image height property.
        /// </summary>
        public static readonly BindableProperty ImageHeightRequestProperty =
            BindableProperty.Create<ImageButton, int>(
                p => p.ImageHeightRequest, default(int));

        /// <summary>
        /// Gets or sets the requested height of the image.  If less than or equal to zero than a 
        /// height of 50 will be used.
        /// </summary>
        /// <value>
        /// The ImageHeightRequest property gets/sets the value of the backing field, ImageHeightRequestProperty.
        /// </value> 
        public int ImageHeightRequest
        {
            get { return (int)GetValue(ImageHeightRequestProperty); }
            set { SetValue(ImageHeightRequestProperty, value); }
        }

        /// <summary>
        /// Backing field for the image width property.
        /// </summary>
        public static readonly BindableProperty ImageWidthRequestProperty =
           BindableProperty.Create<ImageButton, int>(
               p => p.ImageWidthRequest, default(int));

        /// <summary>
        /// Gets or sets the requested width of the image.  If less than or equal to zero than a 
        /// width of 50 will be used.
        /// </summary>
        /// <value>
        /// The ImageHeightRequest property gets/sets the value of the backing field, ImageHeightRequestProperty.
        /// </value> 
        public int ImageWidthRequest
        {
            get { return (int)GetValue(ImageWidthRequestProperty); }
            set { SetValue(ImageWidthRequestProperty, value); }
        }


        /// <summary>
        /// Backing field for the padding property.
        /// </summary>
        public static readonly BindableProperty PaddingProperty =
            BindableProperty.Create<ImageButton, Thickness>(
                p => p.Padding, new Thickness(0));

        /// <summary>
        /// Gets or sets the requested padding for the content of the button.  
        /// </summary>
        /// <value>
                /// The Padding property gets/sets the value of the backing field, PaddingProperty.
        /// </value> 
        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        /// <summary>
        /// Backing field for the ImageToTextSpacing property.
        /// </summary>
        public static readonly BindableProperty ImageToTextSpacingProperty =
            BindableProperty.Create<ImageButton, float>(
                p => p.ImageToTextSpacing, 2);

        /// <summary>
        /// Gets or sets the requested space between text and the picture of the button.  
        /// </summary>
        /// <value>
        /// The Padding property gets/sets the value of the backing field, ImageToTextSpacingProperty.
        /// </value> 
        public float ImageToTextSpacing
        {
            get { return (float)GetValue(ImageToTextSpacingProperty); }
            set { SetValue(ImageToTextSpacingProperty, value); }
        }
    }
}