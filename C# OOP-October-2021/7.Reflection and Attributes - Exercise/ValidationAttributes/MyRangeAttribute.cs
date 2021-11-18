
namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int maxValue;
        private int minValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.maxValue = maxValue;
            this.minValue = minValue;
        }

        public override bool IsValid(object obj)
        {
            int inputInteger = (int)obj;

            if (inputInteger < minValue || inputInteger > maxValue)
            {
                return false;
            }

            return true;
        }
    }
}
