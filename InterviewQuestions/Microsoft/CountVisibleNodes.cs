using InterviewQuestions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewQuestions.Microsoft
{
    /*
     
        
     */
    public static class CountVisibleNodes
    {
        public static int CountNodes(TreeNode node) {
            int maxNode = 0;
            int count = 0;

            PreOrder(node, ref count, node.val.GetValueOrDefault());

            return count;
        }

        // Bass by ref solution
        public static void PreOrder(TreeNode node, ref int count, int maxNode)
        {
            if (node == null)
                return;

            if (node.val >= maxNode) {
                maxNode = node.val.GetValueOrDefault();
                count = count + 1;
            }

            PreOrder(node.left, ref count, maxNode);

            PreOrder(node.right, ref count, maxNode);


        }
    }
}
