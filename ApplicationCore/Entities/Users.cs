using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.ApplicationCore.Entities
{
    public class Users
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        
        public DateTime? JoinedOn { get; set; }

        public ICollection<Expenditures> Expenditure { get; set; }

        public ICollection<Incomes> Income { get; set; }


    }
}
