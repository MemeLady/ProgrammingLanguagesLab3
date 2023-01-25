using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Token
    {
        public string Data { get; set; } = "Token message";
        public int Recipient { get; set; }
        public int TimeOfLife { get; set; }
    }
}
