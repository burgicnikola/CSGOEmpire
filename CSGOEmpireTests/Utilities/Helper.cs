namespace CSGOEmpireTests.Utilities
{
    public class Helper
    {
        public static double RandomNumber()
        {
            Random random = new Random();
            double wholeNumer = random.Next(0, 999999);
            double decimalNumber = random.NextDouble();
            return wholeNumer + decimalNumber;
        }
    }
}
