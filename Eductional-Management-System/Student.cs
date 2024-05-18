using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Eductional_Management_System
{
    public class Student:Person
    {
        public List<Course> courses = new List<Course>();
        public Student() : base() 
        { 
        
        }
        public Student(string name, string username, string password, int id):base(name, username, password, id)
        {
               
        }
       
        public void addCourse(Course course)
        {
            courses.Add(course);
        }
        public void view()
        {
            Console.WriteLine($"{this.Id} {this.Name}");
        }

        public void viewCourses()
        {
            
            foreach (var course in this.courses)
            {
                course.view();
            }
        }
        public bool viewCourse(string code)
        {
            foreach (var course in this.courses)
            {
                if (course.Code == code)
                {
                    course.view();
                    return true;
                    break;
                }
            }
            return false;
        }
        public void removeCourse(string code)
        {
            for(int i = 0; i < courses.Count; i++)
            {
                if(courses[i].Code == code)
                {
                    courses.Remove(courses[i]);
                    break;
                }
            }
        }

    }
}
