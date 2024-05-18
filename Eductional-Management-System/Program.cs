using Eductional_Management_System;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;


List<Course> Courses = new List<Course>();
List<Student> Students = new List<Student>();
List<Doctor> Doctors = new List<Doctor>();

buildCourses(ref Courses);
buildStudents(ref Students, ref Courses);
buildDoctors(ref Doctors, ref Courses);

while (true)
{
    Console.Clear();
    Console.WriteLine("please make a choice:");
    Console.WriteLine("1-Sign Up");
    Console.WriteLine("2-Login");
    Console.WriteLine("3-Shut down");

    int choice;
    choice = int.Parse(Console.ReadLine());

    if(choice == 1)
    {
        Console.Clear();
        Console.WriteLine("please make a choice: You are");
        Console.WriteLine("1-Doctor");
        Console.WriteLine("2-Student");
        int ch;
        ch = int.Parse(Console.ReadLine());
        while(ch != 1 && ch != 2)
        {
            Console.WriteLine("please make a valid choice: ");
            ch = int.Parse(Console.ReadLine());
        }
        if (ch == 1)
        {
            Doctor newDoctor = new Doctor();
            Console.WriteLine("Enter your first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your second name:");
            string secondName = Console.ReadLine();
            newDoctor.Name = string.Concat(firstName,' ',secondName);
            newDoctor.Username = firstName;
            Console.WriteLine("Enter password:");
            newDoctor.Password = Console.ReadLine();
            newDoctor.Id = Doctors.Count+1;
            Doctors.Add(newDoctor);
            Console.WriteLine("your account is created successfully");
            Console.ReadLine();
        }
        else if (ch == 2)
        {
            Student newStudent = new Student();
            Console.WriteLine("Enter your first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your second name:");
            string lastName = Console.ReadLine();
            newStudent.Username = firstName;
            newStudent.Name = string.Concat (firstName," ",lastName);
     
            Console.WriteLine("Enter password:");
            newStudent.Password = Console.ReadLine();
            newStudent.Id = Students.Count+1;
            Students.Add(newStudent);
            Console.WriteLine("your account is created successfully");
            Console.ReadLine();
        }

    }
    else if(choice == 2)
    {
        Console.Clear();
        Doctor curDoctor= new Doctor();
        Student curStudent= new Student();
        string isDoctorOrStudent="none";
        Console.WriteLine("Enter Username:");
        string userName = Console.ReadLine();
        Console.WriteLine("Enter Password:");
        string password = Console.ReadLine();
        while (isDoctorOrStudent == "none")
        {
            foreach (Student s in Students)
            {
                if (s.checkLogin(userName, password) == true)
                {
                    curStudent = s;
                    isDoctorOrStudent = "Student";
                    break;
                }
            }
            foreach (Doctor d in Doctors)
            {
                if (d.checkLogin(userName, password) == true)
                {
                    curDoctor = d;
                    isDoctorOrStudent = "Doctor";
                    break;
                }
            }
            if (isDoctorOrStudent == "none")
            {
                Console.WriteLine("Username or Password is not correct \t please enter correct data");
            }
        }
        if(isDoctorOrStudent == "Student")
        {
            Console.Clear();
            Console.WriteLine($"welcome {curStudent.Name}. you are logged in");
            while (true)
            {
        
                Console.WriteLine("please make choice:");
                Console.WriteLine("1- Register in a Course");
                Console.WriteLine("2- List my courses");
                Console.WriteLine("3- View course");
                Console.WriteLine("4- Log out");
                int ch= int.Parse(Console.ReadLine());
                if(ch == 1)
                {
                    Console.Clear();
                    foreach(Course c in Courses)
                    {
                        Console.WriteLine($"{c.Id} {c.Name} {c.Code} taught by Dr:{c.taughtBy.Name} and has {c.students.Count} students");
                    }
                    Console.WriteLine("which Id course you want register? ");
                    int id = int.Parse(Console.ReadLine());
                    while (id <= 0 || id > Courses.Count)
                    {
                        Console.WriteLine("Enter valid id");
                        id = int.Parse(Console.ReadLine());
                    }
                    foreach(Course c in Courses)
                    {
                        if (id == c.Id)
                        {
                            c.addStudent(curStudent);
                            curStudent.addCourse(c);
                            break;
                        }
                    }
                }else if(ch == 2)
                {
                    if (curStudent.courses.Count == 0)
                    {
                        Console.WriteLine("you are not registered in any course");
                    }
                    else
                    {
                        curStudent.viewCourses();
                    }
                }else if (ch == 3)
                {
                    Console.Clear();
                    foreach (Course c in curStudent.courses)
                    {
                        Console.WriteLine($"{c.Id} {c.Name} {c.Code}");
                    }
                    Console.WriteLine("which Code course to view?");

                    string code = Console.ReadLine();
                    while (!curStudent.viewCourse(code))
                    {
                        Console.WriteLine("enter valid id");
                        code = Console.ReadLine();
                    }

                    Console.WriteLine("press any key to go back");
                    Console.ReadLine();
                }
                else if (ch == 4)
                {
                    Console.WriteLine("you are logged out");
                    break;
                }
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"welcome Dr{curDoctor.Name}.you are logged in");
            while (true)
            {
                Console.WriteLine("please make choice:");
                Console.WriteLine("1- List courses");
                Console.WriteLine("2- Create course");
                Console.WriteLine("3- View course");
                Console.WriteLine("4- Log out");
                int ch = int.Parse(Console.ReadLine());
                if (ch == 1)
                {
                    Console.WriteLine("All available courses are:");
                    foreach (Course c in Courses)
                    {
                        Console.WriteLine($"{c.Id} {c.Name} {c.Code} taught by Dr:{c.taughtBy.Name} and has {c.students.Count} students");
                    }
                    Console.WriteLine("Press any key to go back");
                    Console.ReadLine();
                }
                else if (ch == 2)
                {
                    Console.WriteLine("Enter course name(two words only)");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter course code");
                    string code = Console.ReadLine();
                    Console.WriteLine("course is created successfully");
                    Course newCourse = new Course(name, code,Courses.Count+1);
                    newCourse.addDoctor(curDoctor);
                    curDoctor.addCourse(newCourse);
                    Courses.Add(newCourse);
                    Console.ReadLine();
                    Console.Clear();
                }else if (ch == 3)
                {
                    if (curDoctor.Courses.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("you are not teaching any courses");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        curDoctor.viewCourses();
                        Console.WriteLine("which Code course to view?");
                        string code = Console.ReadLine();
                        while (!curDoctor.viewCourse(code))
                        {
                            Console.WriteLine("enter valid id");
                            code = Console.ReadLine();
                        }
                        Console.WriteLine("press any key to go back");
                        Console.ReadLine();
                    }
                    
                }else if(ch == 4)
                {
                    Console.WriteLine("you are logged out");
                    break;
                }
                Console.Clear ();
            }
        }
    }else if(choice == 3)
    {
        Console.Clear();
        Console.WriteLine("your application is shut down");
        break;
    }
    else
    {
        Console.WriteLine("please enter a valid choice:");
        Thread.Sleep(3000);
    }

    storeCourses(ref Courses);
    storeStudents(ref Students);
    storeDoctors(ref Doctors);
}

#region viewAll
//foreach (var course in Courses)
//{
//    course.view();
//}
//Console.WriteLine("------------------------------");
//foreach (var student in Students)
//{
//    student.view();
//    student.viewCourses();
//}
//Console.WriteLine("-----------------------------");
//foreach(var doctor in Doctors)
//{
//    doctor.view();
//    doctor.viewCourses();
//}
#endregion



#region functions
void buildCourses(ref List<Course>courses)
{
    string filepath = "C:\\Users\\Dell\\Desktop\\Eductional system\\dummy data\\Courses\\Course data.txt";
    using(StreamReader reader = File.OpenText(filepath)) {
        string line = reader.ReadLine();
        int counter = 0;
        while (line != null)
        {
            string[] data = line.Split(' ');
            Course c = new Course(data[0]+' ' + data[1], data[2],++counter);
            courses.Add(c);
            line = reader.ReadLine();
        }
    }
}

void storeCourses(ref List<Course> courses)
{
    string filepath = "C:\\Users\\Dell\\Desktop\\Eductional system\\dummy data\\Courses\\Course data.txt";
    using(StreamWriter writer = new StreamWriter(filepath))
    {
        foreach(Course c in courses)
        {
            writer.WriteLine(c.Name+' '+c.Code);
        }
        writer.Close();
    }
}

void buildStudents(ref List<Student>students,ref List<Course>courses)
{
    string filepath = "C:\\Users\\Dell\\Desktop\\Eductional system\\dummy data\\Students\\Names.txt";
    using (StreamReader reader = File.OpenText(filepath))
    {
        string line = reader.ReadLine();
        int counter = 0;
        while (line != null)
        {
            string[] data = line.Split(' ');
            Student s = new Student(data[0] + ' ' + data[1],data[0], data[2], ++counter);
            students.Add(s);
            line = reader.ReadLine();
        }
    }
    filepath = "C:\\Users\\Dell\\Desktop\\Eductional system\\dummy data\\Students\\Courses.txt";
    using (StreamReader reader1 = File.OpenText(filepath))
    {
        string line = reader1.ReadLine();
 
        while (line != null)
        {
            foreach (Student student in students)
            {
                string[] data = line.Split(' ');
                for (int i = 0; i < data.Length; i++)
                {
                    for(int j = 0;j<courses.Count; j++)
                    {
                        if (data[i] == courses[j].Code)
                        {
                            student.addCourse(courses[j]);
                            courses[j].addStudent(student);
                            break;
                        }
                    }
                }
                line = reader1.ReadLine();
            }  
        }
    }
}

void storeStudents(ref List<Student>students)
{
    string filepath = "C:\\Users\\Dell\\Desktop\\Eductional system\\dummy data\\Students\\Names.txt";
    using (StreamWriter writer = new StreamWriter(filepath))
    {
        foreach (Student s in students)
        {
            writer.WriteLine(s.Name + ' ' + s.Password);
        }
        writer.Close();
    }
    filepath = "C:\\Users\\Dell\\Desktop\\Eductional system\\dummy data\\Students\\Courses.txt";
    using(StreamWriter writer = new StreamWriter(filepath))
    {
        foreach(Student s in students)
        {
            foreach(Course c in s.courses)
            {
                writer.Write(c.Code);
                writer.Write(' ');
            }
            writer.Write('\n');
        }
        writer.Close();
    }
}

void buildDoctors(ref List<Doctor>doctors,ref List<Course>courses)
{
    string filepath = "C:\\Users\\Dell\\Desktop\\Eductional system\\dummy data\\Doctors\\Names.txt";
    using (StreamReader reader = File.OpenText(filepath))
    {
        string line = reader.ReadLine();
        int counter = 0;
        while (line != null)
        {
            string[] data = line.Split(' ');
            Doctor d = new Doctor(data[0] , data[0], data[1], ++counter);
            doctors.Add(d);
            line = reader.ReadLine();
        }
    }

    filepath = "C:\\Users\\Dell\\Desktop\\Eductional system\\dummy data\\Doctors\\Courses.txt";
    using (StreamReader reader1 = File.OpenText(filepath))
    {
        string line = reader1.ReadLine();
 
        while (line != null)
        {
            foreach (Doctor doctor in doctors)
            {
                string[] data = line.Split(' ');
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] == "0")
                    {
                        continue;
                    }
                    for (int j = 0; j < courses.Count; j++)
                    {
                        if (data[i] == courses[j].Code)
                        {
                            doctor.addCourse(courses[j]);
                            courses[j].addDoctor(doctor);
                            break;
                        }
                    }
                }
                line = reader1.ReadLine();
            }
        }
    }
}

void storeDoctors(ref List<Doctor> doctors)
{
    string filepath = "C:\\Users\\Dell\\Desktop\\Eductional system\\dummy data\\Doctors\\Names.txt";
    using (StreamWriter writer = new StreamWriter(filepath))
    {
        foreach (Doctor d in doctors)
        {
            writer.WriteLine(d.Name + ' ' + d.Password);
        }
        writer.Close();
    }
    filepath = "C:\\Users\\Dell\\Desktop\\Eductional system\\dummy data\\Doctors\\Courses.txt";
    using (StreamWriter writer = new StreamWriter(filepath))
    {
        foreach (Doctor d in doctors)
        {
            foreach (Course c in d.Courses)
            {
                writer.Write(c.Code);
                writer.Write(' ');
            }
            writer.Write('\n');
        }
        writer.Close();
    }
}
#endregion
