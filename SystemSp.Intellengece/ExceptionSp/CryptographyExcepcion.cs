using System;
using System.Collections.Generic;
using System.Text;

namespace SystemSp.Intellengece.ExceptionSp
{
    [Serializable]
    public class CryptographyExcepcion : Exception
    {
        public CryptographyExcepcion(string message, Exception inner) 
            : base(message, inner) 
        {
        }
        public CryptographyExcepcion(string message)
            : base(message)
        {
        }
    }
}
