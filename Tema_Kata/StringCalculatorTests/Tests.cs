using StringCalculatorKata;

namespace StringCalculatorTests
{
    public class Tests
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void Setup()
        {
            _stringCalculator = new StringCalculator();
        }

        [Test]
        public void Add_EmptyString_WorksAsExpected()
        {
            Assert.AreEqual(0, _stringCalculator.Add(""));
        }

        [Test]
        public void Add_OneNumber_WorksAsExpected()
        {
            Assert.AreEqual(1, _stringCalculator.Add("1"));
        }

        [Test]
        public void Add_TwoNumbers_WorksAsExpected()
        {
            Assert.AreEqual(3, _stringCalculator.Add("1,2"));
        }

        [Test]
        public void Add_MultipleNumbers_WorksAsExpected()
        {
            Assert.AreEqual(10, _stringCalculator.Add("1,2,3,4"));
        }

        [Test]
        public void Add_IncorrectInput_WorksAsExpected()
        {
            Assert.AreEqual(0, _stringCalculator.Add("a,b,c"));
        }

        [Test]
        public void Add_HandlesNewLines()
        {
            Assert.AreEqual(10, _stringCalculator.Add("1\n2\n3,4"));
        }

        [Test]
        public void Add_SupportsDifferentDelimiters_WithoutNewLines_NewDelimiter()
        {
            Assert.AreEqual(3, _stringCalculator.Add("//;\n1;2"));
        }

        [Test]
        public void Add_SupportsDifferentDelimiters_WithoutNewLines_DefaultDelimiter()
        {
            Assert.AreEqual(3, _stringCalculator.Add("//,\n1,2"));
        }

        [Test]
        public void Add_SupportsDifferentDelimiters_WithNewLines_NewDelimiter()
        {
            Assert.AreEqual(6, _stringCalculator.Add("//;\n1\n2;3"));
        }

        [Test]
        public void Add_SupportsDifferentDelimiters_WithNewLines_DefaultDelimiter()
        {
            Assert.AreEqual(6, _stringCalculator.Add("//,\n1\n2,3"));
        }

        [Test]
        public void Add_ThrowsException_ForOneNegative()
        {
            Assert.Throws<InvalidOperationException>(() => _stringCalculator.Add("-1"));
        }

        [Test]
        public void Add_ThrowsException_ForMultipleNegatives_WithoutNewLines()
        {
            Assert.Throws<InvalidOperationException>(() => _stringCalculator.Add("-1,2,-3,4"));
        }

        [Test]
        public void Add_ThrowsException_ForMultipleNegatives_WithNewLines()
        {
            Assert.Throws<InvalidOperationException>(() => _stringCalculator.Add("-1,2\n-3\n4"));
        }

        [Test]
        public void Add_ThrowsException_ForMultipleNegatives_WithDifferentDelimiter()
        {
            Assert.Throws<InvalidOperationException>(() => _stringCalculator.Add("//;\n-1;2;-3\n4"));
        }

        [Test]
        public void Add_HandlesBigNumbers_ForOneNumber()
        {
            Assert.AreEqual(0, _stringCalculator.Add("1001"));
        }

        [Test]
        public void Add_HandlesBigNumbers_ForMultipleNumbers()
        {
            Assert.AreEqual(1999, _stringCalculator.Add("999,1000,1001,1002"));
        }

        [Test]
        public void Add_ExtraDelimiterBrackets_ForOneCharacter()
        {
            Assert.AreEqual(3, _stringCalculator.Add("//[,]\n1,2"));
        }

        [Test]
        public void Add_ExtraDelimiterBrackets_ForMultipleCharacters()
        {
            Assert.AreEqual(3, _stringCalculator.Add("//[,,,]\n1,,,2"));
        }

        [Test]
        public void Add_MultipleDelimiters_OfOneCharacter_ForOneNumber()
        {
            Assert.AreEqual(1, _stringCalculator.Add("//[,][;][~]\n1"));
        }

        [Test]
        public void Add_MultipleDelimiters_OfOneCharacter_OneMultipleNumbers()
        {
            Assert.AreEqual(15, _stringCalculator.Add("//[,][;][~]\n1,2;3~4\n5"));
        }

        [Test]
        public void Add_MultipleDelimiters_OfMultipleCharacters_ForOneNumber()
        {
            Assert.AreEqual(1, _stringCalculator.Add("//[,,][;*][~^]\n1"));
        }

        [Test]
        public void Add_MultipleDelimiters_OfMultipleCharacters_OneMultipleNumbers()
        {
            Assert.AreEqual(15, _stringCalculator.Add("//[,,][;*][~^]\n1,,2;*3~^4\n5"));
        }
    }
}