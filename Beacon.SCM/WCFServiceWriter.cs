using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Beacon.SCM
{
    public class WCFServiceWriter : IServiceWriter
    {
        public WCFServiceWriter(IBeaconSCMConfiguration configuration,
                                IServiceStringGenerator serviceStringGenerator)
        {
            Configuration = configuration;
            ServiceStringGenerator = serviceStringGenerator;
        }

        private IBeaconSCMConfiguration Configuration { get; set; }
        private IServiceStringGenerator ServiceStringGenerator { get; set; }

        #region IServiceWriter Members

        public string ServiceFileElement { get; set; }

        public void WriteServices(Dictionary<string, string> serviceClasses)
        {
            string[] serviceFileElements = ServiceFileElement.Split(';');
            var elementStack = new Stack<string>(serviceFileElements);
            elementStack.Reverse();

            foreach (string serviceFileLocation in Configuration.ServiceFileLocations)
            {
                WriteToServiceFile(new Stack<string>(elementStack), serviceFileLocation, serviceClasses);
            }
        }

        #endregion

        private void WriteToServiceFile(Stack<string> stack, string serviceFileLocation,
                                        Dictionary<string, string> serviceClasses)
        {
            var document = new XmlDocument();
            document.Load(serviceFileLocation);
            XmlNode rootNode = document.DocumentElement;

            XmlNode node = RecurseNode(stack, rootNode);
            node.InnerText = String.Empty;
            node.InnerXml = String.Empty;

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
    
            foreach (KeyValuePair<string, string> serviceClass in serviceClasses)
            {
//                String serviceClassName = serviceClass.Substring(serviceClass.LastIndexOf('.') + 1);
//                String serviceNamespaceName = serviceClass.Substring(0,
//                                                                     serviceClass.Length - serviceClassName.Length - 1);

                String serviceString = ServiceStringGenerator.GetServiceString(serviceClass.Key, serviceClass.Value);
                stringBuilder.AppendLine(serviceString);
            }

            node.InnerXml = stringBuilder.ToString();
            document.Save(serviceFileLocation);
        }

        private static XmlNode RecurseNode(Stack<string> stack, XmlNode node)
        {
            if (stack.Count != 0)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Name.Equals(stack.Peek()))
                    {
                        if (stack.Count == 1)
                        {
                            return childNode;
                        }
                        stack.Pop();
                        return RecurseNode(stack, childNode);
                    }
                }
            }
            else
            {
                return node;
            }
            return null;
        }
    }
}