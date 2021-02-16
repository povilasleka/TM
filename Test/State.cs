using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class State
    {
        public int Id { get; set; }
        public Dictionary<char, Instruction> Instructions { get; set; }
    }
}
