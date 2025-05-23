using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclid.UnitTests
{
    [TestFixture]
    public class SegmentTests
    {
        [Test]
        public void ConstructorTests()
        {
            var a = new Point(1, 1);
            var b = new Point(2, 3);

            var s = new Segment(a, b);

            Assert.That(s.A, Is.EqualTo(a));
            Assert.That(s.B, Is.EqualTo(b));
        }
        [Test]
        public void LengthTest()
        {
            var a = new Point(1, 1);
            var b = new Pint(2, 3);

            var s = new Segment(a, b);

            Assert.That(s.Length,
                Is.EqualTo(Math.Sqrt(5)).Within(Geometry.EPSILON));

        }

        [TestCase(1,1,true)]
        [TestCase(2, 3, true)]
        [TestCase(1.5, 2, true)]
        [TestCase(0, -1, false)]
        [TestCase(3, 3, false)]
        [TestCase(1, 2, false)]
        public void IsInsideTests(double x, double y, bool result)
        {

            var s = new Segment(new Point(1, 1), new Point(2, 3));
            var p = new Point(x,y);

            Assert.That(s.IsContain(p), Is.EqualTo(result));
        }
    }
}
