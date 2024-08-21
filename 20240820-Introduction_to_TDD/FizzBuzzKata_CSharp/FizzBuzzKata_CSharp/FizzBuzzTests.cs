namespace FizzBuzzKata_CSharp
{
/*
    FizzBuzz Kata
    https://codingdojo.org/kata/FizzBuzz/
    https://kata-log.rocks/fizz-buzz-kata

    Write a function that receives a positive integer as input and returns the number as string. 
    
    For multiples of three return "Fizz" instead of the number.
    
    For multiples of five return "Buzz" instead of the number.

    For numbers which are multiples of both three and five return "FizzBuzz".
*/



    [TestClass]
    public class FizzBuzzTests
    {    
        public string fizzbuzz(int number) {
            bool isMultipleOf3 = number % 3 == 0;
            bool isMultipleOf5 = number % 5 == 0;

            if (isMultipleOf3 && isMultipleOf5)	
                return "FizzBuzz";

            if (isMultipleOf3)
                return "Fizz";       

            if (isMultipleOf5)
                return "Buzz"; 

            return number.ToString();
        }
        
        [TestMethod]
        [DataRow(1,"1")]
        [DataRow(2,"2")]
        [DataRow(3,"Fizz")]
        [DataRow(6,"Fizz")]
        [DataRow(5,"Buzz")]
        [DataRow(15,"FizzBuzz")]
        public void FizzBuzzTest(int number, string expectedResult) {
            var result = fizzbuzz(number);
            Assert.AreEqual(expectedResult, result);
        }
    }

    [TestClass]
    public class ExampleTests
    {
        [TestMethod]
        public void IsOneEven() {
            var number = 1;
            var result = number%2==0;
            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow(1,false)]
        [DataRow(2,true)]
        public void IsNumberEvenParametricTest(int number, bool expectedResult) {
            var result = number%2==0;
            Assert.AreEqual(expectedResult, result);
        }
    }
}