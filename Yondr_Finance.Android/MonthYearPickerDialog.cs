using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Debug = System.Diagnostics.Debug;

namespace Yondr_Finance.Droid
{
    public class MonthYearPickerDialog : Android.Support.V4.App.DialogFragment
    {
        public event EventHandler<DateTime> OnDateTimeChanged;
        public event EventHandler<DateTime> OnClosed;

        #region Private Fields

        private const int DefaultDay = 1;
        private const int MinNumberOfDays = 1;
        private const int MaxNumberOfDays = 31;
        private const int MinNumberOfMonths = 1;
        private const int MaxNumberOfMonths = 12;
        private const int MinNumberOfYears = 1900;
        private const int MaxNumberOfYears = 2100;

        private NumberPicker _dayPicker;
        private NumberPicker _monthPicker;
        private NumberPicker _yearPicker;

        #endregion

        #region Public Properties

        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public DateTime? Date { get; set; }
        public bool InfiniteScroll { get; set; }

        #endregion

        public void Hide() => base.Dialog?.Hide();

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var builder = new AlertDialog.Builder(Activity);
            var inflater = Activity.LayoutInflater;

            var selectedDate = GetSelectedDate();

            var dialog = inflater.Inflate(Resource.Layout.date_picker_dialog, null);
           
            _monthPicker = (NumberPicker)dialog.FindViewById(Resource.Id.picker_month);
            _yearPicker = (NumberPicker)dialog.FindViewById(Resource.Id.picker_year);
            _dayPicker = (NumberPicker)dialog.FindViewById(Resource.Id.picker_day);

            InitializeMonthPicker(selectedDate.Month);
            InitializeYearPicker(selectedDate.Year);
            InitializeDayPicker(selectedDate.Day, selectedDate.Month, selectedDate.Year);
            SetMaxMinDate(MaxDate, MinDate);

            builder.SetView(dialog)
                .SetPositiveButton("Ok", (sender, e) =>
                {
                    selectedDate = new DateTime(_yearPicker.Value, _monthPicker.Value, _dayPicker.Value);
                    OnDateTimeChanged?.Invoke(dialog, selectedDate);
                })
                .SetNegativeButton("Cancel", (sender, e) =>
                {
                    Dialog.Cancel();
                    OnClosed?.Invoke(dialog, selectedDate);
                });
            var ss = selectedDate;
            return builder.Create();
        }

        protected override void Dispose(bool disposing)
        {
            if (_yearPicker != null)
            {
                _yearPicker.ScrollChange -= YearPicker_ScrollChange;
                _yearPicker.Dispose();
                _yearPicker = null;
            }

           
            if (_monthPicker != null)
            {
                _monthPicker.ScrollChange -= MonthPicker_ScrollChange;
                _monthPicker?.Dispose();
                _monthPicker = null;
            }

            _dayPicker?.Dispose();
            _dayPicker = null;

            base.Dispose(disposing);
        }

        #region Private Methods

        private DateTime GetSelectedDate() => Date ?? DateTime.Now;

        private void InitializeYearPicker(int year)
        {
            _yearPicker.MinValue = MinNumberOfYears;
            _yearPicker.MaxValue = MaxNumberOfYears;
            _yearPicker.Value = year;
            _yearPicker.ScrollChange += YearPicker_ScrollChange;
            if (!InfiniteScroll)
            {
                _yearPicker.WrapSelectorWheel = false;
                _yearPicker.DescendantFocusability = DescendantFocusability.BlockDescendants;
            }
        }

        private void InitializeMonthPicker(int month)
        {
            _monthPicker.MinValue = MinNumberOfMonths;
            _monthPicker.MaxValue = MaxNumberOfMonths;
            _monthPicker.SetDisplayedValues(GetMonthNames());
            _monthPicker.Value = month;
            _monthPicker.ScrollChange += MonthPicker_ScrollChange;
            if (!InfiniteScroll)
            {
                _monthPicker.WrapSelectorWheel = false;
                _monthPicker.DescendantFocusability = DescendantFocusability.BlockDescendants;
            }
        }
   
        private void InitializeDayPicker(int day, int _month, int _year)
        {
           
            _dayPicker.MinValue = MinNumberOfDays;
            _dayPicker.MaxValue = DateTime.DaysInMonth(_year, _month);
            _dayPicker.Value = day;
            //populate Days

           
            if (!InfiniteScroll)
            {
                _dayPicker.WrapSelectorWheel = false;
                _dayPicker.DescendantFocusability = DescendantFocusability.BlockDescendants;
           }
        }

        private void MonthPicker_ScrollChange(object sender, View.ScrollChangeEventArgs e)
        {
            _dayPicker.MaxValue = DateTime.DaysInMonth(_yearPicker.Value, _monthPicker.Value);
        }

        private void YearPicker_ScrollChange(object sender, View.ScrollChangeEventArgs e)
        {

            SetMaxMinDate(MaxDate, MinDate);
        }

        private void SetMaxMinDate(DateTime? maxDate, DateTime? minDate)
        {
            try
            {
                if (maxDate.HasValue)
                {
                    var maxYear = maxDate.Value.Year;
                    var maxMonth = maxDate.Value.Month;
                    var maxDay = DateTime.DaysInMonth(maxYear, maxMonth);
                    

                    if (_yearPicker.Value == maxYear)
                    {
                        _monthPicker.MaxValue = maxMonth;
                        _dayPicker.MaxValue = maxDay;

                    }
                    else if (_monthPicker.MaxValue != MaxNumberOfMonths)
                    {
                        _monthPicker.MaxValue = MaxNumberOfMonths;
                        _dayPicker.MaxValue = maxDay;
                    }

                    _yearPicker.MaxValue = maxYear;
                   
                }

                if (minDate.HasValue)
                {
                    var minYear = minDate.Value.Year;
                    var minMonth = minDate.Value.Month;
                    var minDay = minDate.Value.Day;

                    if (_yearPicker.Value == minYear)
                    {
                        _monthPicker.MinValue = minMonth;
                        _dayPicker.MinValue = minDay;
                    }
                    else if (_monthPicker.MinValue != MinNumberOfMonths)
                    {
                        _monthPicker.MinValue = MinNumberOfMonths;
                        _dayPicker.MinValue = MinNumberOfDays;
                    }

                    _yearPicker.MinValue = minYear;
                }
                _monthPicker.SetDisplayedValues(GetMonthNames(_monthPicker.MinValue));
               
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
            }
        }

        private string[] GetMonthNames(int start = 1) =>
            System.Globalization.DateTimeFormatInfo.CurrentInfo?.MonthNames.Skip(start - 1).ToArray();

        #endregion

    }
}
