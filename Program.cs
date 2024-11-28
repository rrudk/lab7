using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    internal class Program
    {
        static List<Person> people;
        static void Main(string[] args)
        {
            people = new List<Person>();
            FileStream fs = new FileStream("Students.student", FileMode.Open);
            BinaryReader reader = new BinaryReader(fs);

            try
            {
                Student student;
                Console.WriteLine("\tЧИТАЄМО ДАНІ З ФАЙЛУ...\n");
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    student = new Student();
                    for (int i = 1; i <= 10; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                student.Name = reader.ReadString();
                                break;
                            case 2:
                                student.Surname = reader.ReadString();
                                break;
                            case 3:
                                student.Age = reader.ReadInt32();
                                break;
                            case 4:
                                student.University = reader.ReadString();
                                break;
                            case 5:
                                student.Specialty = reader.ReadString();
                                break;
                            case 6:
                                student.Year = reader.ReadInt32();
                                break;
                            case 7:
                                student.Rating1 = reader.ReadInt32();
                                break;
                            case 8:
                                student.Rating2 = reader.ReadInt32();
                                break;
                            case 9:
                                student.Rating3 = reader.ReadInt32();
                                break;
                            case 10:
                                student.Scholarship = reader.ReadBoolean();
                                break;
                        }
                    }
                    people.Add(student);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Сталася помилка: {0}", ex.Message);
            }
            finally
            {
                reader.Close();
            }

            Console.WriteLine("Несортований перелік студентів: {0}", people.Count);
            PrintStudents();

            people.Sort(); 
            Console.WriteLine("\nСортований перелік студентів за іменем: {0}", people.Count);
            PrintStudents();

            Console.WriteLine("\nДодаємо новий запис: Олександр Лівак");
            people.Add(new Student("Олександр", "Лівак", 18, "ВНТУ", "ІСТ", 2024, 77, 66, 82, false));

            Console.WriteLine("\nПерелік студентів: {0}", people.Count);
            PrintStudents();

            Console.WriteLine("\nВидаляємо останнє значення");
            people.RemoveAt(people.Count - 1);

            Console.WriteLine("\nПерелік студентів: {0}", people.Count);
            PrintStudents();

            while(true) Console.ReadKey();
        }

        static void PrintStudents()
        {
            foreach(Student student in people) 
            {
                Console.WriteLine(student.GetInfo().Replace('і', 'i'));
            }
            Console.WriteLine();
        }
    }
}
