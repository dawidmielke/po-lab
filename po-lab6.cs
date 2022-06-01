using System.Collections.Generic;
using System;

namespace po_lab6
{
    class Student
    {
        public string Name { get; set; }
        public int Ects { get; set; }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (student == null)
                return false;

            return Name == student.Name && Ects == student.Ects;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Ects);
        }

        public override string ToString()
        {
            return $"Student {{ name = {Name}, ects = {Ects} }}";
        }
    }

    record Person(string Name, string Surname, string Email);

    class Program
    {
        static void Main(string[] args)
        {
            ICollection<string> names = new List<string>();
            names.Add("John");
            names.Add("Mary");
            Console.WriteLine(names.Contains("John"));

            ICollection<Student> students = new List<Student>();
            students.Add(new Student { Name = "John", Ects = 3 });
            students.Add(new Student { Name = "Mary", Ects = 5 });

            Console.WriteLine(students.Contains(new Student { Name = "John", Ects = 3 }));

            ICollection<Person> people = new List<Person>();
            people.Add(new Person("Will", "Smith", "will@email.com"));
            people.Add(new Person("Mary", "Smith", "mary@email.com"));

            Console.WriteLine(people.Contains(new Person("Will", "Smith", "will@email.com")));

            foreach (var student in students)
                Console.WriteLine(student);

            people.Remove(new Person("Will", "Smith", "will@email.com"));

            List<Person> peopleList = (List<Person>)people;
            peopleList.Insert(0, new Person("Andrew", "Dow", "andrew@gmail.com"));

            ISet<Student> team = new HashSet<Student>();
            team.Add(new Student { Name = "John", Ects = 3 });
            team.Add(new Student { Name = "Mary", Ects = 5 });
            team.Add(new Student { Name = "Andrew", Ects = 8 });
            team.Add(new Student { Name = "Mark", Ects = 3 });

            Console.WriteLine(string.Join(",\n", team));
            Console.WriteLine(team.Contains(new Student { Name = "John", Ects = 3 }));

            IDictionary<string, Person> addressBook = new Dictionary<string, Person>();
            addressBook.Add("will@email.com", new Person("Will", "Smith", "will@email.com"));
            addressBook.Add("mary@email.com", new Person("Mary", "Smith", "mary@email.com"));

            Console.WriteLine(addressBook["will@email.com"]);

            int[] arr = { 1, 2, 3, 4, 5 };
            Dictionary<int, int> counters = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                if (counters.ContainsKey(item))
                    counters[item]++;
            }

            Console.WriteLine("Osoby");
            peopleList.Sort((A, B) => -A.Name.CompareTo(B.Name));
            Console.WriteLine(string.Join("\n", peopleList));

            List<Student> list = new List<Student>(team);
            //list.Sort((A, B) => -A.Ects.CompareTo(B.Ects));
            list.Sort((A, B) => A.Name.CompareTo(B.Name) == 0 ? A.Ects.CompareTo(B.Ects) : A.Name.CompareTo(B.Name));
            Console.WriteLine(string.Join("\n", list));

        }
    }
}
