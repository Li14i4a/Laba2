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
            string test2 = "SubjectWithDifficultyLevel 17.02.2022              20:30:48                \"Джордж Хендрикс\" 6";
            string test3 = "SubjectWithDifficultyLevel 17.02.2022              20:30:48                \"Джордж Хендрикс\" Зачет";

            switch (test3.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0])
            { 
                case "Subject":
                {
                    Subject testObj = ToSubject(test.Replace("Subject", ""));
                    Console.WriteLine($"Дата: {testObj.Date.ToString("dd.MM.yyyy")}\nВремя: {testObj.Time}\nИмя: {testObj.Name}");
                    break;
                }
                case "SubjectWithDifficultyLevel":
                {
                    SubjectWithDifficultyLevel testObj = ToSubjectWithDifficultyLevel(test2.Replace("SubjectWithDifficultyLevel", ""));
                    Console.WriteLine($"Дата: {testObj.Date.ToString("dd.MM.yyyy")}\nВремя: {testObj.Time}\nИмя: {testObj.Name}\nУровень сложности: {testObj.DifficultyLevel}");
                    break;
                }
                case "SubjectWithType":
                {
                    SubjectWithType testObj = ToSubjectWithType(test3.Replace("SubjectWithDifficultyLevel", ""));
                    Console.WriteLine($"Дата: {testObj.Date.ToString("dd.MM.yyyy")}\nВремя: {testObj.Time}\nИмя: {testObj.Name}\nУровень сложности: {testObj.TypeOfSubject}");
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
            SubjectWithDifficultyLevel ToSubjectWithDifficultyLevel(string str)
            {
                List<string> items = str.Trim().Split('"').ToList();
                List<string> values = items[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string name = items[1].Trim();
                DateTime date = DateTime.Parse(values[0].Trim()).Date;
                TimeSpan time = DateTime.Parse(values[1].Trim()).TimeOfDay;
                int difficultyLevel = Convert.ToInt32(items[2].Trim());
                return new SubjectWithDifficultyLevel(date, time, name, difficultyLevel);
            }
            SubjectWithType ToSubjectWithType(string str)
            {
                List<string> items = str.Trim().Split('"').ToList();
                List<string> values = items[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string name = items[1].Trim();
                DateTime date = DateTime.Parse(values[0].Trim()).Date;
                TimeSpan time = DateTime.Parse(values[1].Trim()).TimeOfDay;
                string type = items[2].Trim();
                return new SubjectWithType(date, time, name, type);
            }
        }
    }
}
