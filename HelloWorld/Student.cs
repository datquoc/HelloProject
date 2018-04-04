using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Student
    {
        private List<Student> list = new List<Student>(); 
        private int id;
        private string name;
        private string rollNumber;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string RollNumber { get => rollNumber; set => rollNumber = value; }

        public Student(int id, string name, string rollNumber)
        {
            this.id = id;
            this.name = name;
            this.rollNumber = rollNumber;
        }

        public override string ToString()
        {
            return this.id + " - " + this.name + " - " + this.rollNumber;
        }

        public Student()
        {
        }

        public Student(string name, string rollNumber)
        {
            this.name = name;
            this.rollNumber = rollNumber;
        }
    }
}
