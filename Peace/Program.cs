using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Peace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string test = "17.02.2022             20:30:48                \"Джордж оавлыд\"";
            Subject ToObj(string str)
            {
                str = str.Trim();
                List<string> items = str.Split('"').ToList();
                if (items.Count == 3) 
                {
                    List<string> items2 = items[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    string name = items[1].Trim();
                    DateTime date = DateTime.Parse(items2[0].Trim()).Date;
                    TimeSpan time = DateTime.Parse(items2[1].Trim()).TimeOfDay;
                    return new Subject(date, time, name);
                }
                else
                {
                    List<string> items2 = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    string name = items2[2].Trim();
                    DateTime date = DateTime.Parse(items2[0].Trim()).Date;
                    TimeSpan time = DateTime.Parse(items2[1].Trim()).TimeOfDay;
                    return new Subject(date, time, name);
                }
            }
            Subject testObj = ToObj(test);
            Console.WriteLine($"Дата: {testObj.Date.ToString("dd.MM.yyyy")}\nВремя: {testObj.Time}\nИмя:{testObj.Name}");
            Console.ReadKey();
        }
    }
}
