using System;
using System.Runtime.Serialization;

namespace Tasks {
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
    
    public class LinkedList {
        private uint _len = 0;
        private LinkedListNode _head = null;

        public LinkedList() {
        }

        public void InsertLast(int info) {
            if (_len == 0)
            {
                _head = new LinkedListNode(info);
            }
            else
            {
                _head.InsertNode(_len -1, new LinkedListNode(info));
            }

            _len++;
        }

        public void InsertInPlace(uint place, int info) {
            if (place > _len - 1)
            {
                throw new ListException(
                    $"Cant insert node. Number of node to insert is too big. Current size of list = {_len}");
            }
            _head.InsertNode(place, new LinkedListNode(info));
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

    internal class LinkedListNode {
        private LinkedListNode _nextLinkedListNode;
        private LinkedListNode _prevLinkedListNode;
        public int Information { get; }

        public LinkedListNode(int information) {
            Information = information;
            _nextLinkedListNode = null;
            _prevLinkedListNode = null;
        }

        private void AddNode(LinkedListNode nextLinkedListNode) {
            _nextLinkedListNode = nextLinkedListNode;
            nextLinkedListNode._prevLinkedListNode = this;
        }

        public LinkedListNode Next() {
            return _nextLinkedListNode;
        }

        public void InsertNode(uint numberOfNode, LinkedListNode linkedListNodeToInsert) {
            var i = 0;
            var node = this;
            while (node != null && i < numberOfNode)
            {
                node = node.Next();
                i++;
            }
            var nextToInsertedNode = node._nextLinkedListNode;
            node.AddNode(linkedListNodeToInsert);
            if (nextToInsertedNode != null)
                linkedListNodeToInsert.AddNode(nextToInsertedNode);
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

            var nextToDeletedNode = node._nextLinkedListNode;
            var prevToDeletedNode = node._prevLinkedListNode;
            if (nextToDeletedNode != null)
            {
                prevToDeletedNode.AddNode(nextToDeletedNode);
            }
            else
            {
                prevToDeletedNode._nextLinkedListNode = null;
            }

            node._nextLinkedListNode = null;
            node._prevLinkedListNode = null;
        }

        public LinkedListNode DeleteNode() {
            var toReturn = Next();
            _nextLinkedListNode = null;
            _prevLinkedListNode = null;
            return toReturn;
        }
    }
}