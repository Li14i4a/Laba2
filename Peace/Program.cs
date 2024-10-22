using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Peace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string test = "Subject 17.02.2022              20:30:48                \"Джордж Хендрикс\"";

            switch (test.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0])
            { 
                case "Subject":
                {
                        Subject testObj = ToSubject(test.Replace("Subject", ""));
                        Console.WriteLine($"Дата: {testObj.Date.ToString("dd.MM.yyyy")}\nВремя: {testObj.Time}\nИмя: {testObj.Name}");
                        break;
                }
            }
            Console.ReadKey();
            Subject ToSubject(string str)
            {
                List<string> items = str.Trim().Split('"').ToList();
                List<string> values = items[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string name = items[1].Trim();
                DateTime date = DateTime.Parse(values[0].Trim()).Date;
                TimeSpan time = DateTime.Parse(values[1].Trim()).TimeOfDay;
                return new Subject(date, time, name);
            }
        }
    }
}
