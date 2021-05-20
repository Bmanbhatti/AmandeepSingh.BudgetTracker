using BudgetTracker.ApplicationCore.Models.Request;
using BudgetTracker.ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly IConfiguration _configuration;

        public ExpenseController(IExpenseService expenseService, IConfiguration configuration)
        {
            _expenseService = expenseService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addExpense")]
        public async Task<IActionResult> addNewExpense( AddExpenseModel model)
        {
            var exp = await _expenseService.AddExpense(model);

            // 201
            return Ok(exp);
        }


        [HttpDelete]
        [Route("{id:int}/")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            var result = await _expenseService.DeleteExpenseByIdAsync(id);
            if (result)
            {
                return Ok("Expense deleted");
            }
            return NotFound("Failed to delete Expense");
        }
    }
}
