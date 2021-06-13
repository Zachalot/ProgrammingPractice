using InterviewQuestions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.BinaryTreeUtilities;
using Xunit;

namespace UnitTests.Utilities
{
    public class TestBinaryTreeUtilities
    {

        [Fact]
        public void TestCreateTreeFromArray() {

            int?[] inputArr = new int?[11] { 5, 1, 4, 8, 3, null, 7, null, null, 11, 12 };

            TreeNode root = BinaryTreeUtilities.CreateTree(inputArr);

            TreeNode expectedRoot = new TreeNode(5);
            expectedRoot.left = new TreeNode(1);
            expectedRoot.right = new TreeNode(4);
            expectedRoot.left.left = new TreeNode(8);
            expectedRoot.left.right = new TreeNode(3);
            expectedRoot.left.right.left = new TreeNode(11);
            expectedRoot.left.right.right = new TreeNode(12);

            expectedRoot.right.right = new TreeNode(7);


            Assert.Equal(expectedRoot.val, root.val);
            Assert.Equal(expectedRoot.left.val, root.left.val);
            Assert.Equal(expectedRoot.right.val, root.right.val);
            Assert.Equal(expectedRoot.left.left.val, root.left.left.val);
            Assert.Equal(expectedRoot.left.right.val, root.left.right.val);
            Assert.Equal(expectedRoot.left.right.left.val, root.left.right.left.val);
            Assert.Equal(expectedRoot.left.right.right.val, root.left.right.right.val);

        }
    }
}
