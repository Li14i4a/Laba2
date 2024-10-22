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
            string test = "17.02.2022             20:30:48                \"Джордж Хендрикс\"";
            Subject ToObj(string str)
            {
                str = str.Trim();
                List<string> items = str.Split('"').ToList();
                string name = "";
                List<string> values = new List<string>();
                values = items[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                name = items[1].Trim();
                DateTime date = DateTime.Parse(values[0].Trim()).Date;
                TimeSpan time = DateTime.Parse(values[1].Trim()).TimeOfDay;
                return new Subject(date, time, name);
            }
            Subject testObj = ToObj(test);
            Console.WriteLine($"Дата: {testObj.Date.ToString("dd.MM.yyyy")}\nВремя: {testObj.Time}\nИмя: {testObj.Name}");
            Console.ReadKey();
        }
    }
}
