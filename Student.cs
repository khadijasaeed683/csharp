using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lmsProject
{
    internal class Student
    {
        public string Name;
        public string password;
        public string role;
        public class Student(string name,string pass, string role)
        {
                this.name=name;
                this.password= pass;
                this.role=role;
        }





    }
}
