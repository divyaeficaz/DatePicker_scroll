using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Yondr_Finance.Models;

namespace Yondr_Finance.ViewModels
{
    public class SignupDetaiPage1ViewModel : INotifyPropertyChanged
    {
        public DetailModel User { get; set; }
        public bool ErrorMessageVisiliby { get; set; }
        public ICommand OnValidationCommand { get; set; }
        public SignupDetaiPage1ViewModel()
        {
            User = new DetailModel();

            OnValidationCommand = new Command((obj) =>
            {
                User.FirstName.NotValidMessageError = "Name is required";
                User.FirstName.IsNotValid = string.IsNullOrEmpty(User.FirstName.Name);

                User.Email.NotValidMessageError = "Email is required";
                User.Email.IsNotValid = string.IsNullOrEmpty(User.Email.Name);


                if (string.IsNullOrEmpty(User.MiddleName.Name))
                {
                    User.MiddleName.NotValidMessageError = "Middlename is required";
                    User.MiddleName.IsNotValid = true;
                }
                if (string.IsNullOrEmpty(User.SurName.Name))
                {
                    User.SurName.NotValidMessageError = "Surname is required";
                    User.SurName.IsNotValid = true;
                }
                


            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
