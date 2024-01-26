using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lmsProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> data = new List<Student>();
            Console.WriteLine("***********LEARNING MANAGEMENT SYSTEM******************");
           
        }
        static void signup(Student s1, List<data>)
        {
            Console.Write("Emter your name: ");
            Student student = new Student();
            student.Name = Console.ReadLine();
            student.password = Console.ReadLine();
            student.role = Console.ReadLine();
            data.add(student);

        }
    }
}
