using BudgetTracker.ApplicationCore.Models.Request;
using BudgetTracker.ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Http;
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
    public class IncomeController : ControllerBase
    {

        private readonly IIncomeService _incomeService;
        private readonly IConfiguration _configuration;
        public IncomeController(IIncomeService incomeService, IConfiguration configuration)
        {

            _incomeService = incomeService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addIncome")]
        public async Task<IActionResult> addNewExpense(AddIncomRequestModel model)
        {
            var income = await _incomeService.AddIncome(model);

            // 201
            return Ok(income);
        }

        [HttpDelete]
        [Route("{id:int}/")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            var result = await _incomeService.DeleteIncomeByIdAsync(id);
            if (result)
            {
                return Ok("Income deleted");
            }
            return NotFound("Failed to delete Income");
        }

        [HttpPut]
        [Route("updateIncome")]
        public async Task<IActionResult> UpdateIncome(IncomeUpdateRequestModel updateIncome)
        {
            var review = await _incomeService.UpdateIncome(updateIncome);
            return Ok(review);
        }


    }
}
