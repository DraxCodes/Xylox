using System;

namespace Xylox.Services.Entities
{
    public class XyloxTrack : IXyloxServiceResult
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public TimeSpan Duration { get; set; }
        public bool IsQueued { get; set; }
        public string Message { get; set; }
    }
}
