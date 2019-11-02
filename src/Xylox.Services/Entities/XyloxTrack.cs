using System;

namespace Xylox.Services.Entities
{
    public class XyloxTrack
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
