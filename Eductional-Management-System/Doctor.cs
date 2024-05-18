using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eductional_Management_System
{
    public class Doctor:Person
    {
        public List<Course> Courses = new List<Course>();
        public Doctor() : base()
        {

        }
        public Doctor(string name,string username,string password,int id):base(name,username,password,id)
        {
            
        }
        public void addCourse(Course course)
        {
            Courses.Add(course);
        }
        public void view()
        {
            Console.WriteLine($"{this.Id} {this.Name}");
        }
        public void viewCourses()
        {
            
            foreach (var course in this.Courses)
            {
                course.view();
            }
        }
        public bool viewCourse(string code)
        {
            foreach(var course in this.Courses)
            {
                if(course.Code == code)
                {
                    course.view();
                    return true;
                    break;
                }
            }
            return false;
        }
    }
}
