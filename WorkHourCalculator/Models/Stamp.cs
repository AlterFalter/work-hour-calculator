using System;

namespace WorkHourCalculator.Models
{
    public class Stamp
    {
        public DateTime DateTime { get; set; }

        public string Note { get; set; }

        public Stamp(DateTime datetime, string note = "")
        {
            DateTime = datetime;
            Note = note;
        }
    }
}
