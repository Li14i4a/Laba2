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
            string test3 = "SubjectWithType 17.02.2022              20:30:48                \"Джордж Хендрикс\" Зачет";

            Console.WriteLine(result(test));
            Console.WriteLine(result(test2));
            Console.WriteLine(result(test3));
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
            string result(string str)
            { 
                switch (str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0])
                {
                    case "Subject":
                        {
                            Subject Obj = ToSubject(str.Replace("Subject", ""));
                            return($"Дата: {Obj.Date.ToString("dd.MM.yyyy")}\nВремя: {Obj.Time}\nИмя: {Obj.Name}");
                        }
                    case "SubjectWithDifficultyLevel":
                        {
                            SubjectWithDifficultyLevel Obj = ToSubjectWithDifficultyLevel(str.Replace("SubjectWithDifficultyLevel", ""));
                            return($"Дата: {Obj.Date.ToString("dd.MM.yyyy")}\nВремя: {Obj.Time}\nИмя: {Obj.Name}\nУровень сложности: {Obj.DifficultyLevel}");
                        }
                    case "SubjectWithType":
                        {
                            SubjectWithType Obj = ToSubjectWithType(str.Replace("SubjectWithType", ""));
                            return($"Дата: {Obj.Date.ToString("dd.MM.yyyy")}\nВремя: {Obj.Time}\nИмя: {Obj.Name}\nУровень сложности: {Obj.TypeOfSubject}");
                        }
                }
                return ("что-то пошло не так");
            }
        }
    }
}
