using RomanNumbers;

namespace ConversionsTests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{

        //}


        [DataTestMethod]
        [DataRow(1, "I")]
        [DataRow(4, "IV")]
        [DataRow(9, "IX")]
        [DataRow(58, "LVIII")]
        [DataRow(1990, "MCMXC")]
        [DataRow(2022, "MMXXII")]
        [DataRow(3999, "MMMCMXCIX")]
        public void IntToRoman_ShouldReturnCorrectRomanNumeral(int input, string expected)
        {
            var result = Conversions.IntToRoman(input);
            Assert.AreEqual(expected, result);
        }



        [DataTestMethod]
        [DataRow("I", 1)]
        [DataRow("IV", 4)]
        [DataRow("IX", 9)]
        [DataRow("LVIII", 58)]
        [DataRow("MCMXC", 1990)]
        [DataRow("MMXXII", 2022)]
        [DataRow("MMMCMXCIX", 3999)]
        public void RomanToInteger_ShouldReturnCorrectInteger(string roman, int expected)
        {
            var result = Conversions.RomanToInteger(roman);
            Assert.AreEqual(expected, result);
        }

    }
}