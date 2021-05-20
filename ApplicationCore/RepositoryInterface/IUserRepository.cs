using BudgetTracker.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.ApplicationCore.RepositoryInterface
{
    public interface IUserRepository: IAsyncRepository<Users>
    {
        Task<Users> GetUserByEmail(string email);

        Task<IEnumerable<Expenditures>> GetExpById(int id);

        Task<IEnumerable<Incomes>> GetUserIncomeById(int id);


    }
}
