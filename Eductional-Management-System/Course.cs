using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eductional_Management_System
{
    public class Course
    {
        public string Name { get; set; }
        public string Code {  get; set; }
        public int Id { get; set; }
        public Doctor? taughtBy;
        public List<Student> students = new List<Student>();

        public Course(string name,string code,int id)
        {
            this.Name = name;
            this.Code = code;
            this.Id = id;
        }
        public void view()
        {
            Console.WriteLine($"{this.Id} {this.Name} {this.Code}");
        }
        public void addStudent(Student student)
        {
            students.Add(student);
        }
        public void removeStudent(int id)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id == id)
                {
                    students.Remove(students[i]);
                    break;
                }
            }
        }
        public void addDoctor(Doctor doctor)
        {
            this.taughtBy = doctor;
        }
        public void viewStudents()
        {
            Console.WriteLine("Id\\tName");
            foreach (Student student in this.students)
            {
                student.view();
            }
        }
       
    }
}
