using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class Serviceman
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public readonly string MilitaryId;
        public string Rank { get; set; }
        public string UnitNumber { get; set; }
        public DateTime EnlistmentDate { get; set; }
        public readonly ServiceType Service;

        public int ServiceTerm => DateTime.Now.Year - EnlistmentDate.Year;

        public Serviceman(string name, string surname, string militaryId, string rank, string unitNumber, string enlistmentDate, ServiceType service)
        {
            Name = name;
            Surname = surname;
            MilitaryId = militaryId;
            Rank = rank;
            UnitNumber = unitNumber;
            Service = service;

            if (!DateTime.TryParse(enlistmentDate, out DateTime parsedDate))
                throw new ArgumentException("Неправильная дата поступления на службу");
            EnlistmentDate = parsedDate;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[2];
            info[0] = $"{Name} {Surname}, звание: {Rank}, часть: {UnitNumber}";

            string serviceType = Service == ServiceType.Conscription ? "срочная" : "контрактная";

            info[1] = $"Военный билет: {MilitaryId}. Дата поступления на службу: {EnlistmentDate:d}. Тип службы: {serviceType}. Срок службы: {ServiceTerm} лет.";
            return info;
        }
    }
    public class CommandStaff : Serviceman
    {
        public string Division { get; set; } 
        public string Position { get; set; } 

        public CommandStaff(string name, string surname, string militaryId, string unitNumber,
            string enlistmentDate, ServiceType service, string rank,
                            string division, string position)
            : base(name, surname, militaryId, rank, unitNumber, enlistmentDate, service)
        {
            Division = division;
            Position = position;
        }
        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[4];
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Подразделение: {Division}";
            info[3] = $"Должность: {Position}";
            return info;
        }
    }
    public class ManagementBody : Serviceman
    {
        public string District { get; set; } 
        public string Position { get; set; } 

        public ManagementBody(string name, string surname, string militaryId, string rank, string unitNumber, 
            string enlistmentDate, ServiceType service, string district, string position)
            : base(name, surname, militaryId, rank, unitNumber,
            enlistmentDate, service)
        {
            District = district;
            Position = position;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[4];
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Округ: {District}";
            info[3] = $"Должность: {Position}";
            return info;
        }
    }
    public class Veteran : Serviceman
    {
        public int YearsOfService { get; set; } 
        public decimal PensionAmount { get; set; } 

        public Veteran(string name, string surname, string militaryId, string rank, string unitNumber,
            string enlistmentDate, ServiceType service, int yearsOfService, decimal pensionAmount)
            : base(name, surname, militaryId, rank, unitNumber,enlistmentDate, service)
        {
            YearsOfService = yearsOfService;
            PensionAmount = pensionAmount;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[4];
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"Выслуга лет: {YearsOfService}";
            info[3] = $"Размер пенсии: {PensionAmount} руб.";
            return info;
        }
    }
}
