using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class Serviceman
    {
        public string Name {get; set;}
        public string Surname {get; set;}

        public readonly string MilitaryId;              
        public string Rank {get; set;}               
        public string UnitNumber {get; set;}         
        public DateTime EnlistmentDate {get; set;}    
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
}