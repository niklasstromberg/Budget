using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budget.Models;

namespace Budget.ViewModels
{
    public partial class MonthViewModel : BaseViewModel, IViewModel
    {
        public DateTime Month { get; set; }
        public virtual List<Expense> ExpensesByMonth { get; set; }
        public virtual List<Income> IncomeByMonth { get; set; }
    }
}
