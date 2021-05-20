using BudgetTracker.ApplicationCore.Entities;
using BudgetTracker.ApplicationCore.RepositoryInterface;
using BudgetTracker.Infrastructure.Data;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Infrastructure.Repositories
{
    public class ExpenseRepository : EfRepository<Expenditures> ,IExpenseRepository
    {
        public ExpenseRepository(BudgetTrackerDBContext dbContext) : base(dbContext)
        {
        }



    }
}
