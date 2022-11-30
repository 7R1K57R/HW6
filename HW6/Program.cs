using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            int ID;
            string fullName;
            int age;
            int height;
            DateTime bDate;
            string bLocation;
            char key = 'в';
            do
            {
                Console.WriteLine("Для просмотра записей нажмите 1\nДля того, чтобы добавить запись нажмите 2");
                var i = Console.ReadLine();
                switch (i)
                { 
                    case "1":
                        if (File.Exists(@"Employees.txt"))
                        {
                            if (new FileInfo(@"Employees.txt").Length == 0)
                            {
                                Console.WriteLine("Нет записей");
                            }
                            string[] lines = File.ReadAllLines(@"Employees.txt");
                            foreach (var item in lines)
                            {
                                string[] sep = item.Split('#');
                                foreach (var el in sep)
                                {
                                    Console.Write($"{el} ");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            using (FileStream create = File.Create(@"Employees.txt")) ;
                            Console.WriteLine("Нет записей");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите Ф.И.О. сотрудника через пробелы:");
                        fullName = Console.ReadLine();
                        Console.WriteLine("Введите рост сотрудника:");
                        height = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите дату рождения сотрудника в формате дд.мм.гггг :");
                        bDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Введите родной город сотрудника:");
                        bLocation = Console.ReadLine();
                        if (File.Exists(@"Employees.txt"))
                        { }
                        else
                        {
                            using (FileStream create = File.Create(@"Employees.txt"));
                        }
                        int lineCount = File.ReadAllLines(@"Employees.txt").Length;
                        ID = lineCount + 1;
                        StreamWriter notes = new StreamWriter(@"Employees.txt", true);
                        age = DateTime.Today.Year - bDate.Year;
                        notes.WriteLine($"{ID}#{DateTime.Now}#{fullName}#{age}#{height}#{bDate}#{bLocation}#");
                        notes.Close();
                        break;
                    default:
                        Console.WriteLine("Попробуйте еще раз");
                        continue;
                }
                Console.WriteLine("Для продолжения нажмите любую клавишу, для выхода нажмите \"в\""); 
                key = Console.ReadKey(true).KeyChar;
            } while (char.ToLower(key) != 'в');
        }
    }
}
