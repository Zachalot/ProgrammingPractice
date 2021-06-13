using InterviewQuestions.General.BinaryTrees;
using InterviewQuestions.Models;
using System;

namespace InterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(1);
            root.right = new TreeNode(4);
            root.right.right = new TreeNode(7);
            root.left.right = new TreeNode(3);
            root.left.left = new TreeNode(8);

            root.LevelOrderPrint();

            PrintableTreeNode printableRoot = root.ToPrintableTree();

            printableRoot.Print();
        }
    }
}
