using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Yondr_Finance.Models
{
    public class DetailModel : INotifyPropertyChanged
    {
        public Field FirstName { get; set; } = new Field();
        public Field MiddleName { get; set; } = new Field();
        public Field SurName { get; set; } = new Field();
        public Field Email { get; set; } = new Field();
        public Field Gender { get; set; } = new Field();

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Field : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public bool IsNotValid { get; set; }
        public string NotValidMessageError { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class MyMessage
    {
        public string Myvalue { get; set; }
    }
}