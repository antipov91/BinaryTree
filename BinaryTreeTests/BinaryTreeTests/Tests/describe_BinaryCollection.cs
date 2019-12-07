using NSpec;
using BinaryTreeTests.Stubs;
using BinaryTreeCollection.Collection;

namespace BinaryTreeTests.Tests
{
    public class describe_BinaryCollection : nspec
    {
        public void when_Add()
        {
            BinaryCollection<PositionComponent> binaryCollection = null;

            before = () =>
            {
                binaryCollection = new BinaryCollection<PositionComponent>((c1, c2) => { if (c1.x > c2.x) return 1; if (c1.x == c2.x) return 0; return -1; });
            };

            context["Given left-left tree"] = () =>
            {
                before = () =>
                {
                    binaryCollection.Add(new PositionComponent(50, 0), 0);
                    binaryCollection.Add(new PositionComponent(30, 0), 1);
                    binaryCollection.Add(new PositionComponent(10, 0), 2);
                };

                it["Must be turn right"] = () =>
                {
                    var array = binaryCollection.ToArray();
                    array[0].x.should_be(30);
                    array[1].x.should_be(10);
                    array[2].x.should_be(50);
                };
            };

            context["Given left-right tree"] = () =>
            {
                before = () =>
                {
                    binaryCollection.Add(new PositionComponent(50, 0), 0);
                    binaryCollection.Add(new PositionComponent(10, 0), 1);
                    binaryCollection.Add(new PositionComponent(30, 0), 2);
                };

                it["Must be turn left-right"] = () =>
                {
                    var array = binaryCollection.ToArray();
                    array[0].x.should_be(30);
                    array[1].x.should_be(10);
                    array[2].x.should_be(50);
                };
            };

            context["Given right-left tree"] = () =>
            {
                before = () =>
                {
                    binaryCollection.Add(new PositionComponent(10, 0), 0);
                    binaryCollection.Add(new PositionComponent(50, 0), 1);
                    binaryCollection.Add(new PositionComponent(30, 0), 2);
                };

                it["Must be turn right-left"] = () =>
                {
                    var array = binaryCollection.ToArray();
                    array[0].x.should_be(30);
                    array[1].x.should_be(10);
                    array[2].x.should_be(50);
                };
            };

            context["Given right-right tree"] = () =>
            {
                before = () =>
                {
                    binaryCollection.Add(new PositionComponent(10, 0), 0);
                    binaryCollection.Add(new PositionComponent(30, 0), 1);
                    binaryCollection.Add(new PositionComponent(50, 0), 2);
                };

                it["Must be turn left"] = () =>
                {
                    var array = binaryCollection.ToArray();
                    array[0].x.should_be(30);
                    array[1].x.should_be(10);
                    array[2].x.should_be(50);
                };
            };
        }

        public void when_Find()
        {
            BinaryCollection<PositionComponent> binaryCollection = null;

            before = () =>
            {
                binaryCollection = new BinaryCollection<PositionComponent>((c1, c2) => { if (c1.x > c2.x) return 1; if (c1.x == c2.x) return 0; return -1; });
            };

            context["Given tree"] = () =>
            {
                before = () =>
                {
                    binaryCollection.Add(new PositionComponent(50, 0), 0);
                    binaryCollection.Add(new PositionComponent(30, 0), 1);
                    binaryCollection.Add(new PositionComponent(10, 0), 2);
                };

                it["Must find component index with x equal 10"] = () =>
                {
                    int index;
                    binaryCollection.Find(new PositionComponent(10, 0), out index).should_be_true();
                    index.should_be(2);
                };
            };

            context["Given tree"] = () =>
            {
                before = () =>
                {
                    binaryCollection.Add(new PositionComponent(20, 0), 0);
                    binaryCollection.Add(new PositionComponent(17, 0), 1);
                    binaryCollection.Add(new PositionComponent(15, 0), 3);
                    binaryCollection.Add(new PositionComponent(12, 0), 4);
                    binaryCollection.Add(new PositionComponent(10, 0), 5);
                    binaryCollection.Add(new PositionComponent(8, 0), 6);
                    binaryCollection.Add(new PositionComponent(5, 0), 7);

                    binaryCollection.Add(new PositionComponent(50, 0), 8);
                    binaryCollection.Add(new PositionComponent(25, 0), 9);
                    binaryCollection.Add(new PositionComponent(35, 0), 10);
                    binaryCollection.Add(new PositionComponent(45, 0), 11);
                    binaryCollection.Add(new PositionComponent(85, 0), 12);
                    binaryCollection.Add(new PositionComponent(2, 0), 13);
                    binaryCollection.Add(new PositionComponent(1, 0), 14);
                };

                it["Must find component index with x equal 10"] = () =>
                {
                    int index;
                    binaryCollection.Find(new PositionComponent(35, 0), out index).should_be_true();
                    index.should_be(10);
                };
            };
        }

        public void when_Remove()
        {
            BinaryCollection<PositionComponent> binaryCollection = null;

            before = () =>
            {
                binaryCollection = new BinaryCollection<PositionComponent>((c1, c2) => { if (c1.x > c2.x) return 1; if (c1.x == c2.x) return 0; return -1; });
            };

            context["Given tree, and deleted node does not have a subtree"] = () =>
            {
                before = () =>
                {
                    binaryCollection.Add(new PositionComponent(50, 0), 0);
                    binaryCollection.Add(new PositionComponent(30, 0), 1);
                    binaryCollection.Add(new PositionComponent(10, 0), 2);
                    binaryCollection.Remove(new PositionComponent(10, 0));
                };

                it["Must remove node with index equal 2"] = () =>
                {
                    var array = binaryCollection.ToArray();

                    array.Length.should_be(2);
                    array[0].x.should_be(30);
                    array[1].x.should_be(50);
                };
            };

            context["Given tree, and deleted node has a left subtree"] = () =>
            {
                before = () =>
                {
                    binaryCollection.Add(new PositionComponent(30, 0), 0);
                    binaryCollection.Add(new PositionComponent(20, 0), 1);
                    binaryCollection.Add(new PositionComponent(50, 0), 2);
                    binaryCollection.Add(new PositionComponent(10, 0), 3);
                    binaryCollection.Add(new PositionComponent(40, 0), 4);
                    binaryCollection.Add(new PositionComponent(60, 0), 5);

                    binaryCollection.Remove(new PositionComponent(20, 0));
                };

                it["Must remove node with index equal 1"] = () =>
                {
                    var array = binaryCollection.ToArray();

                    array.Length.should_be(5);
                    array[0].x.should_be(50);
                    array[1].x.should_be(30);
                    array[2].x.should_be(10);
                    array[3].x.should_be(40);
                    array[4].x.should_be(60);
                };
            };

            context["Given tree, and deleted node has a right subtree"] = () =>
            {
                before = () =>
                {
                    binaryCollection.Add(new PositionComponent(30, 0), 0);
                    binaryCollection.Add(new PositionComponent(20, 0), 1);
                    binaryCollection.Add(new PositionComponent(50, 0), 2);
                    binaryCollection.Add(new PositionComponent(25, 0), 3);
                    binaryCollection.Add(new PositionComponent(40, 0), 4);
                    binaryCollection.Add(new PositionComponent(60, 0), 5);

                    binaryCollection.Remove(new PositionComponent(20, 0));
                };

                it["Must remove node with index equal 1"] = () =>
                {
                    var array = binaryCollection.ToArray();

                    array.Length.should_be(5);
                    array[0].x.should_be(50);
                    array[1].x.should_be(30);
                    array[2].x.should_be(25);
                    array[3].x.should_be(40);
                    array[4].x.should_be(60);
                };
            };

            context["Given tree, and deleted node has a left subtree and right subtree"] = () =>
            {
                before = () =>
                {
                    binaryCollection.Add(new PositionComponent(30, 0), 0);
                    binaryCollection.Add(new PositionComponent(20, 0), 1);
                    binaryCollection.Add(new PositionComponent(50, 0), 2);
                    binaryCollection.Add(new PositionComponent(10, 0), 3);
                    binaryCollection.Add(new PositionComponent(25, 0), 3);
                    binaryCollection.Add(new PositionComponent(40, 0), 4);
                    binaryCollection.Add(new PositionComponent(60, 0), 5);

                    binaryCollection.Remove(new PositionComponent(10, 0));
                };

                it["Must remove node with index equal 2"] = () =>
                {
                    var array = binaryCollection.ToArray();

                    array.Length.should_be(6);
                    array[0].x.should_be(40);
                    array[1].x.should_be(25);
                    array[2].x.should_be(20);
                    array[3].x.should_be(30);
                    array[4].x.should_be(50);
                    array[5].x.should_be(60);
                };
            };
        }
    }
}