using ApplicationCore.Models.Requests;
using ApplicationCore.Models.Response;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

       

        public async Task<UserDetailsResponseModel> GetUserByIdAsync(int id)
        {
            var userdetail = await _userRepository.GetByIdAsync(id);
            if (userdetail == null)
            {
                throw new Exception("User not found");

            }

            var expenditures = new List<ExpenditureResponseModel>();

            var incomes = new List<IncomesResponseModel>();

            foreach (var income in userdetail.Income)
            {
                incomes.Add(new IncomesResponseModel
                {
                    Id = income.Id,
                    UserId= income.UserId,
                   
                    Amount= income.Amount,
                    Description=income.Description,
                    IncomeDate=income.IncomeDate,
                    Remarks=income.Remarks
                });
            }

            foreach (var expenditure in userdetail.Expenditure)
            {
                expenditures.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }

            var endUserDetails = new UserDetailsResponseModel
            {
                Id = userdetail.Id,
                FullName=userdetail.Fullname,
                Email=userdetail.Email,
                JoinedOn=userdetail.JoinedOn,
                

                

            };

            return endUserDetails;
        }

        public async Task<List<ExpenditureResponseModel>> GetUserExpByIdAsync(int id)
        {
            var userExps = await _userRepository.GetExpById(id);
            if (userExps == null)
            {
                throw new Exception("Movie not found");

            }

            var expenditures = new List<ExpenditureResponseModel>();

            foreach (var userExp in userExps)
            {
                expenditures.Add(new ExpenditureResponseModel
                {
                    Id = userExp.Id,
                    UserId = userExp.UserId,
                    Amount = userExp.Amount,
                    Description = userExp.Description,
                    ExpDate = userExp.ExpDate,
                    Remarks = userExp.Remarks
                });
            }

            return expenditures;
        }

        public async Task<List<IncomesResponseModel>> GetUserIncomeByIdAsync(int id)
        {
            var userIncome = await _userRepository.GetUserIncomeById(id);
            if (userIncome == null)
            {
                throw new Exception("Movie not found");

            }

            var incomes = new List<IncomesResponseModel>();

            foreach (var userExp in userIncome)
            {
                incomes.Add(new IncomesResponseModel
                {
                    Id = userExp.Id,
                    UserId = userExp.UserId,
                    Amount = userExp.Amount,
                    Description = userExp.Description,
                    IncomeDate = userExp.IncomeDate,
                    Remarks = userExp.Remarks
                });
            }

            return incomes;
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequest)
        {
            //first check if user registered
            var dbuser = await _userRepository.GetUserByEmail(registerRequest.Email);
            if (dbuser != null)
            {
                throw new Exception("User Already exist");
            }

            // then create User Object and save it to database with UserRepository 

            var user = new Users()
            {
                Fullname = registerRequest.FullName,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                JoinedOn= registerRequest.JoinedOn

            };

            // call repository to save User info that included salt and hashed password
            var createdUser = await _userRepository.AddAsync(user);

            // map user object to UserRegisterResponseModel object
            var createdUserResponse = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FullName = createdUser.Fullname
                
            };

            return createdUserResponse;
        }


        public async Task<LoginResponseModel> ValidateUser(string email, string password)
        {
            var dbUser = await _userRepository.GetUserByEmail(email);
            if (dbUser == null)
            {
                return null;
            }
            var pass = password;
            if (pass == dbUser.Password)
            {
                var loginResponseModel = new LoginResponseModel { Id = dbUser.Id, Email = dbUser.Email, FullName = dbUser.Fullname };
                return loginResponseModel;
            }
            return null;
        }
    }
}
