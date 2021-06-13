using InterviewQuestions.Microsoft;
using InterviewQuestions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{

    public class TestCountVisibleNodes
    {

        [Fact]
        public void Test1() {

                        /*
                     5
                    / \
                  3       10
                 / \   /
                20 21 1
            */

            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.right = new TreeNode(10);
            
            root.left.left = new TreeNode(20);
            root.left.right = new TreeNode(21);
            root.right.left = new TreeNode(1);

            int count = 0;
            count = CountVisibleNodes.CountNodes(root);

            Assert.Equal(4, count);
            Console.WriteLine(count);
        }
    }
}
