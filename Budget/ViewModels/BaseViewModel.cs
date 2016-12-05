using Budget.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ViewModels
{
    public abstract class BaseViewModel // : INotifyPropertyChanged
    {
        public event EventHandler PropertyChanged;
        //public event EventHandler<PropertyChangedEventArgs> PropertyChanged;

        public Person ChosenPerson { get; set; }
        public Household ChosenHousehold { get; set; }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            EventHandler handler = PropertyChanged;
            if(handler != null)
            PropertyChanged?.Invoke(this, e);
        }




    }
}
