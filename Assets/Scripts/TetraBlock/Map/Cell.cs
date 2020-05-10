namespace TetraBlock.Map
{
    public class Cell
    {
        private bool isEmpty;

        public Cell(bool isEmpty)
        {
            this.isEmpty = isEmpty;
        }

        public bool IsEmpty => isEmpty;

        public void SetFill(bool value)
        {
            isEmpty = value;
        }
    }
}