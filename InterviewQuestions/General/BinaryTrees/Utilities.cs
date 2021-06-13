using InterviewQuestions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewQuestions.General.BinaryTrees
{
    public static class Utilities
    {
        public static TreeNode CreateTree(int?[] array)
        {

            if (array == null || array.Length == 0)
            {
                return null;
            }

            Queue<TreeNode> treeNodeQueue = new Queue<TreeNode>();
            Queue<int?> integerQueue = new Queue<int?>();

            for (int i = 1; i < array.Length; i++)
            {
                integerQueue.Enqueue(array[i]);
            }

            TreeNode treeNode = new TreeNode(array[0]);
            treeNodeQueue.Enqueue(treeNode);

            while (!(integerQueue.Count == 0))
            {
                int? leftVal = (integerQueue.Count == 0) ? null : integerQueue.Dequeue();
                int? rightVal = (integerQueue.Count == 0) ? null : integerQueue.Dequeue();
                TreeNode current = treeNodeQueue.Dequeue();

                if (leftVal != null)
                {
                    TreeNode left = new TreeNode(leftVal);
                    current.left = left;
                    treeNodeQueue.Enqueue(left);
                }

                if (rightVal != null)
                {
                    TreeNode right = new TreeNode(rightVal);
                    current.right = right;
                    treeNodeQueue.Enqueue(right);
                }
            }
            return treeNode;
        }

        // print a level order array of all of the nodes in the tree from root
        public static void LevelOrderPrint(this TreeNode root) {

            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();

            nodeQueue.Enqueue(root);
            TreeNode currentNode = new TreeNode(root.val);

            while (nodeQueue.Count > 0) {

                currentNode = nodeQueue.Dequeue();

                Console.Write(currentNode.val + ", ");

                if (currentNode.left != null)
                {
                    nodeQueue.Enqueue(currentNode.left);
                }
                else if (currentNode.val != null) {
                    nodeQueue.Enqueue(new TreeNode(null));
                }


                if (currentNode.right != null)
                {
                    nodeQueue.Enqueue(currentNode.right);
                }
                else if (currentNode.val != null) {
                    nodeQueue.Enqueue(new TreeNode(null));
                }
                    
            }

            Console.WriteLine();
        }

        // Convert the entire tree starting from the root to a printable tree
        public static PrintableTreeNode ToPrintableTree(this TreeNode root) 
        {
            //Stack<TreeNode> nodeStack = new Stack<TreeNode>();

            //PrintableTreeNode printableRoot = new PrintableTreeNode(); // 
            //nodeStack.Push(root);

            //while (nodeStack.Count > 0) {

            //    printableRoot.Node = nodeStack.Pop();

            //    if (printableRoot.Left != null)
            //        nodeStack.Push(printableRoot.Node.left);

            //    if (printableRoot.Right != null)
            //        nodeStack.Push(printableRoot.Node.right);

            //    if ()
            //}

            PrintableTreeNode rootPrintableTreeNode = new PrintableTreeNode();
            rootPrintableTreeNode.Node = root;

            if (root.left != null)
                rootPrintableTreeNode.Left = ToPrintableTreeHelper(root.left, rootPrintableTreeNode);

            if (root.right != null)
                rootPrintableTreeNode.Right = ToPrintableTreeHelper(root.right, rootPrintableTreeNode);

            return rootPrintableTreeNode;

        }

        // TODO: test this ... some how ...
        private static PrintableTreeNode ToPrintableTreeHelper(TreeNode root, PrintableTreeNode parent) 
        {
            if (root.left == null && root.right == null)
            {

                return new PrintableTreeNode()
                {
                    Node = root,
                    Parent = parent,
                    Left = null,
                    Right = null,
                    // I dont think I need to populate all of the other crap

                };
            }

            PrintableTreeNode currentNode = new PrintableTreeNode();
            currentNode.Parent = parent;
            currentNode.Node = root;

            if (root.left != null)
                currentNode.Left = ToPrintableTreeHelper(root.left, currentNode);

            if (root.right != null)
                currentNode.Right = ToPrintableTreeHelper(root.right, currentNode);

            return currentNode;
        }

        public static void Print(this PrintableTreeNode root, string textFormat = "0", int spacing = 1, int topMargin = 2, int leftMargin = 2)
        {
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<PrintableTreeNode>();
            var next = root;
            for (int level = 0; next != null; level++)
            {
                var item = new PrintableTreeNode { Node = next.Node, Left = next.Left, Right = next.Right, Text = next.Node.val.ToString() };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + spacing;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next.Node == item.Parent.Node.left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                    }
                }

                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    int top = rootTop + 2 * level;
                    Print(item.Text, top, item.StartPos);
                    if (item.Left != null)
                    {
                        Print("/", top + 1, item.Left.EndPos);
                        Print("_", top, item.Left.EndPos + 1, item.StartPos);
                    }
                    if (item.Right != null)
                    {
                        Print("_", top, item.EndPos, item.Right.StartPos - 1);
                        Print("\\", top + 1, item.Right.StartPos - 1);
                    }
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos + 1;
                        next = item.Parent.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos - 1;
                        else
                            item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }

        private static void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }
    }
}
