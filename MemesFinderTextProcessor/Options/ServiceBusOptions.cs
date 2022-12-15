using System;
namespace MemesFinderTextProcessor.Options
{
    public class ServiceBusOptions
    {
        public string FullyQualifiedNamespace { get; set; }
        public string KeywordMessagesTopic { get; set; }
    }
}

