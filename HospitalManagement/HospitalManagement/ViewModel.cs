using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    public class ViewModel : INotifyPropertyChanged
    {
        private List<PetInfo> customers;
        private int currentCustomer;
        public Command NextCustomer { get; private set; }
        public Command PreviousCustomer { get; private set; }
        public ViewModel()
        {
            this.IsAtStart = true;
            this.IsAtEnd = false;
            this.currentCustomer = 0;
            this.NextCustomer = new Command(this.Next, () => this.customers.Count > 1 && !this.IsAtEnd);
            this.PreviousCustomer = new Command(this.Previous, () => this.customers.Count > 0 && !this.IsAtStart);

            this.customers = new List<PetInfo>
            {
                new PetInfo
                {
                    CustomerID=246,
                    Title="Dog",
                    FirstName="Rover",
                    LastName="12",
                    EmailAddress="Sam Cook",
                    Phone="111-4334"
                },
                new PetInfo
                {
                    CustomerID=298,
                    Title="Dog",
                    FirstName="Spot",
                    LastName="2",
                    EmailAddress="Terry Kim",
                    Phone="111-5665"
                },
                new PetInfo
                {
                    CustomerID=341,
                    Title="Cat",
                    FirstName="Morris",
                    LastName="4",
                    EmailAddress="Sam Cook",
                    Phone="111-1132"
                },
                new PetInfo
                {
                    CustomerID=519,
                    Title="Bird",
                    FirstName="Francesca",
                    LastName="2",
                    EmailAddress="Sam Cook",
                    Phone="111-114512"
                },
            };
        }

        public PetInfo Current
        {
            get => this.customers.Count > 0 ? this.customers[currentCustomer] : null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private bool _isAtStart;
        public bool IsAtStart
        {
            get => this._isAtStart;
            set
            {
                this._isAtStart = value;
                this.OnPropertyChanged(nameof(IsAtStart));
            }
        }

        private bool _isAtEnd;
        public bool IsAtEnd
        {
            get => this._isAtEnd;
            set
            {
                this._isAtEnd = value;
                this.OnPropertyChanged(nameof(IsAtEnd));
            }
        }

        private void Next()
        {
            if (this.customers.Count - 1 > this.currentCustomer)
            {
                this.currentCustomer++;
                this.OnPropertyChanged(nameof(Current));
                this.IsAtStart = false;
                this.IsAtEnd = (this.customers.Count - 1 == this.currentCustomer);
            }
        }

        private void Previous()
        {
            if (this.currentCustomer > 0)
            {
                this.currentCustomer--;
                this.OnPropertyChanged(nameof(Current));
                this.IsAtEnd = false;
                this.IsAtStart = (this.currentCustomer == 0);
            }
        }
    }
}
