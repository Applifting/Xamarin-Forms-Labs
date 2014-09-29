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
		bool _isElementChanging;
		private void ProtectFromEventCycle(Action action){
			if(_isElementChanging == false){
				_isElementChanging = true;
				action.Invoke();
				_isElementChanging = false;
			}
		}

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
			this.ProtectFromEventCycle(() => {
				base.Element.SelectedItem = base.Control.SelectedSegment;
				base.Element.InvokeOnSelectedChanged();
			});
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			this.ProtectFromEventCycle(() => {
				if(e.PropertyName == SegmentedControlView.SelectedItemProperty.PropertyName){
					SelectSegment(Element.SelectedItem);
				}
			});

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


				base.SetNativeControl (native);
				SelectSegment(this.Element.SelectedItem);
				base.Control.ValueChanged += new EventHandler (this.HandleControlValueChanged);
			}
		}


		private void SelectSegment(int segment){
		
			if(segment >= 0){
				Control.SelectedSegment = segment;
			}else{
				Control.SelectedSegment = -1;
			}
		}
	}
}

