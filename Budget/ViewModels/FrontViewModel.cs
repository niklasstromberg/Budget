using Budget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.ViewModels
{
    public partial class FrontViewModel : BaseViewModel, IViewModel
    {
        public FrontViewModel()
        {
            GetData();
        }

        private void GetData()
        {
            _households = DatabaseManager.GetHouseholds();
        }

        private List<Household> _households
        {
            set { }
            get
            {
                return DatabaseManager.GetHouseholds();
            }
        }

        public List<Household> Households
        {
            get
            {
                return _households;
            }
        }
    }
}
