using BudgetTracker.ApplicationCore.Entities;
using BudgetTracker.ApplicationCore.Models.Request;
using BudgetTracker.ApplicationCore.Models.Response;
using BudgetTracker.ApplicationCore.RepositoryInterface;
using BudgetTracker.ApplicationCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Infrastructure.Services
{
    public class IncomeService: IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeService(IIncomeRepository incomeRepository)
        {

            _incomeRepository = incomeRepository;
        }

     

        public async Task<AddIncomeResponseModel> AddIncome(AddIncomRequestModel addIncome)
        {

            var income = new Incomes()
            {
                UserId = addIncome.UserId,
                Amount = addIncome.Amount,
                Description = addIncome.Description,
                IncomeDate = addIncome.IncomeDate,
                Remarks = addIncome.Remarks

            };

            var createdincome = await _incomeRepository.AddAsync(income);


            // map user object to UserRegisterResponseModel object
            var createdIncomeResponse = new AddIncomeResponseModel
            {

                UserId = createdincome.UserId,
                Amount = createdincome.Amount,
                Description = createdincome.Description,
                IncomeDate = createdincome.IncomeDate,
                Remarks = createdincome.Remarks


            };

            return createdIncomeResponse;

        }

        public async Task<bool> DeleteIncomeByIdAsync(int id)
        {

            var review = await _incomeRepository.ListAsync(e => e.Id == id);
            if (review != null)
            { 
                await _incomeRepository.DeleteAsync(review.First());

                return true;

            }

            return false;
          
        }

        public async Task<Incomes> UpdateIncome(IncomeUpdateRequestModel UpdateIncome)
        {

            var updateExpense = new Incomes { Id = UpdateIncome.Id, UserId = UpdateIncome.UserId, Amount = UpdateIncome.Amount, Description = UpdateIncome.Description, IncomeDate = UpdateIncome.IncomeDate, Remarks = UpdateIncome.Remarks };
            var exp = await _incomeRepository.UpdateAsync(updateExpense);
            var updatedIncome = new Incomes { Id = exp.Id, UserId = exp.UserId, Amount = exp.Amount, Description = exp.Description, IncomeDate = exp.IncomeDate, Remarks = exp.Remarks };
            return updatedIncome;
            
        }
    }

}
