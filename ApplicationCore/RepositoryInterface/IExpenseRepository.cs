using BudgetTracker.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.ApplicationCore.RepositoryInterface
{
    public interface IExpenseRepository : IAsyncRepository<Expenditures>
    {

    }
}
