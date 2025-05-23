using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLibrary
{
    public class Serviceman
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public readonly string MilitaryID;
        public string Rank { get; set; }
        public string MilitaryUnit { get; set; }
        public readonly DateTime EnlistmentDate;
        public int ServiceDuration => (DateTime.Now - EnlistmentDate).Days / 365;
        public ServiceType Service { get; set; }

        public Serviceman(string firstName, string lastName, string militaryID, string rank, string militaryUnit, string enlistmentDate, ServiceType service)
        {
            FirstName = firstName;
            LastName = lastName;
            MilitaryID = militaryID;
            Rank = rank;
            MilitaryUnit = militaryUnit;
            Service = service;

            if (!DateTime.TryParse(enlistmentDate, out EnlistmentDate))
                throw new ArgumentException("Неверный формат даты поступления на службу");
        }

        public string[] GetInfo()
        {
            return new string[]
            {
                $"{Rank} {FirstName} {LastName}",
                $"Военный билет: {MilitaryID}",
                $"Часть: {MilitaryUnit}, Тип службы: {Service}",
                $"Дата поступления: {EnlistmentDate:d}, Срок службы: {ServiceDuration} лет"
            };
        }
    }
}