using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP3
{
    class TreeNodeTag
    {
        public Object Value { get; set; }

        public Type NodeType { get; set; }

        public PropertyInfo PropertiesInfo { get; set; } 
    }
}
