using BudgetTracker.ApplicationCore.Entities;
using BudgetTracker.ApplicationCore.Models.Request;
using BudgetTracker.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.ApplicationCore.ServiceInterface
{
    public interface IIncomeService
    {
        Task<AddIncomeResponseModel> AddIncome(AddIncomRequestModel addIncome);

        Task<Incomes> UpdateIncome(IncomeUpdateRequestModel addIncome);

        Task<bool> DeleteIncomeByIdAsync(int id);
    }
}
