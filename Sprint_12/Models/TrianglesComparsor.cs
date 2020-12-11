using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprint_12.Models
{
    public class TrianglesComparsor
    {
        private List<Triangle> _triangles = new List<Triangle>();

        public Triangle GreatestByPerimeter { get; }
        public Triangle GreatestByArea { get; }

        public static bool AreCongruent(Triangle t1, Triangle t2) => 
            (Math.Abs(t1.Side1 - t2.Side1) <= 0.1 &&
             Math.Abs(t1.Side2 - t2.Side2) <= 0.1 &&
             Math.Abs(t1.Side3 - t2.Side3) <= 0.1);

        public static bool AreSimilar(Triangle t1, Triangle t2) => 
            (Math.Abs(t1.Side1 / t2.Side1 - t1.Side2 / t2.Side2) <= 0.1) && 
             (Math.Abs(t1.Side1 / t2.Side1 - t1.Side3 / t2.Side3) <= 0.1);

        private Triangle GreatestTriangleByPerimeter()
        {
            double maxPerimeter = 0;
            var triangleMaxPerimeter = new Triangle();

            foreach (var triangle in _triangles.Where(triangle => triangle.Perimeter > maxPerimeter))
            {
                maxPerimeter = triangle.Perimeter;
                triangleMaxPerimeter = triangle;
            }

            return triangleMaxPerimeter;
        }

        private Triangle GreatestTriangleByArea()
        {
            double maxArea = 0;
            var triangleMaxArea = new Triangle();

            foreach (var triangle in _triangles.Where(triangle => triangle.Area > maxArea))
            {
                maxArea = triangle.Area;
                triangleMaxArea = triangle;
            }

            return triangleMaxArea;
        }

        public IEnumerable<(Triangle, Triangle)> NonSimilarTriangles() => 
            from triangle1 in _triangles 
            from triangle2 in _triangles 
            where !AreSimilar(triangle1, triangle2) 
            select (triangle1, triangle2);

        public TrianglesComparsor(IEnumerable<Triangle> triangles)
        {
            triangles.ToList().ForEach(triangle => _triangles.Add(new Triangle(triangle)));

            GreatestByPerimeter = GreatestTriangleByPerimeter();
            GreatestByArea = GreatestTriangleByArea();
        }
    }
}
