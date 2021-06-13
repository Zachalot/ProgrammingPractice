using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions.Microsoft
{

    public class ReverseComp : IComparer<int>
    {
        public int Compare(int a, int b)
        {

            if (a > b)
            {
                return -1;
            }
            else if (a < b)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Taken from https://leetcode.com/discuss/interview-question/364618/
    /// 
    /// Alexa is given n piles of equal or unequal heights. In one step, Alexa can remove any number of boxes 
    /// from the pile which has the maximum height and try to make it equal to the one which is just lower than the 
    /// maximum height of the stack. Determine the minimum number of steps required to make all of the piles equal in height.
    ///
    /// Example 1:
    ///
    /// Input: piles = [5, 2, 1]
    /// Output: 3
    /// Explanation:
    /// Step 1: reducing 5 -> 2 [2, 2, 1]
    /// Step 2: reducing 2 -> 1 [2, 1, 1]
    /// Step 3: reducing 2 -> 1 [1, 1, 1]
    ///     So final number of steps required is 3.
    /// 
    /// </summary>
    public static class MinStepsMakePilesEqual
    {
        public static int FindMinSteps(int[] piles) 
        {
            if (piles.Length <= 1)
                return 0;

            Array.Sort(piles, new ReverseComp());
            // return FindMinStepsHelper(piles, 1, 0);
            return FindMinStepsHelperOptimized(piles, 0);
        }

        public static int FindMinStepsHelper(int[] piles, int idx, int stepCount)
        {
            if (idx == piles.Length - 1)
                return stepCount;

            if (piles[idx] > piles[idx + 1] && idx > 0)
            {
                piles[idx] = piles[idx + 1];
                return FindMinStepsHelper(piles, idx - 1, stepCount + 1);
            }
            else if (piles[idx] > piles[idx + 1])
            {
                piles[idx] = piles[idx + 1];
                return FindMinStepsHelper(piles, idx + 1, stepCount + 1);
            }
            else
            {
                return FindMinStepsHelper(piles, idx + 1, stepCount);
            }
        }

        /// <summary>
        /// We can make the max number smaller, but we can never make small numbers bigger.
        /// In order for all of the numbers to have the same value, all numbers will have to equal the smallest number in the end
        /// We cannot skip numbers. I.E. in order for the largest number to reach the smallest number, it will have to go through all of the numbers in between. i.e. [5, 2, 1] will take 2 steps to get 5 -> 1
        ///     If all equal numbers are in a bucket, then all of the numbers in the bucket will take the same number of steps to reach the min number
        ///     If all equal numbers are in a bucket, then that entire bucket represents a "step" that will have to be traversed by numbers in the higher buckets
        /// If there is only 1 element in the array thats 0 steps
        /// </summary>
        /// <param name="piles"> ints sorted in descending order</param>
        /// <param name="idx"></param>
        /// <param name="stepCount"></param>
        /// <returns></returns>
        public static int FindMinStepsHelperOptimized(int[] piles, int stepCount) 
        {
            // First count the unique numbers, this will tell us how many steps it takes to get from the max to the min.
            int currentBucketSize = 1;

            List<int> bucketSizes = new List<int>(); // we need to know the size of each bucket too

            for (int i = 0; i < piles.Length; ++i)
            {
                if ((i == piles.Length - 1) || (piles[i] > piles[i + 1])) // check if i is at the end or we will always miss the last bucket
                {
                    bucketSizes.Add(currentBucketSize);
                    currentBucketSize = 1;
                }
                else {

                    currentBucketSize += 1;
                }  
            }

            if (currentBucketSize > 1) // if currentBucketSize > 1, then we have an unadded bucket
                bucketSizes.Add(currentBucketSize);

            int bucketsTraversed = 0;

            // traverse the piles to determine the step count. For each bucket we encounter, the number of steps required to minimize all of the elemnts in that bucekts = bucketSize * (bucketCount - bucketsTraversed -1)

            // To get to the begining of the next bucket
            while (bucketsTraversed < bucketSizes.Count()) {
                stepCount += bucketSizes.ElementAt<int>(bucketsTraversed) * (bucketSizes.Count() - bucketsTraversed - 1); // formula for determining step count
                bucketsTraversed += 1; // increment to the next bucket
            }

            return stepCount;

        }
    }
}
