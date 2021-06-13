using InterviewQuestions;
using InterviewQuestions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities.BinaryTreeUtilities;
using Xunit;

namespace UnitTests.Microsoft
{
    public class TestBoundaryOfABinaryTree
    {
        /*
         * https://leetcode.com/problems/boundary-of-binary-tree/
         * 
         * Input: root = [1,null,2,3,4]
         * Output: [1,3,4,2]
         * 
         */

        [Fact]
        public void TestExample1() 
        {
            int?[] nodeArr = new int?[6] { 1, null, 2, 3, 4, 5 };

            TreeNode root = BinaryTreeUtilities.CreateTree(nodeArr);
            root.LevelOrderPrint();

            Assert.True(true);
        }
    }
}
