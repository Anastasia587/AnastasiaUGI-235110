namespace HRLibrary.UnitTeests
{
    [TestFixture]
    public class ServicemanUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var soldier = CreateTestServiceman();

            Assert.That(soldier.FirstName, Is.EqualTo("Иван"));
            Assert.That(soldier.LastName, Is.EqualTo("Иванов"));
            Assert.That(soldier.MilitaryID, Is.EqualTo("12345678"));
            Assert.That(soldier.Rank, Is.EqualTo("Лейтенант"));
            Assert.That(soldier.MilitaryUnit, Is.EqualTo("Военная часть 1111"));
            Assert.That(soldier.Service, Is.EqualTo(ServiceType.Контракт));
            Assert.That(soldier.EnlistmentDate.ToShortDateString(), Is.EqualTo("01.09.2020"));
            Assert.That(soldier.ServiceDuration, Is.EqualTo(DateTime.Now.Year - 2020));
        }

        [Test]
        public void GetInfoTest()
        {
            var soldier = CreateTestServiceman();
            var info = soldier.GetInfo();

            Assert.That(info.Length, Is.EqualTo(4));
            Assert.That(info[0], Is.EqualTo("Лейтенант Иван Иванов"));
            Assert.That(info[1], Is.EqualTo("Военный билет: 12345678"));
            Assert.That(info[2], Is.EqualTo("Часть: Военная часть 1111, Тип службы: Контракт"));
            Assert.That(info[3], Is.EqualTo($"Дата поступления: 01.09.2020, Срок службы: {DateTime.Now.Year - 2020} лет"));
        }

        private Serviceman CreateTestServiceman()
        {
            return new Serviceman("Иван", "Иванов", "12345678", "Лейтенант", "Военная часть 1111", "01.09.2020", ServiceType.Контракт);
        }
    }
}