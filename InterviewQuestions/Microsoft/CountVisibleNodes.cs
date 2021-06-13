using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewQuestions.Microsoft
{
    /*
     
        
     */
    public class Node {

        public int data;
        public Node left = null;
        public Node right = null;

        public Node(int datum) {
            data = datum;
        }
    }
    public static class CountVisibleNodes
    {
        public static int CountNodes(Node node) {
            int maxNode = 0;
            int count = 0;

            PreOrder(node, ref count, node.data);

            return count;
        }

        // Bass by ref solution
        public static void PreOrder(Node node, ref int count, int maxNode)
        {
            if (node == null)
                return;

            if (node.data >= maxNode) {
                maxNode = node.data;
                count = count + 1;
            }

            PreOrder(node.left, ref count, maxNode);

            PreOrder(node.right, ref count, maxNode);


        }
    }
}
