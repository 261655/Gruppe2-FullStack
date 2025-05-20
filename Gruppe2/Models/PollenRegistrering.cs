using System;

namespace Gruppe2.Models
{
    public class PollenRegistrering
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string TypeOfPollen { get; set; }
        public int Level { get; set; }
    }
}