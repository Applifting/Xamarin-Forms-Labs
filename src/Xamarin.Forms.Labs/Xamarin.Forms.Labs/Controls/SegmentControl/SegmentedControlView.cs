using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace Xamarin.Forms.Labs.Controls
{
    public class SegmentedControlView : BoxView
    {

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create<SegmentedControlView, int>(
                p => p.SelectedItem, default(int));

        public int SelectedItem
        {
            get { return (int)GetValue(SelectedItemProperty); }
            set
            {
                Debug.WriteLine("New Value:" + value);
                SetValue(SelectedItemProperty, value);
            }
        }

        public static readonly BindableProperty SegmentsItensProperty =
            BindableProperty.Create<SegmentedControlView, string>(
                p => p.SegmentsItens, default(string));

        public string SegmentsItens
        {
            get { return (string)GetValue(SegmentsItensProperty); }
            set
            {
                Debug.WriteLine("New Seg Value:" + value);
                SetValue(SegmentsItensProperty, value);
            }
        }

        public static readonly BindableProperty TintColorProperty =
            BindableProperty.Create<SegmentedControlView, Color>(
                p => p.TintColor, Color.Blue);

        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set
            {
                Debug.WriteLine("New TintColor Value:" + value);
                SetValue(TintColorProperty, value);
            }
        }

		/// <summary>
		/// The checked changed event.
		/// </summary>
		public event EventHandler<EventArgs<int>> SelectedChanged;



		public void InvokeOnSelectedChanged(){
			if(SelectedChanged != null){
				SelectedChanged(this, new EventArgs<int>(SelectedItem));
			}
		}

    }
}
