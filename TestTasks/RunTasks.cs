using System;
using System.Runtime.Serialization;

namespace Tasks {
    internal class Program {
        public static void Main(string[] args) {
            TestBinaryTree();
        }

        public static void TestList() {
            var list = new LinkedList();
            list.InsertLast(5);
            list.InsertLast(7);
            list.InsertLast(9);
            list.PrintContent();
            list.InsertInPlace(0, 8);
            list.InsertInPlace(1, 8);
            list.PrintContent();
            list.DeleteInPlace(1);
            list.DeleteInPlace(1);
            list.PrintContent();
            list.DeleteLast();
            list.PrintContent();
        }

        public static void TestBinaryTree() {
            BinaryNode root = new BinaryNode(5);
            root.AddNode(new BinaryNode(10));
            root.AddNode(new BinaryNode(4));
            var node2 = new BinaryNode(7);
            root.AddNode(node2);
            root.AddNode(new BinaryNode(12));
            root.AddNode(new BinaryNode(6));
            root.AddNode(new BinaryNode(8));
            var node = new BinaryNode(11);
            root.AddNode(node);
            // root.AddNode(new BinaryNode(13));
            node2.DeleteNode();
            node.DeleteNode();

            Console.Read();

        }
    }


}