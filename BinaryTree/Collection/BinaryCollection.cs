using System;
using System.Runtime.CompilerServices;

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

        public void Print()
        {
            if (ReferenceEquals(node, null))
                return;

            node.Print();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private BinaryNode<T> Find(T value)
        {
            var currentNode = node;
            while (!ReferenceEquals(currentNode, null) && compareTo(value, currentNode.Value) != 0)
            {
                if (compareTo(value, currentNode.Value) >= 0)
                    currentNode = currentNode.LeftNode;
                else
                    currentNode = currentNode.RightNode;
            }
            return currentNode;
        }
    }
}