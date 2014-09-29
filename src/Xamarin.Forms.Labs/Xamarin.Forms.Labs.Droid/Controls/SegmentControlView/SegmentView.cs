using System;
using Android.Widget;
using Android.Content;
using Android.Util;


namespace Xamarin.Forms.Labs.Droid.Controls
{
	public class SegmentView : RadioButton
	{
		public SegmentView(Context context) : base(context)
		{

		}


		public SegmentView(Context context, IAttributeSet attrs):base(context,attrs){

		}

		public SegmentView(IntPtr javaReference,Android.Runtime.JniHandleOwnership transfer): base(javaReference,transfer){

		}

		protected override void DrawableStateChanged()
		{
			base.DrawableStateChanged();
			this.Text = this.Text;
		}
			




	}
}

