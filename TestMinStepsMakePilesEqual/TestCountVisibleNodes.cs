using InterviewQuestions.Microsoft;
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

            Node root = new Node(5);
            root.left = new Node(3);
            root.right = new Node(10);
            
            root.left.left = new Node(20);
            root.left.right = new Node(21);
            root.right.left = new Node(1);

            int count = 0;
            count = CountVisibleNodes.CountNodes(root);

            Assert.Equal(4, count);
            Console.WriteLine(count);
        }
    }
}
