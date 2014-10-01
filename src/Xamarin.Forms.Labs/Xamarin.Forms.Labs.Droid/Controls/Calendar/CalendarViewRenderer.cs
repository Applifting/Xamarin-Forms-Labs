using Android.Views;
using Android.Widget;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Labs.Droid.Controls.Calendar;
using XamLabsControls = Xamarin.Forms.Labs.Controls;
using Android.Renderscripts;
using Android.Support.V4.View;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Labs.Controls.CalendarView), typeof(CalendarViewRenderer))]
namespace Xamarin.Forms.Labs.Droid.Controls.Calendar
{

    public class CalendarViewRenderer : ViewRenderer<Xamarin.Forms.Labs.Controls.CalendarView, Android.Widget.RelativeLayout>
    {
        private const string TAG = "Xamarin.Forms.Labs.Controls.Calendar";

        Xamarin.Forms.Labs.Controls.CalendarView _view;
        private bool _isElementChanging;

        CalendarArrowView _leftArrow;
        CalendarArrowView _rightArrow;

        public CalendarViewRenderer()
        {
        }

        private Android.Views.View _containerView;

        private CalendarPickerView _picker;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Labs.Controls.CalendarView> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement == null)
            {
                _view = e.NewElement;
                LayoutInflater inflatorservice =
                    (LayoutInflater)Context.GetSystemService(Android.Content.Context.LayoutInflaterService);
                _containerView = inflatorservice.Inflate(Resource.Layout.calendar_picker, null);
                _picker = _containerView.FindViewById<CalendarPickerView>(Resource.Id.calendar_view);
                _picker.Init(Element.MinDate, Element.MaxDate, Element.HighlightedDaysOfWeek);
                _picker.OnDateSelected += (object sender, DateSelectedEventArgs evt) => {
                    ProtectFromEventCycle(() => {
                        Element.NotifyDateSelected(evt.SelectedDate);
                    });
                };
                _picker.OnMonthChanged += (object sender, MonthChangedEventArgs mch) => {
                    SetNavigationArrows();
                    ProtectFromEventCycle(() => {
                        Element.NotifyDisplayedMonthChanged(mch.DisplayedMonth);
                    });

                };
                this.SetDisplayedMonth(Element.DisplayedMonth);
                SetNavigationArrows();
                SetColors();
                SetFonts();
                SetNativeControl((Android.Widget.RelativeLayout)_containerView);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            this.ProtectFromEventCycle(() => {
                if(e.PropertyName == XamLabsControls.CalendarView.DisplayedMonthProperty.PropertyName)
                {
                    this.SetDisplayedMonth(Element.DisplayedMonth);
                }
            });

        }


        private void ProtectFromEventCycle(Action action)
        {
            if(_isElementChanging == false)
            {
                _isElementChanging = true;
                action.Invoke();
                _isElementChanging = false;
            }
        }


        private void SetDisplayedMonth(DateTime newMonth)
        {

            if(newMonth >= XamLabsControls.CalendarView.FirstDayOfMonth(Element.MinDate) && newMonth <= XamLabsControls.CalendarView.LastDayOfMonth(Element.MaxDate))
            {
                var index = (newMonth.Month - Element.MinDate.Month) + 12 * (newMonth.Year - Element.MinDate.Year);
                SelectMonth(index, false);
            } else
            {
                throw new Exception("Month must be between MinDate and MaxDate");
            }

        }



        private void SetNavigationArrows()
        {
            if(_leftArrow == null)
            {
                _leftArrow = _containerView.FindViewById<CalendarArrowView>(Resource.Id.left_arrow);
                _leftArrow.Click += (object sender, EventArgs e) => {
                    this.SelectMonth(_picker.CurrentItem - 1, true);
                };

            }
            if(_rightArrow == null)
            {
                _rightArrow = _containerView.FindViewById<CalendarArrowView>(Resource.Id.right_arrow);
                _rightArrow.Direction = CalendarArrowView.ArrowDirection.RIGHT;
                _rightArrow.Click += (object sender, EventArgs e) => {
                    this.SelectMonth(_picker.CurrentItem + 1, true);
                };
            }
            _leftArrow.SetBackgroundColor(Android.Graphics.Color.Transparent);
            _rightArrow.SetBackgroundColor(Android.Graphics.Color.Transparent);
            if(Element.ShowNavigationArrows)
            {
                if(this._picker.CurrentItem + 1 != this._picker.MonthCount)
                {
                    _rightArrow.Visibility = ViewStates.Visible;
                } else
                {
                    _rightArrow.Visibility = ViewStates.Invisible;
                }
                if(this._picker.CurrentItem != 0)
                {
                    _leftArrow.Visibility = ViewStates.Visible;
                } else
                {
                    _leftArrow.Visibility = ViewStates.Invisible;
                }
            } else
            {
                _leftArrow.Visibility = ViewStates.Gone;
                _rightArrow.Visibility = ViewStates.Gone;
            }


        }

        private void SelectMonth(int monthIndex, bool animated)
        {
            if(monthIndex >= 0 && monthIndex < _picker.MonthCount)
            {
                _picker.ScrollToSelectedMonth(monthIndex, animated);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //Console.WriteLine("Disposing calendar renderer");
        }

        private void SetFonts()
        {
            if(Element.DateLabelFont != Font.Default)
            {
                _picker.StyleDescriptor.DateLabelFont = Element.DateLabelFont.ToExtendedTypeface(Context);
            }
            if(Element.MonthTitleFont != Font.Default)
            {
                _picker.StyleDescriptor.MonthTitleFont = Element.MonthTitleFont.ToExtendedTypeface(Context);
            }
        }

        private void SetColors()
        {
            if(Element.BackgroundColor != Color.Default)
            {
                var andColor = Element.BackgroundColor.ToAndroid();
                _containerView.SetBackgroundColor(andColor);
                _picker.SetBackgroundColor(andColor);
                _picker.StyleDescriptor.BackgroundColor = andColor;
            }

            //Month title
            if(Element.ActualMonthTitleBackgroundColor != Color.Default)
                _picker.StyleDescriptor.TitleBackgroundColor = Element.ActualMonthTitleBackgroundColor.ToAndroid();
            if(Element.ActualMonthTitleForegroundColor != Color.Default)
                _picker.StyleDescriptor.TitleForegroundColor = Element.ActualMonthTitleForegroundColor.ToAndroid();

            //Navigation color arrows
            if(Element.ActualNavigationArrowsColor != Color.Default)
            {
                _leftArrow.Color = Element.ActualNavigationArrowsColor.ToAndroid();
                _rightArrow.Color = Element.ActualNavigationArrowsColor.ToAndroid();
            } else
            {
                _leftArrow.Color = _picker.StyleDescriptor.TitleForegroundColor;
                _rightArrow.Color = _picker.StyleDescriptor.TitleForegroundColor;
            }

            //Day of week label
            if(Element.ActualDayOfWeekLabelBackroundColor != Color.Default)
            {
                var andColor = Element.ActualDayOfWeekLabelBackroundColor.ToAndroid();
                _picker.StyleDescriptor.DayOfWeekLabelBackgroundColor = andColor;
            }
            if(Element.ActualDayOfWeekLabelForegroundColor != Color.Default)
            {
                var andColor = Element.ActualDayOfWeekLabelForegroundColor.ToAndroid();
                _picker.StyleDescriptor.DayOfWeekLabelForegroundColor = andColor;
            }

            _picker.StyleDescriptor.ShouldHighlightDaysOfWeekLabel = Element.ShouldHighlightDaysOfWeekLabels;

            //Default date color
            if(Element.ActualDateBackgroundColor != Color.Default)
            {
                var andColor = Element.ActualDateBackgroundColor.ToAndroid();
                _picker.StyleDescriptor.DateBackgroundColor = andColor;
            }
            if(Element.ActualDateForegroundColor != Color.Default)
            {
                var andColor = Element.ActualDateForegroundColor.ToAndroid();
                _picker.StyleDescriptor.DateForegroundColor = andColor;
            }

            //Inactive Default date color
            if(Element.ActualInactiveDateBackgroundColor != Color.Default)
            {
                var andColor = Element.ActualInactiveDateBackgroundColor.ToAndroid();
                _picker.StyleDescriptor.InactiveDateBackgroundColor = andColor;
            }
            if(Element.ActualInactiveDateForegroundColor != Color.Default)
            {
                var andColor = Element.ActualInactiveDateForegroundColor.ToAndroid();
                _picker.StyleDescriptor.InactiveDateForegroundColor = andColor;
            }

            //Today date color
            if(Element.ActualTodayDateBackgroundColor != Color.Default)
            {
                var andColor = Element.ActualTodayDateBackgroundColor.ToAndroid();
                _picker.StyleDescriptor.TodayBackgroundColor = andColor;
            }
            if(Element.ActualTodayDateForegroundColor != Color.Default)
            {
                var andColor = Element.ActualTodayDateForegroundColor.ToAndroid();
                _picker.StyleDescriptor.TodayForegroundColor = andColor;
            }

            //Highlighted date color
            if(Element.ActualHighlightedDateBackgroundColor != Color.Default)
            {
                var andColor = Element.ActualHighlightedDateBackgroundColor.ToAndroid();
                _picker.StyleDescriptor.HighlightedDateBackgroundColor = andColor;
            }
            if(Element.ActualHighlightedDateForegroundColor != Color.Default)
            {
                var andColor = Element.ActualHighlightedDateForegroundColor.ToAndroid();
                _picker.StyleDescriptor.HighlightedDateForegroundColor = andColor;
            }



            //Selected date
            if(Element.ActualSelectedDateBackgroundColor != Color.Default)
                _picker.StyleDescriptor.SelectedDateBackgroundColor = Element.ActualSelectedDateBackgroundColor.ToAndroid();
            if(Element.ActualSelectedDateForegroundColor != Color.Default)
                _picker.StyleDescriptor.SelectedDateForegroundColor = Element.ActualSelectedDateForegroundColor.ToAndroid();

            //Divider
            if(Element.DateSeparatorColor != Color.Default)
                _picker.StyleDescriptor.DateSeparatorColor = Element.DateSeparatorColor.ToAndroid();

        }





    }
}