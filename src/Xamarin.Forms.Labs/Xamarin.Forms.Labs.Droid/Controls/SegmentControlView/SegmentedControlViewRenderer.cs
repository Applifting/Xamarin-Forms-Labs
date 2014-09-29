using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;
using Xamarin.Forms.Labs.Droid.Controls;
using Xamarin.Forms.Platform.Android;
using Android.Views;


[assembly: ExportRenderer (typeof (SegmentedControlView), typeof (SegmentedControlViewRenderer))]
namespace Xamarin.Forms.Labs.Droid.Controls
{
	public class SegmentedControlViewRenderer : ViewRenderer<SegmentedControlView , SegmentedGroup>
	{
		bool _isElementChanging;
		private void ProtectFromEventCycle(Action action){
			if(_isElementChanging == false){
				_isElementChanging = true;
				action.Invoke();
				_isElementChanging = false;
			}
		}

		public SegmentedControlViewRenderer()
		{
		}


		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				this.Control.CheckedChange -= HandleCheckedChange;
			}
			base.Dispose(disposing);

		}

		void HandleCheckedChange (object sender, Android.Widget.RadioGroup.CheckedChangeEventArgs e)
		{
			ProtectFromEventCycle(() => {
				base.Element.SelectedItem = e.CheckedId;
				Element.InvokeOnSelectedChanged();
			});
		}


		protected override void OnElementChanged(ElementChangedEventArgs<SegmentedControlView> e)
		{

			base.OnElementChanged(e);

			if(e.NewElement != null && Control == null){
				var control = new SegmentedGroup(Context);
				control.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
				control.SetGravity(GravityFlags.Center);

				control.Orientation = Android.Widget.Orientation.Horizontal;

				if(e.NewElement.SegmentsItens != null) {
					foreach(string segmentText in e.NewElement.SegmentsItens.Split(';')) {
						LayoutInflater inflatorservice =
							(LayoutInflater)Context.GetSystemService(Android.Content.Context.LayoutInflaterService);
						var radioButton = (Android.Widget.RadioButton)inflatorservice.Inflate(Resource.Drawable.radio_button_item,null);
						//radioButton.LayoutParameters = new Android.Widget.RadioGroup.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent,1);
						radioButton.Text = segmentText;
						control.AddView(radioButton);
						this.Control.CheckedChange += HandleCheckedChange;
					}
				}

				SetNativeControl(control);

			}
		}

		protected override void OnAttachedToWindow()
		{
			base.OnAttachedToWindow();
			Control.UpdateBackground();
//			for(int i = 0; i < Control.ChildCount; i++) {
//				var child = Control.GetChildAt(i);
//
//			}
		}

	


	}
}

