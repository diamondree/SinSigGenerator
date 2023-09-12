namespace SinSigGenerator.Exception
{
    [Serializable]
    public class AmplitudeException : System.Exception
    {
        public AmplitudeException() { }

        public AmplitudeException(string message) 
            : base(message) 
        { }

        public AmplitudeException(string message, System.Exception innerException) 
            : base (message, innerException) 
        { }


    }
}