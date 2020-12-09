using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UIKit;

namespace Yondr_Finance.iOS
{
    public class MYPickerDateModel : UIPickerViewModel
    {
        public event EventHandler<DateTime> PickerChanged;

        #region Fields

        private readonly List<string> _mainNamesOfMonthSource;
        private readonly List<int> _mainYearsSource;
        private readonly List<int> _mainDaySource;
        private readonly UIPickerView _picker;
        private readonly int _numberOfComponents;
        private readonly int _minYear;
        private readonly int _maxYear;

        private List<int> _years;
        private List<string> _namesOfMonth;
        private List<int> _days;

        private DateTime _selectedDate;
        private DateTime _maxDate;
        private DateTime _minDate;

        #endregion Fields

        #region Constructors

        public MYPickerDateModel(UIPickerView datePicker, DateTime selectedDate)
        {
            _mainNamesOfMonthSource = DateTimeFormatInfo.CurrentInfo?.MonthNames
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            _minYear = 1900;
            _maxYear = 2100;

            _minDate = new DateTime(_minYear, 1, 1);
            _maxDate = new DateTime(_maxYear, 12, 1);

            _mainYearsSource = Enumerable.Range(_minYear, _maxYear).ToList();
            //var maxDay = DateTime.DaysInMonth(1, 31);
           
            _mainDaySource = Enumerable.Range(1, 31).ToList();
            
            _picker = datePicker;
            _namesOfMonth = _mainNamesOfMonthSource;
            _years = _mainYearsSource;
            _days = _mainDaySource;
            _numberOfComponents = 3;

            SelectedDate = selectedDate;
        }

        #endregion Constructors

        #region Properties

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                ReloadSections();
                PickerChanged?.Invoke(this, value);
            }
        }

        public DateTime MaxDate
        {
            get => _maxDate;
            set
            {
                _maxDate = value;
                ReloadSections();
            }
        }

        public DateTime MinDate
        {
            get => _minDate;
            set
            {
                _minDate = value;
                ReloadSections();
            }
        }

        #endregion Properties

        #region Private Methods

        private void ReloadSections()
        {
            var selectedDate = SelectedDate == DateTime.MinValue
                ? DateTime.Today
                : SelectedDate;

            _years = _mainYearsSource
                .Where(x => x >= MinDate.Year && x <= MaxDate.Year)
                .ToList();

            _namesOfMonth = _mainNamesOfMonthSource;
            var maxDay = DateTime.DaysInMonth(_maxYear, selectedDate.Month);

            if (SelectedDate.Year == MinDate.Year)
            {
                _namesOfMonth = _mainNamesOfMonthSource.Skip(MinDate.Month - 1).ToList();
                
            }

            if (SelectedDate.Year == MaxDate.Year)
            {
                _namesOfMonth = _mainNamesOfMonthSource.Take(MaxDate.Month).ToList();
               
            }
            _days = Enumerable.Range(1, maxDay).ToList();
            SetCarousels(selectedDate);
        }

        #endregion Private Methods

        #region Public Methods

        public void SetCarousels(DateTime dateTime)
        {
            if (_picker.NumberOfComponents != _numberOfComponents) return;

            var y = DateTimeFormatInfo.CurrentInfo?.GetMonthName(dateTime.Month);
            var x = _namesOfMonth.IndexOf(y);
            var z = _days.IndexOf(dateTime.Day);
            _picker.Select(z, 0, false);
            _picker.Select(x, 1, false);
            _picker.Select(_years.IndexOf(dateTime.Year), 2, false);

            _picker.ReloadComponent(0);
            _picker.ReloadComponent(1);
            _picker.ReloadComponent(2);
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return _numberOfComponents;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component) =>
            (int)component switch
            {
                0 => _days.Count,
                1 => _namesOfMonth.Count,
                2 => _years.Count,
                _ => 0
            };

        public override string GetTitle(UIPickerView pickerView, nint row, nint component) =>
            (int)component switch
            {
                0 => row >= _days.Count ? _days.First().ToString() : _days[(int)row].ToString(),
                1 => row >= _namesOfMonth.Count ? _namesOfMonth.First() : _namesOfMonth[(int)row],
                2 => row >= _years.Count ? _years.First().ToString() : _years[(int)row].ToString(),
                _ => row.ToString()
            };

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            
            
            var month = GetMonthNumberByName(_namesOfMonth[(int)pickerView.SelectedRowInComponent(1)]);
            var year = _years[(int)pickerView.SelectedRowInComponent(2)];
            
            var day = _days[(int)pickerView.SelectedRowInComponent(0)];

            var maxday = DateTime.DaysInMonth(year, month);
            if (year == MinDate.Year)
            {
                month = month >= MinDate.Month ? month : MinDate.Month;

                
            }

            if (year == MaxDate.Year)
            {
                month = month <= MaxDate.Month ? month : MaxDate.Month;
                
            }
           // day = DateTime.DaysInMonth(year, month);
           
            SelectedDate = new DateTime(year, month, day);

            ReloadSections();
            pickerView.ReloadAllComponents();

            int GetMonthNumberByName(string monthName) =>
                DateTime.ParseExact(monthName, "MMMM", CultureInfo.CurrentCulture).Month;
        }

        #endregion Public Methods
    }
}