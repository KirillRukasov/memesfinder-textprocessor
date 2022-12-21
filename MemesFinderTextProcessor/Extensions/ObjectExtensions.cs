using System;
using Newtonsoft.Json;

namespace MemesFinderTextProcessor.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object update) => update is null ? default : JsonConvert.SerializeObject(update);
    }
}
