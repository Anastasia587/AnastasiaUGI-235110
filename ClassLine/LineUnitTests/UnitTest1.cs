using ClassLine;

namespace LineUnitTests
{
    [TestFixture]
    public class LineTests
    {
        [Test]
        public void ConstructorTest()
        {
            var line = new Line(2.5, -1.3);
            Assert.That(line.A, Is.EqualTo(2.5));
            Assert.That(line.B, Is.EqualTo(-1.3));
        }

        [TestCase(double.NaN, 1)]
        [TestCase(1, double.PositiveInfinity)]
        public void Constructor_InvalidValues_Throws(double a, double b)
        {
            Assert.That(() => new Line(a, b), Throws.ArgumentException);
        }

        [TestCase(1, 0, 45)]
        [TestCase(0, 0, 0)]
        [TestCase(-1, 0, -45)]
        public void AngleInDegreesTest(double a, double b, double expected)
        {
            var line = new Line(a, b);
            Assert.That(line.AngleInDegrees, Is.EqualTo(expected).Within(1e-13));
        }

        [Test]
        public void ToStringTest_PositiveAndNegativeB()
        {
            var line1 = new Line(1.5, -2.2);
            var line2 = new Line(-3.0, 0.5);
            Assert.That(line1.ToString(), Is.EqualTo("y = 1.5x - 2.2"));
            Assert.That(line2.ToString(), Is.EqualTo("y = -3x + 0.5"));
        }

        [Test]
        public void EqualsTest()
        {
            var l1 = new Line(1.0000000000001, 2.0000000000001);
            var l2 = new Line(1.0000000000002, 2.0000000000002);
            Assert.That(l1 == l2, Is.True);
        }

        [Test]
        public void NotEqualsTest()
        {
            var l1 = new Line(1.0, 2.0);
            var l2 = new Line(1.1, 2.0);
            Assert.That(l1 != l2, Is.True);
        }

        [Test]
        public void GetHashCode_SameLine_SameHash()
        {
            var l1 = new Line(3.14, 2.71);
            var l2 = new Line(3.14, 2.71);
            Assert.That(l1.GetHashCode(), Is.EqualTo(l2.GetHashCode()));
        }

        [Test]
        public void UnaryTilde_ValidLine_ReturnsPerpendicular()
        {
            var original = new Line(2.0, 5.0);
            var perpendicular = ~original;
            Assert.That(perpendicular.A, Is.EqualTo(-0.5).Within(1e-13));
            Assert.That(perpendicular.B, Is.EqualTo(0).Within(1e-13));
        }

        [Test]
        public void UnaryTilde_HorizontalLine_Throws()
        {
            var horizontal = new Line(0, 3.5);
            Assert.That(() => ~horizontal, Throws.InvalidOperationException);
        }
    }
}
