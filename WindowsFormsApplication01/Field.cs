using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService
{
    public class Field
    {
        public string Name { get; private set; }
        public string Type { get; private set; }

        public Field(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}
