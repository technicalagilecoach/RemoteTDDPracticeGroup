namespace FizzBuzzKata_CSharp
{
/*
    FizzBuzz-Kata
    https://codingdojo.org/kata/FizzBuzz/
    https://kata-log.rocks/fizz-buzz-kata

    Schreibe eine Funktion, die eine positive ganze Zahl als Argument empfängt und jede Zahl als Zeichenfolge zurückgibt.
    Für Vielfache von 3 soll "Fizz" anstelle der Zahl zurückgegeben werden
    Für Vielfache von 5 soll "Buzz" anstelle der Zahl zurückgegeben werden
    Für Zahlen, die ein Vielfaches von 3 und 5 sind, soll "FizzBuzz" anstelle der Zahl zurückgegeben werden
*/

    [TestClass]
    public class FizzBuzzTests
    {
        [TestMethod]
        [DataRow(1,"1")]
        [DataRow(2,"2")]
        [DataRow(3,"Fizz")]
        [DataRow(5,"Buzz")]
        [DataRow(6,"Fizz")]
        [DataRow(15,"FizzBuzz")]
        public void TestFizzBuzz(int number, string expectedResult) {
            var instance = new FizzBuzz();
            Assert.AreEqual(expectedResult, instance.Calculate(number));
        }
}

    public class FizzBuzz {
        private const int FizzDivider = 3;
        private const int BuzzDivider = 5;

        public String Calculate(int number)
        {
            bool isMultipleOf3 = IsMultipleOf(number, FizzDivider);
            bool isMultipleOf5 = IsMultipleOf(number, BuzzDivider);

            if (isMultipleOf3 && isMultipleOf5)
            {
                return "FizzBuzz";
            }
            if (isMultipleOf3)
            {
                return "Fizz";
            }
            if (isMultipleOf5)
            {
                return "Buzz";
            }
            return number.ToString();
        }

        private static bool IsMultipleOf(int number, int divider)
        {
            return number % divider == 0;
        }
    }
}
