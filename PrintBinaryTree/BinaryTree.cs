using System.Collections.Generic;

namespace PrintBinaryTree
{
    class BinaryTree
    {
        private int _data;
        private BinaryTree _left;
        private BinaryTree _right;

        public BinaryTree(int data)
        {
            _data = data;
        }

        public int Data
        {
            get
            {
                return _data;
            }
        }

        public BinaryTree Left
        {
            get
            {
                return _left;
            }
            set
            {
                _left = value;
            }
        }

        public BinaryTree Right
        {
            get
            {
                return _right;
            }
            set
            {
                _right = value;
            }
        }

        // Prints out the binary tree in comma separated level order
        public string toString()
        {
            // start with root node
            BinaryTree root = this;
            Queue<BinaryTree> children = new Queue<BinaryTree>();
            children.Enqueue(root);

            return formatForString(children);
        }

        private string formatForString(Queue<BinaryTree> nodes)
        {
            string output = "";
            Queue<BinaryTree> children = new Queue<BinaryTree>();

            // Iterate through each item in nodes
            foreach (BinaryTree node in nodes)
            {
                // Add current node's value to output
                output += node._data + ", ";

                // Add current node's children to list if they exist
                if (node._left != null)
                {
                    children.Enqueue(node._left);
                }

                if (node._right != null)
                {
                    children.Enqueue(node._right);
                }
            }

            // Call again on children if there are any
            if (children.Count > 0)
            {
                output += formatForString(children);
            }

            return output;
        }
    }
}
