using ServiceLibrary;
using System.ComponentModel;
using System.Security.AccessControl;
using System.Xml.Linq;
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
            Assert.That(info[1], Is.EqualTo($"Военный билет: AB123456. Дата поступления на службу: 10.05.2020. " +
                $"Тип службы: контрактная. Срок службы: {DateTime.Now.Year - 2020} лет."));
        }

        private Serviceman CreateTestServiceman()
        {
            return new Serviceman("Иван", "Иванов", "AB123456", "Сержант", "12345", "10.05.2020", ServiceType.Contract);
        }
    }
    [TestFixture]
    public class CommandStaffTest
    {
        [Test]
        public void ConstructorTest()
        {
            var leader = GetTestStaffMember();

            Assert.That(leader.Division, Is.EqualTo("Морская пехота"));
            Assert.That(leader.Position, Is.EqualTo("Командир"));
        }

        [Test]
        public void GetInfo_CommandStaff()
        {
            var leader = GetTestStaffMember();
            var lines = new[]
            {
                "Наталья Прибрежная, звание: Командир пехоты, часть: 54987",
                $"Военный билет: AB123456. Дата поступления на службу: 10.05.2003. Тип службы: контрактная. Срок службы: {DateTime.Now.Year - 2003} лет.",
                "Подразделение: Морская пехота",
                "Должность: Командир"
             };
            var info = leader.GetInfo();
            Assert.That(info.Length, Is.EqualTo(4));

            for (var i = 0; i < info.Length; i++)
                Assert.That(info[i], Is.EqualTo(lines[i]));
        }

        private CommandStaff GetTestStaffMember()
        {
            var staffmember = new CommandStaff("Наталья", "Прибрежная", "AB123456", "54987",
          "10.05.2003", ServiceType.Contract, "Командир пехоты", "Морская пехота", "Командир");
            return staffmember;
        }

    }

    [TestFixture]
    public class ManagementBodyTests
    {
        [Test]
        public void ConstructorTest()
        {
            var manager = GetTestManagementBody();

            Assert.That(manager.District, Is.EqualTo("Южный округ"));
            Assert.That(manager.Position, Is.EqualTo("Начальник отдела"));
        }

        [Test]
        public void GetInfo_ManagementBody()
        {
            var manager = GetTestManagementBody();
            var info = manager.GetInfo();

            Assert.That(info.Length, Is.EqualTo(4));
            Assert.That(info[0], Is.EqualTo("Каролина Черепак, звание: Генерал-майор, часть: 77777"));
            Assert.That(info[1], Is.EqualTo(
                $"Военный билет: AB123656. Дата поступления на службу: 10.05.2010. Тип службы: контрактная. Срок службы: {DateTime.Now.Year - 2010} лет."));
            Assert.That(info[2], Is.EqualTo("Округ: Южный округ"));
            Assert.That(info[3], Is.EqualTo("Должность: Начальник отдела"));
        }

        private ManagementBody GetTestManagementBody()
        {
            return new ManagementBody(
                "Каролина", "Черепак", "AB123656", "Генерал-майор", "77777",
                "10.05.2010", ServiceType.Contract,
                "Южный округ", "Начальник отдела");
        }
    }

    [TestFixture]
    public class VeteranTests
    {
        [Test]
        public void ConstructorTest()
        {
            var veteran = GetTestVeteran();

            Assert.That(veteran.YearsOfService, Is.EqualTo(45));
            Assert.That(veteran.PensionAmount, Is.EqualTo(15000));
        }

        [Test]
        public void GetInfo_Veteran()
        {
            var veteran = GetTestVeteran();
            var info = veteran.GetInfo();

            Assert.That(info.Length, Is.EqualTo(4));
            Assert.That(info[0], Is.EqualTo("Петр Петров, звание: Полковник, часть: 67890"));
            Assert.That(info[1], Is.EqualTo(
                $"Военный билет: CD789012. Дата поступления на службу: 15.03.2000. Тип службы: контрактная. Срок службы: {DateTime.Now.Year - 2000} лет."));
            Assert.That(info[2], Is.EqualTo("Выслуга лет: 45"));
            Assert.That(info[3], Is.EqualTo("Размер пенсии: 15000 руб."));
        }

        private Veteran GetTestVeteran()
        {
            return new Veteran(
                "Петр", "Петров", "CD789012", "Полковник", "67890",
                "15.03.2000", ServiceType.Contract, 45, 15000);
        }
    }

    [TestFixture]
    public class ServicemanComparisonTests
    {
        [Test]
        public void CompareToTest()
        {
            var boris = new Serviceman("Борис", "Алексеев", "AB123459", "Рядовой","12345", 
                "10.05.2021", ServiceType.Conscription);
            var alexey = new Serviceman("Алексей", "Сидоров", "AB123458", "Капитан","12345", 
                "10.05.2018", ServiceType.Contract);
            var ivan = new Serviceman("Иван", "Иванов", "AB123456", "Сержант","12345", 
                "10.05.2020", ServiceType.Contract);
            var petr = new Serviceman("Петр", "Петров", "AB123457", "Лейтенант","54321", 
                "10.05.2019", ServiceType.Contract);

            Assert.That(petr.CompareTo(ivan), Is.GreaterThan(0)); 
            Assert.That(ivan.CompareTo(petr), Is.LessThan(0));   
            Assert.That(boris.CompareTo(ivan), Is.LessThan(0));  
            Assert.That(alexey.CompareTo(boris), Is.GreaterThan(0)); 

            var ivan2 = new Serviceman("Иван", "Иванов", "XX000000", "Рядовой","12345", 
                "01.01.2020", ServiceType.Conscription);

            Assert.That(ivan.CompareTo(ivan2), Is.EqualTo(0)); 
        }
    }
    [TestFixture]
    public class MilitaryUnitTests
    {
        private MilitaryUnit unit;
        private Serviceman[] servicemen;

        [SetUp]
        public void Setup()
        {
            servicemen = new Serviceman[]
            {
            new Serviceman("Иван", "Иванов", "AB123456", "Сержант", "12345", "10.05.2020", ServiceType.Contract),
            new Serviceman("Петр", "Петров", "AB123457", "Лейтенант", "12345", "10.05.2019", ServiceType.Contract),
            new Serviceman("Алексей", "Сидоров", "AB123458", "Капитан", "54321", "10.05.2018", ServiceType.Contract),
            new Serviceman("Иван", "Иванов", "AB123456", "Сержант", "12345", "10.05.2020", ServiceType.Contract)
            };

            unit = new MilitaryUnit("Первая рота", "12345", servicemen);
        }
        [Test]
        public void ConstructorTest()
        {
            Assert.That(unit.Name, Is.EqualTo("Первая рота"));
            Assert.That(unit.UnitNumber, Is.EqualTo("12345"));

            Assert.That(unit.Count, Is.EqualTo(2));
        }
        [Test]
        public void IEnumerableTest()
        {
            var expectedMembers = servicemen
                .Where(s => s.UnitNumber == "12345")
                .Distinct()
                .ToArray();

            var i = 0;
            foreach (var serviceman in unit)
                Assert.That(serviceman, Is.SameAs(expectedMembers[i++]));
        }
    }
}