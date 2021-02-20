﻿using System;
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
            var tree = new BinaryTree();
            tree.Add(5);
            tree.Add(4);
            tree.Add(10);
            tree.Add(7);
            tree.Add(12);
            tree.Add(6);
            tree.Add(8);
            tree.Add(11);
            tree.Add(13);
            tree.PrintTree();
            tree.Delete(10);
            tree.Delete(8);
            tree.PrintTree();
            tree.Delete(5);
            tree.PrintTree();
            tree.Delete(6);
            tree.Delete(12);
            tree.Delete(11);
            tree.Delete(13);
            tree.Delete(4);
            tree.PrintTree();
        }
    }


}