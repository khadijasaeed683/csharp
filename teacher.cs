using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsProject
{
    internal class teacher
    {
        public string Name;
        public string password;
        public string role;
        public class teacher(string name, string pass, string role)
        {
                this.name=name;
                this.password= pass;
                this.role=role;
        }

    }
}
