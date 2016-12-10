using Budget.Interfaces;
using Budget.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Budget.Models
{
    public class Household : IHousehold
    {
        [Key]
        public int HouseholdId { get; set; }
        public string HouseholdName { get; set; }
        public virtual List<Person> PersonsInHousehold { get; set; }
        //{
        //    get
        //    {
        //        return this;
        //    }
        //    set
        //    {
        //        PersonsInHousehold = DatabaseManager.GetPersonsInHousehold(this);
        //    }
        //}

        // Get the total income for the household
        public double GetIncome()
        {
            double totalIncome = 0;
            foreach (Person person in PersonsInHousehold)
            {
                foreach (Income income in person.IncomeByPerson)
                {
                    totalIncome += income.Amount;
                }
            }
            return totalIncome;
        }
    }
}
