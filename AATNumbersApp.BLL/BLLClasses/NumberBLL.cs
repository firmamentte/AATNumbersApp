using AATNumbersApp.Data.DALClasses;
using AATNumbersApp.Data.Entities;

namespace AATNumbersApp.BLL.BLLClasses
{
    public class NumberBLL
    {
        private readonly NumberDAL NumberDAL;

        public NumberBLL()
        {
            NumberDAL = new NumberDAL();
        }

        public async Task<List<Number>> GetNumbers()
        {
            int skip = 0;
            using NumberDbContext dbContext = new();

            List<Number> numbers = [], numbersDB = await NumberDAL.GetNumbers(dbContext, skip, StaticClass.GlobalVariable.Take);

            while (numbersDB.Any())
            {
                numbers.AddRange(numbersDB);

                skip += StaticClass.GlobalVariable.Take;

                numbersDB = await NumberDAL.GetNumbers(dbContext, skip, StaticClass.GlobalVariable.Take);
            }

            return numbers;
        }
    }
}
