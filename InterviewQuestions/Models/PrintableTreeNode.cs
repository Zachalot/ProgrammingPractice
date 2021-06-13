using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewQuestions.Models
{
    public class PrintableTreeNode
    {
        public TreeNode Node;
        public PrintableTreeNode Parent;
        public PrintableTreeNode Left;
        public PrintableTreeNode Right;

        public string Text;
        public int StartPos;
        public int Size { get { return Text.Length; } }
        public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }



    }
}
