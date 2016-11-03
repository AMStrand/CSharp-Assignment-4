using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
        // Generic stack class of type T:
    class GenericStack<T>
    {
            // Internal class to serve as the Node class for the linked list stack:
        protected class Node
        {
                // Property to hold the data:
            public T Data { get; set; }
                // Property to hold the next node:
            public Node Next { get; set; }
        }

            // Variable declarations:
        private Node _head;
        private int _size;

            // Bool property to see if the stack is empty:
        public bool IsEmpty
        {
            get { return _head == null; }
        }

            // Int property for the size of the stack:
        public int Size
        {
            get { return _size; }
        }

            // Public method to add an item to the front of the generic stack:
        public void AddToFront(T genericData)
        {
                // Save the head in the oldHead variable:
            Node oldHead = _head;
                // Create a new Node to be the new head:
            _head = new Node();
                // Save the passed in data as the data for the new head:
            _head.Data = genericData;
                // Increment the size:
            _size++;
                // Set the next of the new head to the old head:
            _head.Next = oldHead;
        }

            // Public method to remove the front item of the stack:
        public T RemoveFromFront()
        {
            T returnData;
                // If the list is empty, set the return data to the default of the type (null / 0):
                // Set the return data to the current head data:
            returnData = _head.Data;
                // Set the new head to the next of the old head:
            _head = _head.Next;
                // Decrement the size:
            _size--;

                // Return the data of the deleted head:
            return returnData;
        }

            // Default constructor to set values to default values upon instantiation of a stack:
        public GenericStack()
        {
            _head = null;
            _size = 0;
        }
    }
}
