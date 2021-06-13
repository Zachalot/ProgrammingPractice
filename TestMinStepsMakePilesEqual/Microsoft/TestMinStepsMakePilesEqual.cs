using InterviewQuestions.Microsoft;
using System;
using Xunit;

namespace TestMinStepsMakePilesEqual
{
    public class TestMinStepsMakePilesEqual
    {
        [Fact]
        public void Test1()
        {
            int[] piles = new int[3] { 5, 2, 1 };
            int expectedSteps = 3;

            int actualSteps = MinStepsMakePilesEqual.FindMinSteps(piles);

            Assert.Equal(expectedSteps, actualSteps);
        }

        [Fact]
        public void Test2()
        {
            int[] piles = new int[10] { 1, 1, 2, 2, 2, 3, 3, 3, 4, 4 };
            int expectedSteps = 15;

            int actualSteps = MinStepsMakePilesEqual.FindMinSteps(piles);

            Assert.Equal(expectedSteps, actualSteps);

        }
    }
}
