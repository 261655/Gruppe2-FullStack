using System;

namespace Gruppe2.Models
{
    public class Pollenregistrering
    {
        public int ID { get; set; }
        public DateTime date { get; set; }
        public string TypeOfPollen { get; set; }
        public int level { get; set; }
    }
}