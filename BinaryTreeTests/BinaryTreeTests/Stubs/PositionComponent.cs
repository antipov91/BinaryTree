namespace BinaryTreeTests.Stubs
{
    public struct PositionComponent
    {
        public int x;
        public int y;

        public PositionComponent(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return x.ToString();
        }
    }
}