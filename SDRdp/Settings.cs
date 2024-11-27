using System.Collections.Generic;

namespace SDRdp
{
    public class Settings
    {
        public static Settings Instance = new();
        public List<string> Groups { get; set; } = [];
        public bool IsNRemoteRDPImported { get; set; } = false;
    }
}
