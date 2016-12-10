using Budget.Managers;
using Budget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ViewModels
{
    public partial class PersonViewModel : BaseViewModel
    {
        public PersonViewModel()
        {
            GetData();
        }

        public void GetData()
        {
            _households = DatabaseManager.GetHouseholds();
            _persons = DatabaseManager.GetPersons();
        }

        private List<Household> _households = new List<Household>();

        public List<Household> Households
        {
            set
            {
                _households = value;
            }
            get
            {
                return _households;
            }
        }

        private List<Person> _persons = new List<Person>();

        public List<Person> Persons
        {
            set
            {
                _persons = value;
            }
            get
            {
                return _persons;
            }
        }


    }
}
