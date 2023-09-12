namespace SinSigGenerator.Exception
{
    [Serializable]
    public class FreqSigException : System.Exception
    {
        public FreqSigException() { }

        public FreqSigException(string message)
            : base(message)
        { }

        public FreqSigException(string message, System.Exception innerException)
            : base(message, innerException)
        { }


    }
}