using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace
{
    internal class SubjectWithDifficultyLevel : Subject
    {
        public int DifficultyLevel { get; set; }
        public SubjectWithDifficultyLevel(DateTime date, TimeSpan time, string name, int difficultyLevel):base(date,time,name)
        {
            Date = date;
            Time = time;
            Name = name;
            DifficultyLevel = difficultyLevel;
        }
    }
}
