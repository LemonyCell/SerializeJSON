using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace SerializeJSON
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Sex { get; set; }
    }
}
