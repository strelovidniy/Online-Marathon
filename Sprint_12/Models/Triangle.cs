using System;
using System.Collections.Generic;

namespace Sprint_12.Models
{
    public class Triangle
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }
        public double Area { get; }
        public double Perimeter { get; }
        public bool IsRightAngled { get; }
        public bool IsEquilateral { get; }
        public bool IsIsosceles { get; }
        
        private double TriangleArea() =>
            Math.Sqrt(Perimeter / 2 * (Perimeter / 2 - Side1) * (Perimeter / 2 - Side2) * (Perimeter / 2 - Side3));

        private double TrianglePerimeter() =>
            Side1 + Side2 + Side3;

        private bool IsTriangleRightAngled() =>
            Side1 * Side1 == Side2 * Side2 + Side3 * Side3 ||
            Side2 * Side2 == Side1 * Side1 + Side3 * Side3 ||
            Side3 * Side3 == Side1 * Side1 + Side2 * Side2;

        private bool IsTriangleEquilateral() =>
            Side1 == Side2 && Side1 == Side3;

        private bool IsTriangleIsosceles() =>
            Side1 == Side2 || Side1 == Side3 || Side2 == Side3;
        

        public List<string> ShowInfo() =>
            new List<string>()
            {
                "------------------------------------------------------------",
                "Triangle:",
                $"({Side1:F4}, {Side2:F4}, {Side3:F4})",
                $"Reduced:",
                $"({Side1 / Perimeter:F4}, {Side2 / Perimeter:F4}, {Side3 / Perimeter:F4})",
                "",
                $"Area = {Area:F4}",
                $"Perimeter = {Perimeter:F4}",
                "------------------------------------------------------------"
            };

        public Triangle()
        {

        }

        public Triangle(Triangle triangle)
        {
            var triangleSides = new [] { triangle.Side1, triangle.Side2, triangle.Side3 };
            Array.Sort(triangleSides);

            Side1 = triangleSides[0];
            Side2 = triangleSides[1];
            Side3 = triangleSides[2];
            Perimeter = TrianglePerimeter();
            Area = TriangleArea();

            IsRightAngled = IsTriangleRightAngled();
            IsEquilateral = IsTriangleEquilateral();
            IsIsosceles = IsTriangleIsosceles();
        }

        public Triangle(params double[] sides)
        {
            Array.Sort(sides);

            try
            {
                Side1 = sides[0];
                Side2 = sides[1];
                Side3 = sides[2];
            }
            catch (Exception)
            {
                // ignored
            }

            Perimeter = TrianglePerimeter();
            Area = TriangleArea();

            IsRightAngled = IsTriangleRightAngled();
            IsEquilateral = IsTriangleEquilateral();
            IsIsosceles = IsTriangleIsosceles();
        }
    }
}
