using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Yondr_Finance.Models
{
    public class CommonViewModel
    {
        public void validate_buttons(bool validate,Button btnNext)
        {
            if(validate==true)
            {
                btnNext.IsEnabled = true;
                btnNext.BackgroundColor = Color.FromRgb(179, 130, 242);
            }
            else
            {
                btnNext.IsEnabled = false;
                btnNext.BackgroundColor = Color.FromRgb(160, 160, 160);
            }
        }

        public bool validate_email(string email)
        {
            bool rslt;            
            var emailPattern = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            rslt = emailPattern.IsMatch(email);
            return rslt;
            
        }
    }
}
