using AATNumbersApp.BLL.Helpers;

namespace AATNumbersApp.BLL.BLLClasses
{
    public class ComputeDataBLL : NumberHelper
    {
        public void ShowTotals()
        {
            StaticClass.GlobalVariable.Numbers = StaticClass.GlobalVariable.Numbers.OrderBy(number => number).ToList();
            StaticClass.GlobalVariable.TotalOddNumbers = StaticClass.GlobalVariable.Numbers.Count(number => IsOddNumber(number));
            StaticClass.GlobalVariable.TotalEvenNumbers = StaticClass.GlobalVariable.Numbers.Count(number => IsEvenNumber(number));
        }

        public void ComputeData()
        {
            Thread createOddNumbers = new(CreateOddNumbers);
            createOddNumbers.Start();

            Thread createPrimeNumbers = new(CreatePrimeNumbers);
            createPrimeNumbers.Start();
        }

        private void CreateOddNumbers()
        {
            Random random = new();
            while (StaticClass.GlobalVariable.Numbers.Count < StaticClass.GlobalVariable.MinCounter)
            {
                int number = random.Next(1, int.MaxValue);

                if (IsOddNumber(number))
                    StaticClass.GlobalVariable.Numbers.Add(number);

                if (!StaticClass.GlobalVariable.IsEvenNumbersThreadCreated && StaticClass.GlobalVariable.Numbers.Count == StaticClass.GlobalVariable.MinCounter)
                {
                    StaticClass.GlobalVariable.IsEvenNumbersThreadCreated = true;
                    StaticClass.GlobalVariable.MinCounter = StaticClass.GlobalVariable.MaxCounter;

                    Thread createEvenNumbers = new(CreateEvenNumbers);
                    createEvenNumbers.Start();
                }
            }
        }

        private void CreatePrimeNumbers()
        {
            List<int> intList = [2];
            int nextNumber = 3;

            while (StaticClass.GlobalVariable.Numbers.Count < StaticClass.GlobalVariable.MinCounter)
            {
                int number = (int)Math.Floor(Math.Sqrt(nextNumber));
                bool flag = true;

                for (int index = 0; intList[index] <= number; ++index)
                {
                    if (nextNumber % intList[index] == 0)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    intList.Add(nextNumber);
                    StaticClass.GlobalVariable.Numbers.Add(nextNumber);
                }

                nextNumber += 2;

                if (!StaticClass.GlobalVariable.IsEvenNumbersThreadCreated && StaticClass.GlobalVariable.Numbers.Count == StaticClass.GlobalVariable.MinCounter)
                {
                    StaticClass.GlobalVariable.IsEvenNumbersThreadCreated = true;
                    StaticClass.GlobalVariable.MinCounter = StaticClass.GlobalVariable.MaxCounter;

                    Thread createEvenNumbers = new(CreateEvenNumbers);
                    createEvenNumbers.Start();
                }
            }
        }

        private void CreateEvenNumbers()
        {
            Random random = new();
            while (StaticClass.GlobalVariable.Numbers.Count < StaticClass.GlobalVariable.MinCounter)
            {
                int number = random.Next(1, int.MaxValue);
                if (IsEvenNumber(number))
                    StaticClass.GlobalVariable.Numbers.Add(number);
            }
        }
    }
}
