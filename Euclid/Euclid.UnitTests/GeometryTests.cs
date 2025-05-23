using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclid.UnitTests
{
    public class GeometryTests
    {
        [Test]

        public void CreateSegment_DifferentPoints_Create()
        {
            var a = new Point(1, 1);
            var b = new Point(2, 3);

            var s = Geometry.CreateSegment(a, b);

            Assert.That(s.A, Is.EqualTo(a));
            Assert.That(s.B, Is.EqualTo(b));
        }
        [Test]
        public void CreateSegment_EqualPoints_ArgumentException()
        {
            var a = new Point(-2, 4);
            var b = new Point(-2, 4);

            //Assert.That(() => Geometry.CreateSegment(a, b), Throws.ArgumentException);

            var exception = Assert.Throws<ArgumentException>(() => Geometry.CreateSegment(a, b));
            Assert.That(exception.Message, Is.EqualTo("Концы отрезка совпадают"));

        }
        [Test]
        public void CreateTriangle_DEgeneratedTriangle_ArgumentException()
        {
            var a = new Point();
            var b = new Point(1, 2);
            var c = new Point(2, 4);

            var exception = Assert.Throws<ArgumentException>(
                () => Geometry.CreateTriangle(a, b, c));

        }
    }
}
