using BudgetTracker.ApplicationCore.Models.Request;
using BudgetTracker.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.ApplicationCore.ServiceInterface
{
    public interface IExpenseService
    {
        Task<AddExpenseResponseModel> AddExpense(AddExpenseModel addExpense);

        Task<bool> DeleteExpenseByIdAsync(int id);
    }
}
