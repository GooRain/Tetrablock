namespace TetraBlock.Map
{
    public class Grid
    {
        public Cell[,] cells;

        public Grid(int size)
        {
            cells = new Cell[size, size];
        }

        public Grid(int width, int height)
        {
            cells = new Cell[width, height];
        }
    }
}