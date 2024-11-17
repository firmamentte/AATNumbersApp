using AATNumbersApp.BLL.Helpers;
using AATNumbersApp.Data.Entities;
using EFCore.BulkExtensions;

namespace AATNumbersApp.BLL.BLLClasses
{
    public class PersistDataBLL : NumberHelper
    {
        public async Task PersistData()
        {
            int skip = 0;
            NumberDbContext dbContext = new();

            while (skip < StaticClass.GlobalVariable.Numbers.Count)
            {
                List<Number> numbers = [];

                foreach (int number in StaticClass.GlobalVariable.Numbers.Skip(skip).Take(StaticClass.GlobalVariable.Take))
                {
                    numbers.Add(new Number()
                    {
                        Value = number,
                        IsPrime = IsPrimeNumber(number)
                    });
                }

                await dbContext.BulkInsertAsync(numbers);

                skip += StaticClass.GlobalVariable.Take;
            }
        }
    }
}
