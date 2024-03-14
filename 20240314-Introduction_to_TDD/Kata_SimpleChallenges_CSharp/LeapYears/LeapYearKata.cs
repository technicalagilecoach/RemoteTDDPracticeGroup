namespace LeapYears

{
    [TestClass]
    public class LeapYearKata
    {
        /*
            Write a function that returns true or false depending on whether its input integer is a leap year or not.
            
            A leap year is defined as one that is divisible by 4, 
            but is not otherwise divisible by 100 
            unless it is also divisible by 400.
            
            For example, 2001 is a typical common year and 1996 is a typical leap year, whereas 1900 is an atypical common year and 2000 is an atypical leap year.
         */

        bool multipleOf(int valueToBeChecked, int factor) {
            return valueToBeChecked % factor == 0;
        }

        bool isLeapYear(int year) {
            if (multipleOf(year, 400)) {
                return true;
            }
            if (multipleOf(year, 100)) {
                return false;
            }
            if (multipleOf(year, 4)) {
                return true;
            }
            return false;
        }

        [TestMethod]
        [DataRow(1900, false)]
        [DataRow(2021, false)]
        [DataRow(2000, true)]
        [DataRow(2024, true)]
        public void TestIsLeapYear(int year, bool shouldBeLeapYear)
        {
            bool isLeapYear = this.isLeapYear(year);
            Assert.AreEqual(shouldBeLeapYear, isLeapYear);
        }
    }
}
