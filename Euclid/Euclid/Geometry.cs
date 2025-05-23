using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclid
{
    public static class Geometry
    {
        static readonly double EPSILON = 1E-13;
        public static Segment CreateSegment(Point a, Point b)
        {
            if (Math.Abs(a.X == b.X) < EPSILON && Math.Abs(a.Y == b.Y) < EPSILON)
                throw new ArgumentException("Концы отрезка совпадают");

            return new Segment(a, b);
        }
        public static bool IsPointInsideSegment(Point p, Segment s) => s.IsContain(p);

        public static Triangle CreateTriangle(Point a, Point b, Point c)
        {
            var t = new Triangle(a, b, c);
            if(t.AB.Length + t.AC.Length - t.BC.Length >= EPSILON &&
                t.AB.Length + t.BC.Length - t.AC.Length >= EPSILON &&
                t.AC.Length + t.BC.Length - t.AB.Length >= EPSILON)
                return t;
            throw new ArgumentException("Треугольник вырожденный");
        }
        [Test]
        public void CreateTriangle_DegeneratedCase()
    }
}
