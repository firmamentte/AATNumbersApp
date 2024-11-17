namespace AATNumbersApp.BLL.Helpers
{
    public class NumberHelper
    {
        public bool IsOddNumber(int number) => number % 2 == 1;

        public bool IsEvenNumber(int number) => number % 2 == 0;

        public bool IsPrimeNumber(int number)
        {
            if (number <= 1)
                return false;

            if (number == 2)
                return true;

            if (number % 2 == 0)
                return false;

            int num = (int)Math.Floor(Math.Sqrt(number));

            for (int index = 3; index <= num; index += 2)
            {
                if (number % index == 0)
                    return false;
            }
            return true;
        }
    }
}
