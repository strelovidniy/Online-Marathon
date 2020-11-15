namespace Sprint_04.Task_04
{
    internal class Trapezoid : IShape
    {
        public double Length1 { get; set; }
        public double Length2 { get; set; }
        public double Width { get; set; }

        public double Area() 
            => (Length1 + Length2) / 2  * Width;

        public object Clone()
            => new Trapezoid { Length1 = this.Length1, Length2 = this.Length2, Width = this.Width };
    }
}
