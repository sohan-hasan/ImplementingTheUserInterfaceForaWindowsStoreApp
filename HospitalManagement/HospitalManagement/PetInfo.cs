using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    public class PetInfo : INotifyPropertyChanged
    {
        public int _customerID;
        public string _title;
        public string _firstName;
        public string _lastName;
        public string _emailAddress;
        public string _phone;

        public int CustomerID
        {
            get => _customerID;
            set
            {
                _customerID = value;
                this.OnPropertyChanged(nameof(CustomerID));
            }
        }
        public string Title
        {
            get => _title;

            set
            {
                _title = value;
                this.OnPropertyChanged(nameof(Title));
            }
        }
        public string FirstName
        {
            get => _firstName;

            set
            {
                _firstName = value;
                this.OnPropertyChanged(nameof(FirstName));
            }

        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                this.OnPropertyChanged(nameof(LastName));
            }

        }
        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                _emailAddress = value;
                this.OnPropertyChanged(nameof(EmailAddress));
            }

        }
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                this.OnPropertyChanged(nameof(Phone));
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
