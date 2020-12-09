using System;

using Yondr_Finance.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Yondr_Finance.Controls;


[assembly: ExportRenderer(typeof(MonthYearPickerView), typeof(MonthYearPickerRenderer))]
namespace Yondr_Finance.iOS
{
    public class MonthYearPickerRenderer : ViewRenderer<MonthYearPickerView, UITextField>
    {
        private DateTime _selectedDate;
        private UITextField _dateLabel;
        private MYPickerDateModel _pickerModel;
        public event EventHandler<Xamarin.Forms.FocusEventArgs> Unfocused;
        protected override void OnElementChanged(ElementChangedEventArgs<MonthYearPickerView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null)
            {
                return;
            }
            _dateLabel = new UITextField();

            var dateToday = DateTime.Today;
            SetupPicker(new DateTime(dateToday.Year, dateToday.Month, dateToday.Day));

            SetNativeControl(_dateLabel);

            Control.EditingChanged += ControlOnEditingChanged;
            Element.PropertyChanged += Element_PropertyChanged;
        }

        private void ControlOnEditingChanged(object sender, EventArgs e)
        {
            string thisMonth = Element.Date.ToString("MMM");
            var currentDate = $"{Element.Date.Day:D2} |{thisMonth} | {Element.Date.Year}";
            if (_dateLabel.Text != currentDate)
            {
                _dateLabel.Text = currentDate;
            }
        }

        protected override void Dispose(bool disposing)
        {
            Element.PropertyChanged -= Element_PropertyChanged;
            base.Dispose(disposing);
        }

        private void SetupPicker(DateTime date)
        {
            var datePicker = new UIPickerView();
            _pickerModel = new MYPickerDateModel(datePicker, date);
            datePicker.ShowSelectionIndicator = true;
            _selectedDate = date;
            _pickerModel.PickerChanged += (sender, e) =>
            {
                _selectedDate = e;
            };
            datePicker.Model = _pickerModel;
            _pickerModel.MaxDate = Element.MaxDate ?? DateTime.MaxValue;
            _pickerModel.MinDate = Element.MinDate ?? DateTime.MinValue;

            var toolbar = new UIToolbar
            {
                BarStyle = UIBarStyle.Default,
                Translucent = true
            };
            toolbar.SizeToFit();

            var doneButton = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done,
                (s, e) =>
                {
                    Element.Date = _selectedDate;
                    string thisMonth = Element.Date.ToString("MMM");
                    _dateLabel.Text = $"{Element.Date.Day:D2} | {thisMonth} | {Element.Date.Year}";
                    _dateLabel.ResignFirstResponder();
                });

            toolbar.SetItems(new[] { new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace), doneButton }, true);

            _dateLabel.InputView = datePicker;
            string thisMonth = Element.Date.ToString("MMM");
            _dateLabel.Text = $"{Element.Date.Day:D2} | {thisMonth} | {Element.Date.Year}";
            _dateLabel.InputAccessoryView = toolbar;
            _dateLabel.TextColor = Element.TextColor.ToUIColor();
        }

        private void Element_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == MonthYearPickerView.MaxDateProperty.PropertyName)
            {
                _pickerModel.MaxDate = Element.MaxDate ?? DateTime.MinValue;
            }
            else if (e.PropertyName == MonthYearPickerView.MinDateProperty.PropertyName)
            {
                _pickerModel.MinDate = Element.MinDate ?? DateTime.MaxValue;
            }
        }
    }
}
