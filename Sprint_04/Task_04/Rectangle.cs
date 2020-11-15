namespace Sprint_04.Task_04
{
    internal class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public double Area() 
            => Length * Width;

        public object Clone() 
            => new Rectangle { Length = this.Length, Width = this.Width };
    }
}
