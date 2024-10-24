﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peace
{
    internal class SubjectWithType : Subject
    {
        public string TypeOfSubject { get; set; }
        public SubjectWithType(DateTime date, TimeSpan time, string name, string typeOfSubject) : base(date, time, name)
        {
            TypeOfSubject = typeOfSubject;
        }
    }
}
