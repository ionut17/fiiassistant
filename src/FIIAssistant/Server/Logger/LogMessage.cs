using System;

namespace Server.Logger
{
    public class LogMessage
    {
        public LogMessage(Guid id, string message, string source, string method)
        {
            Id = id;
            Message = message;
            Source = source;
            Method = method;
        }

        public string Timestamp { get; set; }
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Method { get; set; }

        public override string ToString()
        {
            return string.Format("Message: {0}, Source: {1}, Method: {2}.", Message, Source, Method);
        }
    }
}