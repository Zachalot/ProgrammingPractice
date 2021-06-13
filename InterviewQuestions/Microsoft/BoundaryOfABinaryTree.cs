using InterviewQuestions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions.Microsoft
{
    /*
     * 
     * https://leetcode.com/problems/boundary-of-binary-tree/
     * 
     The boundary of a binary tree is the concatenation of the root, the left boundary, the leaves ordered from left-to-right, and the reverse order of the right boundary.

    The left boundary is the set of nodes defined by the following:

    The root node's left child is in the left boundary. If the root does not have a left child, then the left boundary is empty.
    If a node in the left boundary and has a left child, then the left child is in the left boundary.
    If a node is in the left boundary, has no left child, but has a right child, then the right child is in the left boundary.
    The leftmost leaf is not in the left boundary.
    The right boundary is similar to the left boundary, except it is the right side of the root's right subtree. Again, the leaf is not part of the right boundary, and the right boundary is empty if the root does not have a right child.

    The leaves are nodes that do not have any children. For this problem, the root is not a leaf.

    Given the root of a binary tree, return the values of its boundary.
     
    Example:

    Input: root = [1,null,2,3,4]
    Output: [1,3,4,2]
    Explanation:
    - The left boundary is empty because the root does not have a left child.
    - The right boundary follows the path starting from the root's right child 2 -> 4.
        4 is a leaf, so the right boundary is [2].
    - The leaves from left to right are [3,4].
    Concatenating everything results in [1] + [] + [3,4] + [2] = [1,3,4,2].
     */
    public class BoundaryOfABinaryTree
    {

        public int rightBoundaryCount = 0;
        public IList<int> BoundaryOfBinaryTree(TreeNode root)
        {

            if (root.left == null && root.right == null)
                return new List<int>() { root.val.GetValueOrDefault() };

            List<int> answer = new List<int>() { root.val.GetValueOrDefault() };
            List<int> leftBoundary = new List<int>();
            List<int> rightBoundary = new List<int>();
            List<int> leafBoundary = new List<int>();

            if (root.left != null)
                DetermineLeftBoundary(root.left, ref leftBoundary, true, true, false);

            if (root.right != null)
                DetermineRightBoundary(root.right, ref rightBoundary, true, true, false);

            DetermineLeaves(root, ref leafBoundary);

            leftBoundary.Reverse();
            answer.AddRange(leftBoundary);
            answer.AddRange(leafBoundary);
            //rightBoundary.Reverse();
            answer.AddRange(rightBoundary);

            Console.WriteLine("leftBoundary: " + leftBoundary.Count());
            Console.WriteLine("leafBoundary: " + leafBoundary.Count());
            Console.WriteLine("rightBoundary: " + rightBoundary.Count());
            return answer;
        }

        public List<int> ReverseList(ref List<int> toReverse)
        {

            List<int> reversed = new List<int>();

            for (int i = toReverse.Count() - 1; i > 0; --i)
            {

                reversed.Add(toReverse[i]);
            }

            return reversed;
        }

        public void DetermineLeaves(TreeNode root, ref List<int> leafBoundary)
        {

            if (root.left == null && root.right == null)
            {

                leafBoundary.Add(root.val.GetValueOrDefault());
                return;
            }

            if (root.left != null)
            {

                DetermineLeaves(root.left, ref leafBoundary);
            }

            if (root.right != null)
                DetermineLeaves(root.right, ref leafBoundary);



        }

        public void DetermineRightBoundary(TreeNode root, ref List<int> rightBoundary, bool meRight, bool parentRight, bool grandParentRight)
        {

            if (root.left == null && root.right == null)
                return;

            if (root.right != null)
                DetermineRightBoundary(root.right, ref rightBoundary, true, meRight, parentRight);

            if (root.left != null && root.right == null && meRight)
            {

                DetermineRightBoundary(root.left, ref rightBoundary, true, meRight, parentRight);
            }
            else if (root.left != null)
            {

                DetermineRightBoundary(root.left, ref rightBoundary, false, meRight, parentRight);
            }


            if (parentRight && meRight)
            {
                Console.WriteLine("right boundary execute: " + (rightBoundaryCount++) + " thisNode: " + root.val);

                rightBoundary.Add(root.val.GetValueOrDefault());
                return;
            }

            if (grandParentRight && meRight)
            {
                Console.WriteLine("right boundary execute: " + (rightBoundaryCount++) + " thisNode: " + root.val);

                rightBoundary.Add(root.val.GetValueOrDefault());
                return;
            }
        }

        public void DetermineLeftBoundary(TreeNode root, ref List<int> leftBoundary, bool meLeft, bool parentLeft, bool grandParentLeft)
        {

            if (root.left == null && root.right == null)
                return;

            if (root.left != null)
                DetermineLeftBoundary(root.left, ref leftBoundary, true, meLeft, parentLeft);

            if (root.right != null && root.left == null && meLeft)
            { // I am in the left boundary, I dont have a left child, but I DO have a right child 

                DetermineLeftBoundary(root.right, ref leftBoundary, true, meLeft, parentLeft);
            }
            else if (root.right != null)
            {

                DetermineLeftBoundary(root.right, ref leftBoundary, false, meLeft, parentLeft);
            }



            if (parentLeft && meLeft)
            {

                leftBoundary.Add(root.val.GetValueOrDefault());
                return;
            }


            if (grandParentLeft && meLeft)
            {

                leftBoundary.Add(root.val.GetValueOrDefault());
                return;
            }
        }
    }
}
