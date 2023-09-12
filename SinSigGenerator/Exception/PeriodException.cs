namespace SinSigGenerator.Exception
{
    [Serializable]
    public class PeriodException : System.Exception
    {
        public PeriodException() { }

        public PeriodException(string message)
            : base(message)
        { }

        public PeriodException(string message, System.Exception innerException)
            : base(message, innerException)
        { }


    }
}