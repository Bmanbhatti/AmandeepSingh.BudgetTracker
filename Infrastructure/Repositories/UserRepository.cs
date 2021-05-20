using BudgetTracker.ApplicationCore.Entities;
using BudgetTracker.ApplicationCore.RepositoryInterface;
using BudgetTracker.Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetTracker.Infrastructure.Repositories
{
    public class UserRepository : EfRepository<Users>, IUserRepository
    {
        public UserRepository(BudgetTrackerDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }


        public override async Task<Users> GetByIdAsync(int id)
        {
            var userdetail = await _dbContext.Users.Include(u => u.Income)
                .FirstOrDefaultAsync(u => u.Id == id);

            var Expenditures = await _dbContext.Expenditure.Where(e => e.UserId==id).OrderByDescending(e=> e.ExpDate).Take(30).ToListAsync();

            var income = await _dbContext.Income.Where(e => e.UserId == id).OrderByDescending(e=> e.IncomeDate).Take(30).ToListAsync();
            ////assign movie avg rating;

            userdetail.Expenditure = Expenditures;
            userdetail.Income = income;

            return userdetail;
        }

        public async Task<IEnumerable<Expenditures>> GetExpById(int id)
        {
            var Expenditures = await _dbContext.Expenditure.Where(e => e.UserId == id).OrderByDescending(e => e.ExpDate).Take(30).ToListAsync();

            return Expenditures; 
        }

        public async Task<IEnumerable<Incomes>> GetUserIncomeById(int id)
        {
            var income = await _dbContext.Income.Where(e => e.UserId == id).OrderByDescending(e => e.IncomeDate).Take(30).ToListAsync();
            return income;
        }


    }
}
