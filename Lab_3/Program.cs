using System;
using System.Reflection.Metadata;

namespace BST
{
    public class Node
    {
        public int key;
        public object value;
        public Node left, right;

        public Node(int key, object value)
        {
            this.key = key;
            this.value = value;
            left = null;
            right = null;
        }
    }


    public class BinarySearchTree
    {
        private Node root;
        private int count;

        public BinarySearchTree()
        {
            root = null;
            count = 0;
        }

        public int Size()
        {
            return count;
        }

        public void Add(int key, object value)
        {
            root = addNode(root, key, value);
        }

        private Node addNode(Node node, int key, object value)
        {
            if (node == null)
            {
                node = new Node(key, value);
                count++;
            }

            else if (key < node.key)
            {
                node.left = addNode(node.left, key, value);
            }

            else if (key > node.key)
            {
                node.right = addNode(node.right, key, value);
            }
            else
            {
                node.value = value;
            }

            return node;
        }

        public object Search(int key)
        {
            Node node = searchNode(root, key);
            if (node == null)
                return false;

            else
                return node.value;

        }

        private Node searchNode(Node node, int key)
        {
            if (node == null || node.key == key)
                return node;

            else if (key < node.key)
            {
                return searchNode(node.left, key);
            }
            else
                return searchNode(node.right, key);
        }

        public Tuple<int, object> Largest()
        {
            if (root == null)
                return new Tuple<int, object>(default, default);

            Node node = root;

            while (node.right != null)
            {
                node = node.right;
            }
            return new Tuple<int, object>(node.key, node.value);
        }

        public Tuple<int, object> Smallest()
        {
            if (root == null)
                return new Tuple<int, object>(default, default);

            Node node = root;

            while (node.left != null)
            {
                node = node.left;
            }
            return new Tuple<int, object>(node.key, node.value);
        }

        public bool Remove(int key)
        {
            Node parent = null;
            Node node = root;

            // Find the node to be removed
            while (node != null && node.key != key)
            {
                parent = node;
                if (key < node.key)
                {
                    node = node.left;
                }
                else
                {
                    node = node.right;
                }
            }

            // If the node was not found, return false
            if (node == null)
            {
                return false;
            }

            // If the node has two children, find the maximum node in the left subtree
            if (node.left != null && node.right != null)
            {
                Node maxParent = node;
                Node maxNode = node.left;
                while (maxNode.right != null)
                {
                    maxParent = maxNode;
                    maxNode = maxNode.right;
                }

                // Replace the node to be removed with the maximum node
                node.key = maxNode.key;
                node.value = maxNode.value;

                // Remove the maximum node
                parent = maxParent;
                node = maxNode;
            }

            // If the node has one child or no children, update the parent's reference
            Node child;
            if (node.left != null)
            {
                child = node.left;
            }
            else
            {
                child = node.right;
            }

            if (parent == null)
            {
                root = child;
            }
            else if (node == parent.left)
            {
                parent.left = child;
            }
            else
            {
                parent.right = child;
            }

            count--;
            return true;
        }


        public List<int> InorderWalk()
        {
            List<int> keys = new List<int>();
            inorderWalk(root, keys);
            return keys;
        }

        private void inorderWalk(Node node, List<int> keys)
        {
            if (node != null)
            {
                inorderWalk(node.left, keys);
                keys.Add(node.key);
                inorderWalk(node.right, keys);
            }
        }

        public List<int> PreorderWalk()
        {
            List<int> keys = new List<int>();
            preorderWalk(root, keys);
            return keys;
        }

        private void preorderWalk(Node node, List<int> keys)
        {
            if (node != null)
            {
                keys.Add(node.key);
                preorderWalk(node.left, keys);
                preorderWalk(node.right, keys);
            }
        }

        public List<int> PostorderWalk()
        {
            List<int> keys = new List<int>();
            postorderWalk(root, keys);
            return keys;
        }

        private void postorderWalk(Node node, List<int> keys)
        {
            if (node != null)
            {
                postorderWalk(node.left, keys);
                postorderWalk(node.right, keys);
                keys.Add(node.key);
            }
        }

    }

    public class Program
    {
        public static void Main()
        {
            BinarySearchTree bst;

            bst = new BinarySearchTree();
            bst.Add(10, "Value for 10");
            bst.Add(52, "Value for 52");
            bst.Add(5, "Value for 5");
            bst.Add(8, "Value for 8");
            bst.Add(1, "Value for 1");
            bst.Add(40, "Value for 40");
            bst.Add(30, "Value for 30");
            bst.Add(45, "Value for 45");


            Console.WriteLine( bst.Smallest());
            bst.Add(6, "Value for 6");
            bst.Add(4, "Value for 4");
            bst.Add(0, "Value for 0");
            bst.Add(32, "Value for 32");
            Console.WriteLine(bst.Smallest());

        }
    }
}
