using System;

namespace Beacon.SCM
{
    public class ServiceStringGenerator : IServiceStringGenerator
    {
        public ServiceStringGenerator(string serviceStringFormat)
        {
            ServiceStringFormat = serviceStringFormat;
        }

        private string ServiceStringFormat { get; set; }

        #region IServiceStringGenerator Members

        public string GetServiceString(string fullname, string namespaceName)
        {
            return String.Format(ServiceStringFormat, fullname, namespaceName);
        }

        #endregion
    }
}