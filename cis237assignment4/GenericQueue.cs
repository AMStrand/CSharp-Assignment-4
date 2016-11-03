using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericQueue<T>
    {
        // Internal class to serve as the Node class for the linked list queue:
        protected class Node
        {
            // Property to hold the data:
            public T Data { get; set; }
            // Property to hold the next node:
            public Node Next { get; set; }
        }

        // Variable declarations:
        private Node _head;
        private Node _tail;
        private int _size;

        // Bool property to see if the queue is empty:
        public bool IsEmpty
        {
            get { return _head == null; }
        }

        // Int property for the size of the queue:
        public int Size
        {
            get { return _size; }
        }

        // Public method to add an item to the back of the queue:
        public void AddToBack(T genericData)
        {
                // Set the old tail to the current tail:
            Node oldTail = _tail;
                // Make a new tail node:
            _tail = new Node();
                // Save the data of the new tail:
            _tail.Data = genericData;
                // Set the next of the tail to null:
            _tail.Next = null;
                // Increment the size:
            _size++;
                // If there is only one item, the head = the tail:
            if (_size == 1)
            {
                _head = _tail;
            }
                // Otherwise, set the next of the old tail to the new tail:
            else
            {
                oldTail.Next = _tail;
            }
        }

            // Public method to remove from the front of the queue:
        public T RemoveFromFront()
        {
                // Set the return data to the current head data:
            T returnData = _head.Data;
                // Set the new head to the next of the old head:
            _head = _head.Next;
                // Decrement the size:
            _size--;
                // Return the data of the deleted head:
            return returnData;
        }

        // Default constructor to set values to default values upon instantiation of a queue:
        public GenericQueue()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }
    }
}
