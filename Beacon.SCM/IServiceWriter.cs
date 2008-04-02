using System.Collections.Generic;

namespace Beacon.SCM
{
    public interface IServiceWriter
    {
        string ServiceFileElement { get; set; }
        void WriteServices(Dictionary<string, string> serviceClasses);
    }
}
