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
    public class IncomeRepository: EfRepository<Incomes>, IIncomeRepository
    {

        public IncomeRepository(BudgetTrackerDBContext dbContext) : base(dbContext)
        {
        }
    }
}
