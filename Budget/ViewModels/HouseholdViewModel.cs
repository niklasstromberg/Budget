using Budget.Managers;
using Budget.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ViewModels
{
    public partial class HouseholdViewModel : BaseViewModel
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        public HouseholdViewModel()
        {
            GetData();
        }

        private void GetData()
        {
            _households = DatabaseManager.GetHouseholds();
        }

        private List<Household> _households = new List<Household>();
        //{
        //    set
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("_households"));
        //    }
        //    get
        //    {
        //        return DatabaseManager.GetHouseholds();
        //    }
        //}

        public List<Household> Households
        {
            get
            {
                return _households;
            }
            set
            {
                _households = value;
                //RaiseOnPropertyChanged();
            }
        }

        public void RaiseOnPropertyChanged()
        {
            OnPropertyChanged(new PropertyChangedEventArgs("_households"));
        }
    }
}
