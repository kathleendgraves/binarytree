using System;
using System.Collections.Generic;

namespace PrintBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt user for input string
            Console.WriteLine("Enter a comma separated list of integer values.");
            string input = Console.ReadLine();

            // Validate
            try
            {
                validateInput(input);

                // Build binary tree from input
                BinaryTree tree = loadTreeFromString(input);

                // Output binary tree in level order
                Console.Write("The binary tree, in level order: ");
                Console.WriteLine(tree.toString());

                //TODO Display string as binary tree?
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            //TODO Keep window open a little longer

        }

        private static void validateInput(string input)
        {
            if (input.Length == 0)
            {
                throw new ArgumentException("Please enter a string.");
            }
            else if (!input.Contains(","))
            {
                throw new ArgumentException("Please separate the integer values with a comma.");
            }
        }

        // ex: 5, 2, 6, 7, 8, 1, 9
        private static BinaryTree loadTreeFromString(string input)
        {
            // Convert to queue for consumption
            Queue<int> valueList = convertStringToQueue(input);

            // Create root node
            BinaryTree root = new BinaryTree(valueList.Dequeue());

            // Create queue to be processed
            Queue<BinaryTree> nodeList = new Queue<BinaryTree>();
            nodeList.Enqueue(root);

            // Build the binary tree
            buildNodes(nodeList, valueList);

            return root;
        }
        
        // Builds the binary tree recursively using the input
        private static void buildNodes(Queue<BinaryTree> nodeList, Queue<int> valueList)
        {
            Queue<BinaryTree> childrenList = new Queue<BinaryTree>();

            foreach (BinaryTree node in nodeList)
            {
                BinaryTree left, right;
                if (valueList.Count > 0)
                {
                    left = new BinaryTree(valueList.Dequeue());

                    node.Left = left;
                    childrenList.Enqueue(left);
                }

                if (valueList.Count > 0)
                {
                    right = new BinaryTree(valueList.Dequeue());

                    node.Right = right;
                    childrenList.Enqueue(right);
                }

            }

            if (valueList.Count > 0)
            {
                buildNodes(childrenList, valueList);
            }

        }

        // Converts a string to a queue of integers, throws an error if input is not valid
        private static Queue<int> convertStringToQueue(string input)
        {
            // Convert string to array
            string[] strArray = input.Split(',');

            // Create queue<int> to be populated
            Queue<int> intList = new Queue<int>();

            int parseValue;
            foreach (string strVal in strArray)
            {
                // convert to int
                bool parseSuccess = int.TryParse(strVal, out parseValue);
                if (parseSuccess)
                {
                    intList.Enqueue(parseValue);
                }
                else
                {
                    throw new ArgumentException(strVal + " is not a valid integer.");
                }
            }

            return intList;
        }
    }
}
