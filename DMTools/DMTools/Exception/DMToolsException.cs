using System;
using System.Collections.Generic;
using System.Text;

namespace DMTools.Exception
{
    public class DMToolsException : System.Exception
    {
        public DMToolsException(string message):base(message)
        {
        }
    }
}
