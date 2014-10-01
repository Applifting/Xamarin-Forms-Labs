using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using System;

namespace Xamarin.Forms.Labs.Droid.Controls.Calendar
{
    public class CalendarCellView : TextView
    {

        private bool _isSelectable;
        private bool _isCurrentMonth;
        private bool _isToday;
        private bool _isHighlighted;
        private RangeState _rangeState = RangeState.None;

        public CalendarCellView(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }

        public CalendarCellView(Context context)
            : base(context)
        {
        }

        public CalendarCellView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public CalendarCellView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        public bool Selectable {
            set {
                _isSelectable = value;
            }
        }

        public bool IsCurrentMonth {
            set {
                _isCurrentMonth = value;
            }
        }

        public bool IsToday {
            set {
                _isToday = value;
            }
        }

        public bool IsHighlighted {
            set {
                _isHighlighted = value;
            }
        }

        public RangeState RangeState {
            set {
                _rangeState = value;
            }
        }

        public void SetStyle(StyleDescriptor style)
        {
            if(style.DateLabelFont != null)
            {
                this.Typeface = (style.DateLabelFont);
            }
            if(this.Selected)
            {
                SetBackgroundColor(style.SelectedDateBackgroundColor);
                SetTextColor(style.SelectedDateForegroundColor);
            } else if(_isToday)
            {
                SetBackgroundColor(style.TodayBackgroundColor);
                SetTextColor(style.TodayForegroundColor);
            } else if(_isHighlighted)
            {
                SetBackgroundColor(style.HighlightedDateBackgroundColor);
                if(_isCurrentMonth)
                {
                    SetTextColor(style.HighlightedDateForegroundColor);
                } else
                {
                    SetTextColor(style.InactiveDateForegroundColor);
                }
            } else if(!_isCurrentMonth)
            {
                SetBackgroundColor(style.InactiveDateBackgroundColor);
                SetTextColor(style.InactiveDateForegroundColor);
            } else
            {
                SetBackgroundColor(style.DateBackgroundColor);
                SetTextColor(style.DateForegroundColor);
            }
        }


    }
}
