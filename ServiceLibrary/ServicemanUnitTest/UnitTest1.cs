using ServiceLibrary;
namespace ServicemanUnitTest
{
    [TestFixture]
    public class ServicemanUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var soldier = CreateTestServiceman();

            Assert.That(soldier.Name, Is.EqualTo("Иван"));
            Assert.That(soldier.Surname, Is.EqualTo("Иванов"));
            Assert.That(soldier.MilitaryId, Is.EqualTo("AB123456"));
            Assert.That(soldier.Rank, Is.EqualTo("Сержант"));
            Assert.That(soldier.UnitNumber, Is.EqualTo("12345"));
            Assert.That(soldier.EnlistmentDate.ToShortDateString(), Is.EqualTo("10.05.2020"));
            Assert.That(soldier.Service, Is.EqualTo(ServiceType.Contract));
            Assert.That(soldier.ServiceTerm, Is.EqualTo(DateTime.Now.Year - 2020));
        }

        [Test]
        public void GetInfoTest()
        {
            var soldier = CreateTestServiceman();
            var info = soldier.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("Иван Иванов, звание: Сержант, часть: 12345"));
            Assert.That(info[1], Is.EqualTo(
                $"Военный билет: AB123456. Дата поступления на службу: 10.05.2020. Тип службы: контрактная. Срок службы: {DateTime.Now.Year - 2020} лет."));
        }

        private Serviceman CreateTestServiceman()
        {
            return new Serviceman("Иван", "Иванов", "AB123456", "Сержант", "12345", "10.05.2020", ServiceType.Contract);
        }
    }
}