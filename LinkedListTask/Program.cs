using System;
using System.Runtime.Serialization;

namespace LinkedListTask {
    internal class Program {
        public static void Main(string[] args) {
            LinkedList list = new LinkedList();
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
    }

    internal class ListException : Exception {
        public ListException() {
        }

        public ListException(string message) : base(message) {
        }

        public ListException(string message, Exception innerException) : base(message, innerException) {
        }

        protected ListException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }


    internal class LinkedList {
        private uint _len = 0;
        private Node _head = null;

        public LinkedList() {
        }

        public void InsertLast(int info) {
            if (_len == 0)
            {
                _head = new Node(info);
            }
            else
            {
                _head.InsertNode(_len -1, new Node(info));
            }

            _len++;
        }

        public void InsertInPlace(uint place, int info) {
            if (place > _len - 1)
            {
                throw new ListException(
                    $"Cant insert node. Number of node to insert is too big. Current size of list = {_len}");
            }
            _head.InsertNode(place, new Node(info));
            _len++;
        }

        public void PrintContent() {
            Console.Write(_head.Information + " ");
            var node = _head.Next();
            while (node != null)
            {
                Console.Write(node.Information + " ");
                node = node.Next();
            }
            Console.WriteLine();
        }

        public void DeleteLast() {
            _head.DeleteNode(_len - 1);
            _len--;
        }

        public void DeleteInPlace(uint place) {
            if (place > _len - 1)
            {
                throw new ListException(
                    $"Cant insert node. Number of node to delete is too big. Current size of list = {_len}");
            }
            if (place == 0)
                _head = _head.DeleteNode();
            else
            {
                _head.DeleteNode(place);
            }

            _len--;
        }
    }

    internal class Node {
        private Node _nextNode;
        private Node _prevNode;
        public int Information { get; }

        public Node(int information) {
            Information = information;
            _nextNode = null;
            _prevNode = null;
        }

        private void AddNode(Node nextNode) {
            _nextNode = nextNode;
            nextNode._prevNode = this;
        }

        public Node Next() {
            return _nextNode;
        }

        public void InsertNode(uint numberOfNode, Node nodeToInsert) {
            var i = 0;
            var node = this;
            while (node != null && i < numberOfNode)
            {
                node = node.Next();
                i++;
            }
            var nextToInsertedNode = node._nextNode;
            node.AddNode(nodeToInsert);
            if (nextToInsertedNode != null)
                nodeToInsert.AddNode(nextToInsertedNode);
        }


        public void DeleteNode(uint numberOfNode) {
            if (numberOfNode < 1)
            {
                throw new ListException("Number of node should be > 0");
            }

            var i = 1;
            var node = Next();
            while (node != null && i < numberOfNode)
            {
                node = node.Next();
                i++;
            }

            if (node == null)
            {
                throw new ListException(
                    $"Cant insert node. Number of node to insert is too big. Current size of list = {i}");
            }

            var nextToDeletedNode = node._nextNode;
            var prevToDeletedNode = node._prevNode;
            if (nextToDeletedNode != null)
            {
                prevToDeletedNode.AddNode(nextToDeletedNode);
            }
            else
            {
                prevToDeletedNode._nextNode = null;
            }

            node._nextNode = null;
            node._prevNode = null;
        }

        public Node DeleteNode() {
            var toReturn = Next();
            _nextNode = null;
            _prevNode = null;
            return toReturn;
        }
    }
}