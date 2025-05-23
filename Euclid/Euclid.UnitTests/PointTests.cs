using Euclid

namespace Euclid.UnitTests
{
    [TestFixture]
    public class Point Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorTwoParametrsTest()
        {
        //Arrange
        double x = 1;
        double y = 2;

        //Act
        var p = new Point(x, y);

        //Assert
        Assert.That(p.X, Is.EqualTo(x));
        Assert.That(p.Y, Is.EqualTo(y));
    }

    [Test]
    public void ConstructorZeroParametersTests()
    {
        var p = new Point();

        Assert.That(p.X, Is.EqualTo(0));
        Assert.That(p.Y, Is.EqualTo(0));
    }
    }
}