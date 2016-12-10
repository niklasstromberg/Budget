using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public int RecipientId { get; set; }
        public double Amount { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public int? PersonId { get; set; }
        public Household Household { get; set; }
        public string Notes { get; set; }

        public virtual Person person { get; set; }
    }
}
