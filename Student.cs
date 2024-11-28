using System;

namespace lab7
{
    public class Student : Person, IComparable
    {
        public string University { get; set; }
        public string Specialty { get; set; }
        public int Year { get; set; }
        public int Rating1 { get; set; }
        public int Rating2 { get; set; }
        public int Rating3 { get; set; }
        public bool Scholarship { get; set; }

        public Student() : base("", "", 0) { }

        public Student(string name, string surname, int age, string university, string specialty, int year, int rating1, int rating2, int rating3, bool scholarship)
            : base(name, surname, age)
        {
            University = university;
            Specialty = specialty;
            Year = year;
            Rating1 = rating1;
            Rating2 = rating2;
            Rating3 = rating3;
            Scholarship = scholarship;
        }

        public double CalculateAverageGrade()
        {
            double sum = Rating1 + Rating2 + Rating3;
            return sum / 3;
        }

        public override string GetInfo()
        {
            return $"{Name} {Surname}, {Age} років, студент спеціальності {Specialty} ({University}).";
        }

        public int CompareTo(object obj)
        {
            Student student = obj as Student;
            return Name.CompareTo(student.Name);
        }
    }
}
