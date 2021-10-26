using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplateSelectorDemo
{
    public class Person
    {
        public string Name { get; set; }

        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Unknown = 0,
        Female = 1,
        Male = 2,
    }
}
