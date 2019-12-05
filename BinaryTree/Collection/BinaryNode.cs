using System;
using System.Runtime.CompilerServices;

namespace BinaryTreeCollection.Collection
{
    public class BinaryNode<T>
    {
        public BinaryNode<T> LeftNode { get; private set; }
        public BinaryNode<T> RightNode { get; private set; }
        public T Value { get; private set; }
        public int Index { get; private set; }
        public int Height { get; private set; }

        public BinaryNode(T value, int index)
        {
            Value = value;
            Index = index;
        }

        public BinaryNode<T> Add(T value, int index, Func<T, T, int> сompareTo)
        {
            var newRoot = this;
            if (сompareTo(Value, value) <= 0)
            {
                LeftNode = AddToSubTree(LeftNode, value, index, сompareTo);
                if (GetHeightDifference() == 2)
                {
                    if (сompareTo(LeftNode.Value, value) <= 0)
                        newRoot = RotateRight();
                    else
                        newRoot = RotateLeftRight();
                }
            }
            else
            {
                RightNode = AddToSubTree(RightNode, value, index, сompareTo);
                if (GetHeightDifference() == -2)
                {
                    if (сompareTo(RightNode.Value, value) > 0)
                        newRoot = RotateLeft();
                    else
                        newRoot = RotateRightLeft();
                }
            }
            newRoot.ComputeHeight();
            return newRoot;
        }

        public void Print()
        {
            if (!ReferenceEquals(LeftNode, null))
                Console.WriteLine(string.Format("{0} -> {1}", Value, LeftNode.Value));
            if (!ReferenceEquals(RightNode, null))
                Console.WriteLine(string.Format("{0} -> {1}", Value, RightNode.Value));

            if (!ReferenceEquals(LeftNode, null))
                LeftNode.Print();
            if (!ReferenceEquals(RightNode, null))
                RightNode.Print();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int GetHeightDifference()
        {
            var leftHeight = ReferenceEquals(LeftNode, null) ? 0 : LeftNode.Height + 1;
            var rightHeight = ReferenceEquals(RightNode, null) ? 0 : RightNode.Height + 1;
            return leftHeight - rightHeight;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ComputeHeight()
        {
            Height = 0;
            if (!ReferenceEquals(LeftNode, null))
                Height = Math.Max(Height, LeftNode.Height) + 1;
            if (!ReferenceEquals(RightNode, null))
                Height = Math.Max(Height, RightNode.Height) + 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private BinaryNode<T> RotateRight()
        {
            var newRoot = LeftNode;
            LeftNode = newRoot.RightNode;
            newRoot.RightNode = this;

            ComputeHeight();
            return newRoot;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private BinaryNode<T> RotateLeft()
        {
            var newRoot = RightNode;
            RightNode = newRoot.LeftNode;
            newRoot.LeftNode = this;

            ComputeHeight();
            return newRoot;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private BinaryNode<T> RotateRightLeft()
        {
            var child = RightNode;
            var newRoot = child.LeftNode;
            var grand1 = newRoot.LeftNode;
            var grand2 = newRoot.RightNode;
            child.LeftNode = grand2;
            RightNode = grand1;

            newRoot.LeftNode = this;
            newRoot.RightNode = child;

            child.ComputeHeight();
            ComputeHeight();
            return newRoot;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private BinaryNode<T> RotateLeftRight()
        {
            var child = LeftNode;
            var newRoot = child.RightNode;
            var grand1 = newRoot.LeftNode;
            var grand2 = newRoot.RightNode;
            child.RightNode = grand1;
            LeftNode = grand2;

            newRoot.LeftNode = child;
            newRoot.RightNode = this;

            child.ComputeHeight();
            ComputeHeight();
            return newRoot;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private BinaryNode<T> AddToSubTree(BinaryNode<T> parentNode, T value, int index, Func<T, T, int> сompareTo)
        {
            if (ReferenceEquals(parentNode, null))
                return new BinaryNode<T>(value, index);

            parentNode = parentNode.Add(value, index, сompareTo);
            return parentNode;
        }
    }
}