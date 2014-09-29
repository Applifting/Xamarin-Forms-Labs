using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using MonoTouch.UIKit;
using System.Drawing;
using Xamarin.Forms.Labs.iOS.Controls;
using Xamarin.Forms.Labs.Controls;

[assembly: ExportRenderer (typeof (SegmentedControlView), typeof (SegmentedControlViewRenderer))]

namespace Xamarin.Forms.Labs.iOS.Controls
{
    public class SegmentedControlViewRenderer : ViewRenderer<SegmentedControlView , UISegmentedControl>
	{
		//
		// Methods
		//
		protected override void Dispose (bool disposing)
		{
			if (disposing) {
				base.Control.ValueChanged -= new EventHandler (this.HandleControlValueChanged);

			}
			base.Dispose (disposing);
		}

		private void HandleControlValueChanged (object sender, EventArgs e)
		{
			base.Element.SelectedItem = base.Control.SelectedSegment;
			base.Element.InvokeOnSelectedChanged();
		}



		protected override void OnElementChanged (ElementChangedEventArgs<SegmentedControlView> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {   
				// perform initial setup
				var native = new UISegmentedControl (RectangleF.Empty);
			
				var segments = this.Element.SegmentsItens.Split (';');


				for (int i = 0; i < segments.Length; i++) {
					native.InsertSegment (segments[i], i, false);
				}

				native.TintColor = this.Element.TintColor.ToUIColor();
				native.SelectedSegment = 0;

				base.SetNativeControl (native);

				base.Control.ValueChanged += new EventHandler (this.HandleControlValueChanged);
			}
		}
	}
}

