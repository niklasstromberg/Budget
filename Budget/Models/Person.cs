using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }

        public virtual List<Household> Households { get; set; }
        public virtual List<Income> IncomeByPerson { get; set; }
        public virtual List<Expense> ExpensesByPerson { get; set; }
    }
}
