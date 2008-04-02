using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beacon.SCM.Test
{
    /// <summary>
    /// Summary description for WCFServiceWriterTest
    /// </summary>
    [TestClass]
    public class WCFServiceWriterTest
    {
        private readonly IServiceWriter _serviceWriter = CastleWindsorFrameworkHelper.New<IServiceWriter>();

        [TestMethod]
        public void WCFServiceWriter_Initialise_IsNotNull()
        {
            Assert.IsNotNull(_serviceWriter, Result.FAILED_TO_INITIALISE);
        }

        [TestMethod]
        public void WriteServices_WithValidServiceFilesAndValidServiceElement_CreatesCorrectServiceFile()
        {
            IBeaconSCMConfiguration configuration = CastleWindsorFrameworkHelper.New<IBeaconSCMConfiguration>();
            IAssemblyReader assemblyReader = CastleWindsorFrameworkHelper.New<IAssemblyReader>();
            _serviceWriter.WriteServices(assemblyReader.GetClassesDerivedFrom("TestBase"));

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(configuration.ServiceFileLocations[0]);

            XmlNode node = xmlDocument.DocumentElement;

            int count = node.ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes.Count;

            Assert.AreEqual(2, count, "Should have inserted definitions for two services.");
        }
    }
}