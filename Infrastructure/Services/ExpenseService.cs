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
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<AddExpenseResponseModel> AddExpense(AddExpenseModel addExpense)
        {

            var expense = new Expenditures()
            {
                UserId = addExpense.UserId,
                Amount = addExpense.Amount,
                Description = addExpense.Description,
                ExpDate = addExpense.ExpDate,
                Remarks = addExpense.Remarks

            };

            var createdexpense = await _expenseRepository.AddAsync(expense);


            // map user object to UserRegisterResponseModel object
            var createdExpResponse = new AddExpenseResponseModel
            {
               UserId= createdexpense.UserId,
                Amount = createdexpense.Amount,
                Description = createdexpense.Description,
                ExpDate= createdexpense.ExpDate,
                Remarks= createdexpense.Remarks
        

            };

            return createdExpResponse;
            
        }

        public async Task<bool> DeleteExpenseByIdAsync(int id)
        {
            var review = await _expenseRepository.ListAsync(e => e.Id == id);
            if (review != null)
            {
                await _expenseRepository.DeleteAsync(review.First());

                return true;

            }

            return false;
        }

        public async Task<Expenditures> UpdateExpenditures(ExpenseUpdateRequestModel updateExp)
        {

           

            
            var updateExpense = new Expenditures { Id = updateExp.Id, UserId=updateExp.UserId, Amount = updateExp.Amount, Description= updateExp.Description , ExpDate= updateExp.ExpDate, Remarks= updateExp.Remarks };
            var exp = await _expenseRepository.UpdateAsync(updateExpense);
            var updatedExp = new Expenditures { Id = exp.Id, UserId=exp.UserId, Amount = exp.Amount, Description = exp.Description, ExpDate = exp.ExpDate, Remarks= exp.Remarks };
            return updatedExp;
           
        }
    }
}
