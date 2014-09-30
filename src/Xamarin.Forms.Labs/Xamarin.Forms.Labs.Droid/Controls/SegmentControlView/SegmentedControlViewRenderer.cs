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
				var radioButton = Control.FindViewById( e.CheckedId);
				int idx = Control.IndexOfChild(radioButton);
				base.Element.SelectedItem = idx;
				Element.InvokeOnSelectedChanged();
			});
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			this.ProtectFromEventCycle(() => {
				if(Control != null){
					if(e.PropertyName == SegmentedControlView.SelectedItemProperty.PropertyName){
						SetSelectedValue(Element.SelectedItem);
					}
				}
			});
		}

		private void SetSelectedValue(int value){
			if(value == -1){
				Control.ClearCheck();
			}else{
				Control.Check(Control.GetChildAt(value).Id);
			}
		}


		protected override void OnElementChanged(ElementChangedEventArgs<SegmentedControlView> e)
		{

			base.OnElementChanged(e);

			if(e.NewElement != null && Control == null){
				var control = new SegmentedGroup(Context);
				control.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
				control.SetGravity(GravityFlags.Center);
				control.TintColor = e.NewElement.TintColor.ToAndroid();
				control.Orientation = Android.Widget.Orientation.Horizontal;
				control.CheckedChange += HandleCheckedChange;

				if(e.NewElement.SegmentsItens != null) {
					LayoutInflater inflatorservice =
						(LayoutInflater)Context.GetSystemService(Android.Content.Context.LayoutInflaterService);
					foreach(string segmentText in e.NewElement.SegmentsItens.Split(';')) {
						var radioButton = (Android.Widget.RadioButton)inflatorservice.Inflate(Resource.Drawable.radio_button_item,null);
						//radioButton.LayoutParameters = new Android.Widget.RadioGroup.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent,1);
						control.AddView(radioButton);
						radioButton.Text = segmentText;


					}
				}

				SetNativeControl(control);
				SetSelectedValue(e.NewElement.SelectedItem);
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

