using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget.Models
{
    public class Income
    {
        [Key]
        public int IncomeId { get; set; }
        public int PersonId { get; set; }
        public string IncomeDescription { get; set; }
        public double Amount { get; set; }

        public virtual Person person { get; set; }
    }
}
