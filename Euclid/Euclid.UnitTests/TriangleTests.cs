using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclid.UnitTests
{
    public class TriangleTests
    {
        [Test]
        public void ConstructorTest()
        {
            var a = new Point(1, 1);
            var b = new Point(3, 1);
            var c = new Point(3, 4);

            var t = new Triangle(a, b, c);

            Assert.That(t.A, Is.EqualTo(a));
            Assert.That(t.B, Is.EqualTo(b));
            Assert.That(t.C, Is.EqualTo(c));
        }
        [Test]
        public void TestSideAB
        {
            var t = CreateTestTriangle();

            Assert.That(t.AB.A.X, Is.EqualTo(1));
            Assert.That(t.AB.A.Y, Is.EqualTo(1));
            Assert.That(t.AB.B.X, Is.EqualTo(3));
            Assert.That(t.AB.B.Y, Is.EqualTo(4));
        }
        [Test]
        public void TestSideAB
     {
        var t = CreateTestTriangle();

        Assert.That(t.AB.A.X, Is.EqualTo(1));
        Assert.That(t.AB.A.Y, Is.EqualTo(1));
        Assert.That(t.AB.B.X, Is.EqualTo(3));
        Assert.That(t.AB.B.Y, Is.EqualTo(4));
    }
    private static Triangle CreateTestTriangle()
        {
            var a = new Point(1, 1);
            var b = new Point(3, 1);
            var c = new Point(3, 4);

            return new Triangle(a, b, c);


        }
    }
}
