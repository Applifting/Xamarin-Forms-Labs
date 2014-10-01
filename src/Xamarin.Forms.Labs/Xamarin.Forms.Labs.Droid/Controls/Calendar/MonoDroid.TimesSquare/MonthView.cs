using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Xamarin.Forms.Labs.Droid.Controls.Calendar
{
    public class MonthView : LinearLayout
    {
        private TextView _title;
        private CalendarGridView _grid;
        private ClickHandler _clickHandler;

        public MonthView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public static MonthView Create(ViewGroup parent, LayoutInflater inflater, string weekdayNameFormat,
                                       DateTime today, ClickHandler handler)
        {
            var view = (MonthView)inflater.Inflate(Resource.Layout.month, parent, false);

            var originalDay = today;

            var firstDayOfWeek = (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;

            var headerRow = (CalendarRowView)view._grid.GetChildAt(0);

            for(int i = 0; i < 7; i++)
            {
                var offset = firstDayOfWeek - (int)today.DayOfWeek + i;
                today = today.AddDays(offset);
                var textView = (TextView)headerRow.GetChildAt(i);
                textView.Text = today.ToString(weekdayNameFormat);
                today = originalDay;
            }
            view._clickHandler = handler;
            return view;
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            Logr.D("Month.OnMeasure w={0} h={1}", MeasureSpec.ToString(widthMeasureSpec),
                MeasureSpec.ToString(heightMeasureSpec));
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }

        public void Init(MonthDescriptor month, List<List<MonthCellDescriptor>> cells)
        {
            Logr.D("Initializing MonthView ({0:d}) for {1}", GetHashCode(), month);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
            _title.Text = month.Label;
            if(_title.Typeface != null)
            {
                _title.Typeface = month.Style.MonthTitleFont;
            }
            _title.SetTextColor(month.Style.TitleForegroundColor);
            _title.SetBackgroundColor(month.Style.TitleBackgroundColor);

            _grid.DividerColor = month.Style.DateSeparatorColor;

            var headerRow = (CalendarRowView)_grid.GetChildAt(0);
            if(headerRow != null)
            {
                headerRow.SetBackgroundColor(month.Style.DayOfWeekLabelBackgroundColor);
                var week = cells[0];
                for(int c = 0; c <= 6; c++)
                {

                    var headerText = (TextView)headerRow.GetChildAt(c);
                    if(month.Style.ShouldHighlightDaysOfWeekLabel && week[c].IsHighlighted)
                    {
                        headerText.SetBackgroundColor(month.Style.HighlightedDateBackgroundColor);
                    }
                    headerText.SetTextColor(month.Style.DayOfWeekLabelForegroundColor);
                }
            }

            int numOfRows = cells.Count;
            _grid.NumRows = numOfRows;
            for(int i = 0; i < 6; i++)
            {
                var weekRow = (CalendarRowView)_grid.GetChildAt(i + 1);
                weekRow.ClickHandler = _clickHandler;
                if(i < numOfRows)
                {
                    weekRow.Visibility = ViewStates.Visible;
                    var week = cells[i];
                    for(int c = 0; c < week.Count; c++)
                    {
                        var cell = week[c];
                        var cellView = (CalendarCellView)weekRow.GetChildAt(c);

                        cellView.Text = cell.Value.ToString();
                        cellView.Enabled = cell.IsCurrentMonth;
                        cellView.Selectable = cell.IsSelectable;
                        cellView.Selected = cell.IsSelected;
                        cellView.IsCurrentMonth = cell.IsCurrentMonth;
                        cellView.IsToday = cell.IsToday;
                        cellView.IsHighlighted = cell.IsHighlighted;
                        cellView.RangeState = cell.RangeState;
                        cellView.Tag = cell;
                        cellView.SetStyle(month.Style);
                        //Logr.D("Setting cell at {0} ms", stopWatch.ElapsedMilliseconds);
                    }
                } else
                {
                    weekRow.Visibility = ViewStates.Gone;
                }
            }
            stopWatch.Stop();
            Logr.D("MonthView.Init took {0} ms", stopWatch.ElapsedMilliseconds);
        }

        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();
            _title = FindViewById<TextView>(Resource.Id.title);
            _grid = FindViewById<CalendarGridView>(Resource.Id.calendar_grid);
        }
    }
}