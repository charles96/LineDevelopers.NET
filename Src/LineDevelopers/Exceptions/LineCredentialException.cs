namespace Line
{
    public class LineCredentialException : Exception
    {
        public LineCredentialException(string message, string detail) : base(message)
        { 
            this.Detail = detail;
        }

        public string Detail { get; set; }
    }
}
