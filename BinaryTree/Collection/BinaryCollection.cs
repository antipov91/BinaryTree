using System;
using System.Collections.Generic;

namespace BinaryTreeCollection.Collection
{
    public class BinaryCollection<T>
    {
        private BinaryNode<T> node;
        private Func<T, T, int> compareTo;

        public BinaryCollection(Func<T, T, int> compareTo)
        {
            this.compareTo = compareTo;
        }

        public void Add(T value, int index)
        {
            if (ReferenceEquals(node, null))
                node = new BinaryNode<T>(value, index);
            else
                node = node.Add(value, index, compareTo);
        }

        public bool Find(T value, out int outIndex)
        {
            outIndex = 0;
            var findedNode = Find(value);
            if (ReferenceEquals(findedNode, null))
                return false;

            outIndex = findedNode.Index;
            return true;
        }

        public void Remove(T value)
        {
            if (ReferenceEquals(node, null))
                return;

            node = node.Remove(value, compareTo);
        }

        public void Print()
        {
            if (ReferenceEquals(node, null))
                return;

            node.Print();
        }

        public T[] ToArray()
        {
            var queue = new Queue<T>();
            AddNodeToQueue(node, queue);
            return queue.ToArray();
        }

        private void AddNodeToQueue(BinaryNode<T> currentNode, Queue<T> queue)
        {
            if (ReferenceEquals(currentNode, null))
                return;

            queue.Enqueue(currentNode.Value);
            AddNodeToQueue(currentNode.LeftNode, queue);
            AddNodeToQueue(currentNode.RightNode, queue);
        }

        private BinaryNode<T> Find(T value)
        {
            var currentNode = node;
            while (!ReferenceEquals(currentNode, null) && compareTo(value, currentNode.Value) != 0)
            {
                if (compareTo(currentNode.Value, value) >= 0)
                    currentNode = currentNode.LeftNode;
                else
                    currentNode = currentNode.RightNode;
            }
            return currentNode;
        }
    }
}