using System;
using System.Collections.Generic;

namespace School
{ 

    public class Student
    {
        private const double CREDITS_PER_YEAR = 24.0;

        private static int nextStudentId = 1;
        public string Name { get; set; }
        public int StudentId { get; set; }
        public int NumberOfCredits { get; set; }
        public double Gpa { get; set; }

        public Student(string name, int studentId,
                int numberOfCredits, double gpa)
        {
            Name = name;
            StudentId = studentId;
            NumberOfCredits = numberOfCredits;
            Gpa = gpa;
        }

        public Student(string name, int studentId)
            : this(name, studentId, 0, 0) { }

        public Student(string name)
            : this(name, nextStudentId)
        {
            nextStudentId++;
        }

        public void AddGrade(int courseCredits, double grade)
        {
            double newTotalGrade = Gpa * NumberOfCredits + grade * courseCredits;


            NumberOfCredits += courseCredits;
            Gpa = newTotalGrade / NumberOfCredits;
        }

        public string GetGradeLevel()
        {
            if (NumberOfCredits > CREDITS_PER_YEAR * 3)
            {
                return "Senior";
            }
            else if (NumberOfCredits > CREDITS_PER_YEAR * 2)
            {
                return "Junior";
            }
            else if (NumberOfCredits > CREDITS_PER_YEAR)
            {
                return "Sophmore";
            }
            else
            {
                return "Freshman";
            }


        }


        public override string ToString()
        {
            return Name + "(Credits: " + NumberOfCredits + ", GPA: " + Gpa + ")";
        }


        public override bool Equals(object obj)
        {
            bool compare = false;
            Student studentObj;

            if (obj == null || (obj.GetType() != this.GetType()))
            {
                return false;
            }

            //if (obj == null)
            //{
            //    return false;
            //}

            //if (obj.GetType() != this.GetType())
            //{
            //    return false;
            //} two old conditions that get combined as one up above

            studentObj = obj as Student;

            if (this.StudentId == studentObj.StudentId &&
                this.Name == studentObj.Name)
            {
                compare = true;
            }

            return compare;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() *1000 + StudentId;
        }

        public static double GetCreditsPerYear()
        {
            return CREDITS_PER_YEAR;
        }

    }


public class Course
{
    public int CourseID { get; protected set; }
    public string Name { get; set; }
    public bool RequiresPrereq { get; set; }
    public decimal NumCredits { get; protected set; }
    public string Instructor { get; set; }
    public List<Student> ClassRoster { get; set; }

    public Course(int courseId, string name, bool requiredsPrereq, decimal numCredits, string instructor)
    {
        this.CourseID = courseId;
        this.Name = name;
        this.RequiresPrereq = RequiresPrereq;
        this.NumCredits = numCredits;
        this.Instructor = instructor;
        this.ClassRoster = null;

    }

    public Course(int courseId, string name) :
        this(courseId, name, false, 0, "")
    {

    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        Student st = new Student("JJ", 0);
        Student st2 = new Student("Maine", 1);
        Student st3 = new Student("Mary", 2);

            Student st4 = st;

        Course c1;
        Course c2;

        c1 = new Course(10, "CodeCamp", false, 14, "Ben");

        c2 = new Course(101, "LC101");

        Console.WriteLine("Name: " + c1.Name + "Credits: " + c1.NumCredits);
        List<Student> roster = new List<Student>() { st2, st3 };

        Console.WriteLine(st.Name + " " + st.StudentId);

        c1.ClassRoster = roster;

            Console.WriteLine("Credits per year: " + Student.GetCreditsPerYear());

            st.AddGrade(10, 3.0);
            st.AddGrade(8, 2.5);
            st.AddGrade(9, 3.7);
            Console.WriteLine("Student: " + st.Name + "GPA: " + st.Gpa);
            Console.WriteLine("Student Level: " + st.GetGradeLevel());

            Console.WriteLine("Student ToString: " + st.ToString());
            Console.WriteLine("Student ToString: " + st);

            Console.WriteLine("1 " + st.Equals(st2));
            Console.WriteLine("2 " + st.Equals(st4));
            Console.WriteLine("3 " + st.Equals(new Student("JJ", 0)));

            Console.WriteLine(st.GetHashCode() + " " + st2.GetHashCode());
            Console.WriteLine(new Student("JJ", 0).GetHashCode());
       

    }

  }

}

