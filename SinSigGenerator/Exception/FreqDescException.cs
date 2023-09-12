namespace SinSigGenerator.Exception
{
    [Serializable]
    public class FreqDescException : System.Exception
    {
        public FreqDescException() { }

        public FreqDescException(string message)
            : base(message)
        { }

        public FreqDescException(string message, System.Exception innerException)
            : base(message, innerException)
        { }


    }
}