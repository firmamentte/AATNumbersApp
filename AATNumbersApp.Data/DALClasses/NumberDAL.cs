using AATNumbersApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AATNumbersApp.Data.DALClasses
{
    public class NumberDAL
    {
        public async Task<List<Number>> GetNumbers(NumberDbContext dbContext, int skip, int take)
        {
            return await (from number in dbContext.Numbers
                          select number).
                          Skip(skip).
                          Take(take).
                          ToListAsync();
        }
    }
}
