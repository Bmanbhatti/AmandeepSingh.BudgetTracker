using ApplicationCore.Models.Requests;
using ApplicationCore.Models.Response;
using BudgetTracker.ApplicationCore.Models.Request;
using BudgetTracker.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.ApplicationCore.ServiceInterface
{
    public interface IUserService
    {
        Task<LoginResponseModel> ValidateUser(string email, string password);
        Task<UserDetailsResponseModel> GetUserByIdAsync(int id);

        Task<List<ExpenditureResponseModel>> GetUserExpByIdAsync(int id);

        Task<List<IncomesResponseModel>> GetUserIncomeByIdAsync(int id);

        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequest);

       


    }
}
