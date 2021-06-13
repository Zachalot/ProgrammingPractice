using InterviewQuestions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Models
{
    public class TestTreeNode
    {

        [Fact]
        public void TestPrint() {

            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(1);
            root.right = new TreeNode(4);
            root.right.right = new TreeNode(7);
            root.left.right = new TreeNode(3);
            root.left.left = new TreeNode(8);

            root.PrintTree();
        }
    }
}
