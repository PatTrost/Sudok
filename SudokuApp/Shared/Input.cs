using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuApp.Shared
{
    public enum InputType{
        Value,
        Possible,
        Notation           
    }

    public class InputValue
    {
        public int Value { get; set; }
        public InputType Type { get; set; }
    }
}
