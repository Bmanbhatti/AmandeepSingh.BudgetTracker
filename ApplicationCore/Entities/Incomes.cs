﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.ApplicationCore.Entities
{
    public class Incomes
    {   
        public int Id { get; set; }
        public int? UserId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }
        public DateTime? IncomeDate { get; set; }
        public string Remarks { get; set; }

        public Users User { get; set; }
    }
}
