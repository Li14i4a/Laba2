using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace
{
    internal class Subject
    {
        public DateTime Date;
        public TimeSpan Time;
        public string Name;
        public Subject(DateTime date, TimeSpan time, string name) 
        {
            Date = date;
            Time = time;
            Name = name;
        }
    }
}
