using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace Xamarin.Forms.Labs.Controls
{
    public class CalendarView : View
    {
		public enum BackgroundStyle{
			Fill,
			CircleFill,
			CircleOutline
		}

		/**
		 * SelectedDate property
		 */
		public static readonly BindableProperty MinDateProperty = 
			BindableProperty.Create(
				"MinDate",
				typeof(DateTime),
				typeof(CalendarView),
				FirstDayOfMonth(DateTime.Today),
				BindingMode.OneWay,
				null, null, null, null);


		public DateTime  MinDate {
			get {
				return (DateTime)base.GetValue(CalendarView.MinDateProperty);
			}
			set {

				base.SetValue(CalendarView.MinDateProperty, value);
			}
		}

		public static readonly BindableProperty MaxDateProperty = 
			BindableProperty.Create(
				"MaxDate",
				typeof(DateTime),
				typeof(CalendarView),
				LastDayOfMonth(DateTime.Today),
				BindingMode.OneWay,
				null, null, null, null);


		public DateTime  MaxDate {
			get {
				return (DateTime)base.GetValue(CalendarView.MaxDateProperty);
			}
			set {
				base.SetValue(CalendarView.MaxDateProperty, value);
			}
		}
		//Helper method
		public static DateTime FirstDayOfMonth(DateTime date)
		{
            return date.AddDays(1-date.Day).Date;
		}
		//Helper method
		public static DateTime LastDayOfMonth(DateTime date)
		{
			return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
		}



		/**
		 * SelectedDate property
		 */
		public static readonly BindableProperty SelectedDateProperty = 
			BindableProperty.Create(
				"SelectedDate",
				typeof(DateTime?),
				typeof(CalendarView),
				null,
				BindingMode.TwoWay,
				null, null, null, null);


		public DateTime?  SelectedDate {
			get {
				return (DateTime?)base.GetValue(CalendarView.SelectedDateProperty);
			}
			set {
				base.SetValue(CalendarView.SelectedDateProperty, value);
			}
		}

		/**
		 * Displayed date property
		 */
		public static readonly BindableProperty DisplayedMonthProperty = 
			BindableProperty.Create(
				"DisplayedMonth",
				typeof(DateTime),
				typeof(CalendarView),
				DateTime.Now,
				BindingMode.TwoWay,
				null, null, null, null);


		public DateTime  DisplayedMonth {
			get {
				return (DateTime)base.GetValue(CalendarView.DisplayedMonthProperty);
			}
			set {
				base.SetValue(CalendarView.DisplayedMonthProperty, value);
			}
		}


		/**
		 * DateLabelFont property
		 */
		public static readonly BindableProperty DateLabelFontProperty = BindableProperty.Create("DateLabelFont", typeof(Font), typeof(CalendarView), Font.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Font used by the calendar dates and day labels
		 */
		public Font DateLabelFont {
			get {
				return (Font)base.GetValue(CalendarView.DateLabelFontProperty);
			}
			set {
				base.SetValue(CalendarView.DateLabelFontProperty, value);
			}
		}


		/**
		 * Font property
		 */
		public static readonly BindableProperty MonthTitleFontProperty = BindableProperty.Create("MonthTitleFont", typeof(Font), typeof(CalendarView), Font.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Font used by the month title
		 */
		public Font MonthTitleFont {
			get {
				return (Font)base.GetValue(CalendarView.MonthTitleFontProperty);
			}
			set {
				base.SetValue(CalendarView.MonthTitleFontProperty, value);
			}
		}




		/**
		 * TextColorProperty property
		 */
		public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Overall text color property. Default color is platform specific.
		 */
		public Color TextColor {
			get {
				return (Color)base.GetValue(CalendarView.TextColorProperty);
			}
			set {
				base.SetValue(CalendarView.TextColorProperty, value);
			}
		}

		/**
		 * TodayDateForegroundColorProperty property
		 */
		public static readonly BindableProperty TodayDateForegroundColorProperty = BindableProperty.Create("TodayDateForegroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Foreground color of today date. Default color is platform specific.
		 */
		public Color TodayDateForegroundColor {
			get {
				return (Color)base.GetValue(CalendarView.TodayDateForegroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.TodayDateForegroundColorProperty, value);
			}
		}

		/**
		 * TodayDateBackgroundColorProperty property
		 */
		public static readonly BindableProperty TodayDateBackgroundColorProperty = BindableProperty.Create("TodayDateBackgroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Background color of today date. Default color is platform specific.
		 */
		public Color TodayDateBackgroundColor {
			get {
				return (Color)base.GetValue(CalendarView.TodayDateBackgroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.TodayDateBackgroundColorProperty, value);
			}
		}

		/**
		 * DateForegroundColorProperty property
		 */
		public static readonly BindableProperty DateForegroundColorProperty = BindableProperty.Create("DateForegroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Foreground color of date in the calendar. Default color is platform specific.
		 */
		public Color DateForegroundColor {
			get {
				return (Color)base.GetValue(CalendarView.DateForegroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.DateForegroundColorProperty, value);
			}
		}

		/**
		 * DateBackgroundColorProperty property
		 */
		public static readonly BindableProperty DateBackgroundColorProperty = BindableProperty.Create("DateBackgroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Background color of date in the calendar. Default color is platform specific.
		 */
		public Color DateBackgroundColor {
			get {
				return (Color)base.GetValue(CalendarView.DateBackgroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.DateBackgroundColorProperty, value);
			}
		}


		/**
		 * InactiveDateForegroundColorProperty property
		 */
		public static readonly BindableProperty InactiveDateForegroundColorProperty = BindableProperty.Create("InactiveDateForegroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Foreground color of date in the calendar which is outside of the current month. Default color is platform specific.
		 */
		public Color InactiveDateForegroundColor {
			get {
				return (Color)base.GetValue(CalendarView.InactiveDateForegroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.InactiveDateForegroundColorProperty, value);
			}
		}

		/**
		 * InactiveDateBackgroundColorProperty property
		 */
		public static readonly BindableProperty InactiveDateBackgroundColorProperty = BindableProperty.Create("InactiveDateBackgroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Background color of date in the calendar  which is outside of the current month. Default color is platform specific.
		 */
		public Color InactiveDateBackgroundColor {
			get {
				return (Color)base.GetValue(CalendarView.InactiveDateBackgroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.InactiveDateBackgroundColorProperty, value);
			}
		}


		/**
		 * HighlightedDateForegroundColorProperty property
		 */
		public static readonly BindableProperty HighlightedDateForegroundColorProperty = BindableProperty.Create("HighlightedDateForegroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Foreground color of highlighted date in the calendar. Default color is platform specific.
		 */
		public Color HighlightedDateForegroundColor {
			get {
				return (Color)base.GetValue(CalendarView.HighlightedDateForegroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.HighlightedDateForegroundColorProperty, value);
			}
		}
		/**
		 * HighlightedDateBackgroundColor property
		 */
		public static readonly BindableProperty HighlightedDateBackgroundColorProperty = BindableProperty.Create("HighlightedDateBackgroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Background color of selected date in the calendar. Default color is platform specific.
		 */
		public Color HighlightedDateBackgroundColor {
			get {
				return (Color)base.GetValue(CalendarView.HighlightedDateBackgroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.HighlightedDateBackgroundColorProperty, value);
			}
		}


		/**
		 * TodayBackgroundStyle property
		 */
		public static readonly BindableProperty TodayBackgroundStyleProperty = BindableProperty.Create("TodayBackgroundStyle", typeof(BackgroundStyle), typeof(CalendarView), BackgroundStyle.Fill, BindingMode.OneWay, null, null, null, null);

		/**
		 * Background style for today cell. It is only respected on iOS for now.
		 */
		public BackgroundStyle TodayBackgroundStyle {
			get {
				return (BackgroundStyle)base.GetValue(CalendarView.TodayBackgroundStyleProperty);
			}
			set {
				base.SetValue(CalendarView.TodayBackgroundStyleProperty, value);
			}
		}


		/**
		 * SelectionBackgroundStyle property
		 */
		public static readonly BindableProperty SelectionBackgroundStyleProperty = BindableProperty.Create("SelectionBackgroundStyle", typeof(BackgroundStyle), typeof(CalendarView), BackgroundStyle.Fill, BindingMode.OneWay, null, null, null, null);

		/**
		 * Background style for selecting the cells. It is only respected on iOS for now.
		 */
		public BackgroundStyle SelectionBackgroundStyle {
			get {
				return (BackgroundStyle)base.GetValue(CalendarView.SelectionBackgroundStyleProperty);
			}
			set {
				base.SetValue(CalendarView.SelectionBackgroundStyleProperty, value);
			}
		}


		/**
		 * SelectedDateForegroundColorProperty property
		 */
		public static readonly BindableProperty SelectedDateForegroundColorProperty = BindableProperty.Create("SelectedDateForegroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Foreground color of selected date in the calendar. Default color is platform specific.
		 */
		public Color SelectedDateForegroundColor {
			get {
				return (Color)base.GetValue(CalendarView.SelectedDateForegroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.SelectedDateForegroundColorProperty, value);
			}
		}

		/**
		 * DateBackgroundColorProperty property
		 */
		public static readonly BindableProperty SelectedDateBackgroundColorProperty = BindableProperty.Create("SelectedDateBackgroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Background color of selected date in the calendar. Default color is platform specific.
		 */
		public Color SelectedDateBackgroundColor {
			get {
				return (Color)base.GetValue(CalendarView.SelectedDateBackgroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.SelectedDateBackgroundColorProperty, value);
			}
		}



		/**
		 * DayOfWeekLabelForegroundColorProperty property
		 */
		public static readonly BindableProperty DayOfWeekLabelForegroundColorProperty = BindableProperty.Create("DayOfWeekLabelForegroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Foreground color of week day labels in the month header. Default color is platform specific.
		 */
		public Color DayOfWeekLabelForegroundColor {
			get {
				return (Color)base.GetValue(CalendarView.DayOfWeekLabelForegroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.DayOfWeekLabelForegroundColorProperty, value);
			}
		}
		/**
		 * DayOfWeekLabelForegroundColorProperty property
		 */
		public static readonly BindableProperty DayOfWeekLabelBackgroundColorProperty = BindableProperty.Create("DayOfWeekLabelBackgroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Background color of week day labels in the month header. Default color is platform specific.
		 */
		public Color DayOfWeekLabelBackgroundColor {
			get {
				return (Color)base.GetValue(CalendarView.DayOfWeekLabelBackgroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.DayOfWeekLabelBackgroundColorProperty, value);
			}
		}



		/**
		 * DayOfWeekLabelForegroundColorProperty property
		 */
		public static readonly BindableProperty MonthTitleForegroundColorProperty = BindableProperty.Create("MonthTitleForegroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Foreground color of week day labels in the month header. Default color is platform specific.
		 */
		public Color MonthTitleForegroundColor {
			get {
				return (Color)base.GetValue(CalendarView.MonthTitleForegroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.MonthTitleForegroundColorProperty, value);
			}
		}


		/**
		 * DayOfWeekLabelForegroundColorProperty property
		 */
		public static readonly BindableProperty MonthTitleBackgroundColorProperty = BindableProperty.Create("MonthTitleBackgroundColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Background color of week day labels in the month header. Default color is platform specific.
		 */
		public Color MonthTitleBackgroundColor {
			get {
				return (Color)base.GetValue(CalendarView.MonthTitleBackgroundColorProperty);
			}
			set {
				base.SetValue(CalendarView.MonthTitleBackgroundColorProperty, value);
			}
		}

		/**
		 * DateSeparatorColorProperty property
		 */
		public static readonly BindableProperty DateSeparatorColorProperty = BindableProperty.Create("DateSeparatorColor", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Color of separator between dates. Default color is platform specific.
		 */
		public Color DateSeparatorColor {
			get {
				return (Color)base.GetValue(CalendarView.DateSeparatorColorProperty);
			}
			set {
				base.SetValue(CalendarView.DateSeparatorColorProperty, value);
			}
		}



		/**
		 * ShowNavigationArrowsProperty property
		 */
		public static readonly BindableProperty ShowNavigationArrowsProperty = BindableProperty.Create("ShowNavigationArrows", typeof(bool), typeof(CalendarView), false, BindingMode.OneWay, null, null, null, null);

		/**
		 * Whether to show navigation arrows for going through months. The navigation arrows 
		 */
		public bool ShowNavigationArrows {
			get {
				return (bool)base.GetValue(CalendarView.ShowNavigationArrowsProperty);
			}
			set {
				base.SetValue(CalendarView.ShowNavigationArrowsProperty, value);
			}
		}

		/**
		 * NavigationArrowsColorProperty property
		 */
		public static readonly BindableProperty NavigationArrowsColorProperty = BindableProperty.Create("NavigationArrowsColorProperty", typeof(Color), typeof(CalendarView), Color.Default, BindingMode.OneWay, null, null, null, null);

		/**
		 * Color of the navigation colors (if shown). Default color is platform specific
		 */
		public Color NavigationArrowsColor {
			get {
				return (Color)base.GetValue(CalendarView.NavigationArrowsColorProperty);
			}
			set {
				base.SetValue(CalendarView.NavigationArrowsColorProperty, value);
			}
		}


		/**
		 * ShouldHighlightDaysOfWeekLabelsProperty property
		 */
		public static readonly BindableProperty ShouldHighlightDaysOfWeekLabelsProperty = BindableProperty.Create("ShouldHighlightDaysOfWeekLabels", typeof(bool), typeof(CalendarView), false, BindingMode.OneWay, null, null, null, null);

		/**
		 * Whether to highlight also the labels of week days when the entire column is highlighted.
		 */
		public bool ShouldHighlightDaysOfWeekLabels {
			get {
				return (bool)base.GetValue(CalendarView.ShouldHighlightDaysOfWeekLabelsProperty);
			}
			set {
				base.SetValue(CalendarView.ShouldHighlightDaysOfWeekLabelsProperty, value);
			}
		}



		/**
		 * HighlightedDaysOfWeekProperty property
		 */
		public static readonly BindableProperty HighlightedDaysOfWeekProperty = BindableProperty.Create("HighlightedDaysOfWeek", typeof(DayOfWeek[]), typeof(CalendarView), new DayOfWeek[]{}, BindingMode.OneWay, null, null, null, null);

		/**
		 * Background color of selected date in the calendar. Default color is platform specific.
		 */
		public DayOfWeek[] HighlightedDaysOfWeek {
			get {
				return (DayOfWeek[])base.GetValue(CalendarView.HighlightedDaysOfWeekProperty);
			}
			set {
				base.SetValue(CalendarView.HighlightedDaysOfWeekProperty, value);
			}
		}



	

		#region ColorHelperProperties

		public Color ActualDateBackgroundColor{
			get{
				return this.DateBackgroundColor;
			}

		}

		public Color ActualDateForegroundColor{
			get{
				if(this.DateForegroundColor != Color.Default) {
					return this.DateForegroundColor;
				}
				return this.TextColor;
			}
		} 

		public Color ActualInactiveDateBackgroundColor{
			get{
				if(this.InactiveDateBackgroundColor != Color.Default) {
					return this.InactiveDateBackgroundColor;
				}
				return this.ActualDateBackgroundColor;
			}

		}

		public Color ActualInactiveDateForegroundColor{
			get{
				if(this.InactiveDateForegroundColor != Color.Default) {
					return this.InactiveDateForegroundColor;
				}
				return this.ActualDateForegroundColor;
			}
		} 

		public Color ActualTodayDateForegroundColor{
			get{
				if(this.TodayDateForegroundColor != Color.Default) {
					return this.TodayDateForegroundColor;
				}
				return this.ActualDateForegroundColor;
			}
		} 
		public Color ActualTodayDateBackgroundColor{
			get{
				if(this.TodayDateBackgroundColor != Color.Default) {
					return this.TodayDateBackgroundColor;
				}
				return this.ActualDateBackgroundColor;
			}
		} 

		public Color ActualSelectedDateForegroundColor{
			get{
				if(this.SelectedDateForegroundColor != Color.Default){
					return this.SelectedDateForegroundColor;
				}
				return this.ActualDateForegroundColor;
			}
		}

		public Color ActualSelectedDateBackgroundColor{
			get{
				if(this.SelectedDateBackgroundColor != Color.Default){
					return this.SelectedDateBackgroundColor;
				}
				return this.ActualDateBackgroundColor;
			}
		}

		public Color ActualMonthTitleForegroundColor{
			get{
				if(this.MonthTitleForegroundColor != Color.Default){
					return MonthTitleForegroundColor;
				}
				return this.TextColor;
			}
		}

		public Color ActualMonthTitleBackgroundColor{
			get{
				if(this.MonthTitleBackgroundColor != Color.Default){
					return MonthTitleBackgroundColor;
				}
				return this.BackgroundColor;
			}
		}

		public Color ActualDayOfWeekLabelForegroundColor{
			get{
				if(this.DayOfWeekLabelForegroundColor != Color.Default){
					return DayOfWeekLabelForegroundColor;
				}
				return this.TextColor;
			}
		}

		public Color ActualDayOfWeekLabelBackroundColor{
			get{
				if(this.DayOfWeekLabelBackgroundColor != Color.Default){
					return DayOfWeekLabelBackgroundColor;
				}
				return this.BackgroundColor;
			}
		}

		public Color ActualNavigationArrowsColor{
			get{
				if(this.NavigationArrowsColor != Color.Default){
					return NavigationArrowsColor;
				}
				return this.ActualMonthTitleForegroundColor;
			}
		}

		public Color ActualHighlightedDateForegroundColor{
			get{
				return HighlightedDateForegroundColor;
			}
		}

		public Color ActualHighlightedDateBackgroundColor{
			get{
				return HighlightedDateBackgroundColor;
			}
		}
		#endregion



		public CalendarView()
		{
			if(Device.OS == TargetPlatform.iOS){
				HeightRequest = 198 + 20; //This is the size of the original iOS calendar
			}else if(Device.OS == TargetPlatform.Android){
				HeightRequest = 300; //This is the size in which Android calendar renders comfortably on most devices
			}

		}

		public void NotifyDisplayedMonthChanged(DateTime date)
		{
			DisplayedMonth = date;
			if (MonthChanged != null)
				MonthChanged(this, date);
		}
		public event EventHandler<DateTime> MonthChanged;


		public void NotifyDateSelected(DateTime dateSelected)
		{
			SelectedDate = dateSelected;
			if (DateSelected != null)
				DateSelected(this, dateSelected);
		}

		public event EventHandler<DateTime> DateSelected;



    }
}
