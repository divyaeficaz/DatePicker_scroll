using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yondr_Finance.Models
{
    public class UserModel
    {
        public UserModel()
        {
            UniqueID = Guid.NewGuid().ToString();
        }

        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string UniqueID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string Gender { get; set; }
        public string PrefferedName{ get; set; }
        public string add_number { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Territory { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string Nationality { get; set; }
        public string SecurityQn { get; set; }
        public string SecurityAns { get; set; }
        public DateTime DOB { get; set; }
        public string Passort_DocumentNo { get; set; }
        public string Passport_Nationality { get; set; }
        public string Passport_PlaceofBirth { get; set; }
        public string Passport_Expiry { get; set; }
        public string Licence_DocumentNo { get; set; }
        public string Licence_state { get; set; }     
        public string Licence_Expiry { get; set; }
        public string Medicare_No { get; set; }
        public string Medicare_referenceNo { get; set; }
        public string Medicare_Expiry { get; set; }
        private static List<UserModel> userList = new List<UserModel>();

        public DateTime Date { get; set; }
        public static List<UserModel> UserList
        {
            get { return userList; }
            set { userList = value; }
        }
    }
}
