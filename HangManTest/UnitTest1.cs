using System;
using Xunit;
using System.Text;

namespace HangManTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new char[] { 't', 'e', 's', 't' }, "test")]
        [InlineData(new char[] { 'L', 'O', 'v', 'E' }, "LOvE")]
        [InlineData(new char[] { 'H', 'A', 'p', 'p', 'Y' }, "HAppY")]
        public void TestArrayToString(char[] test, string stringTest)
        {
            string result = HangMan.Program.ArrayToString(test);

            Assert.Equal(stringTest, result);
        }
        [Fact]
        public void TestWordPickEasy()
        {
            for (int i = 0; i < 10000; i++)
            {
                string result = HangMan.Program.WordPickEasy();

                Assert.NotNull(result);
            }
        }

        [Fact]
        public void TestWordPickMedium()
        {
            for (int i = 0; i < 10000; i++)
            {
                string result = HangMan.Program.WordPickMedium();

                Assert.NotNull(result);
            }
        }

        [Fact]
        public void TestWordPickHard()
        {
            for (int i = 0; i < 10000; i++)
            {
                string result = HangMan.Program.WordPickHard();

                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData(new char[] { 'H', 'A', 'P', 'P', 'Y' }, "HAPPY", 'P')]
        [InlineData(new char[] { 'L', 'O', 'V', 'E' }, "LOVE", 'O')]
        [InlineData(new char[] { 'S', 'H', 'A', 'L', 'L', 'O', 'W' }, "SHALLOW", 'L')]
        public void TestTryInputToCorrectGuessesCorrectGuess(char[] correctGuesses, string secretWord, char inputChar)
        {
            bool result = HangMan.Program.TryInputToCorrectGuesses(correctGuesses, secretWord, inputChar);

            Assert.True(result);
        }

        [Theory]
        [InlineData(new char[] { 'H', 'A', 'P', 'P', 'Y' }, "HAPPY", 'E')]
        [InlineData(new char[] { 'L', 'O', 'V', 'E' }, "LOVE", 'T')]
        [InlineData(new char[] { 'S', 'H', 'A', 'L', 'L', 'O', 'W' }, "SHALLOW", 'K')]
        public void TestTryInputToCorrectGuessesIncorrectGuess(char[] correctGuesses, string secretWord, char inputChar)
        {
            bool result = HangMan.Program.TryInputToCorrectGuesses(correctGuesses, secretWord, inputChar);

            Assert.False(result);
        }

        [Theory]
        [InlineData("A F G", 'F')]
        [InlineData("G H K L W", 'H')]
        [InlineData("F Y W Q V X", 'Y')]
        public void TestTryInputToIncorrectGuessesOldGuess(string incorrectGuesses, char inputChar)
        {
            StringBuilder sb = new StringBuilder(incorrectGuesses);

            bool result = HangMan.Program.TryInputToIncorrectGuesses(sb, inputChar);

            Assert.True(result);
        }

        [Theory]
        [InlineData("A F G", 'E')]
        [InlineData("G H K L W", 'Z')]
        [InlineData("F Y W Q V X", 'P')]
        public void TestTryInputToIncorrectGuessesNotOldGuess(string incorrectGuesses, char inputChar)
        {
            StringBuilder sb = new StringBuilder(incorrectGuesses);

            bool result = HangMan.Program.TryInputToIncorrectGuesses(sb, inputChar);

            Assert.False(result);
        }
        
        [Theory]
        [InlineData(new char[] {'_', '_', '_', '_', '_' }, "HAPPY", 'P', "_ _ P P _ ")]
        [InlineData(new char[] {'L', '_', '_', '_'}, "LOVE", 'V', "L _ V _ ")]
        public void TestAddInputToCorrectGuesses(char[] correctGuesses, string secretWord, char inputChar, string expectedResult)
        {
            char[] result = HangMan.Program.AddInputToCorrectGuesses(correctGuesses, secretWord, inputChar);

            StringBuilder resultString = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                resultString.Append(result[i] + " ");
            }

            Assert.Equal(resultString.ToString(), expectedResult);
        }

    } // End of class
} // End of namespace 
