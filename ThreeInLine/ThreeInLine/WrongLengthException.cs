using System;

namespace ThreeInLine
{
    public class WrongLengthException : Exception
    {
        public WrongLengthException ( string exceptionText ) : base ( exceptionText )
        {

        }
    }
}