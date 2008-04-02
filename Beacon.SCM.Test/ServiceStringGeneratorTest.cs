using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beacon.SCM.Test
{
    /// <summary>
    /// Summary description for ServiceStringGeneratorTest
    /// </summary>
    [TestClass]
    public class ServiceStringGeneratorTest
    {
        private readonly IServiceStringGenerator _serviceStringGenerator = CastleWindsorFrameworkHelper.New<IServiceStringGenerator>();

        [TestMethod]
        public void ServiceStringGenerator_Initialise_IsNotNull()
        {
            Assert.IsNotNull(_serviceStringGenerator, Result.FAILED_TO_INITIALISE);
        }

        [TestMethod]
        public void GetServiceString_WithValidNamespaceAndEntityname_ReturnsCorrectValue()
        {
            string serviceString = _serviceStringGenerator.GetServiceString("entityName", "namespaceName");
            Assert.AreEqual("<service entity=\"namespaceName.entityName, namespaceName\" contract=\"namespaceName.entityName, namespaceName\" />", serviceString, "Failed to create correct service string.");
        }
    }
}
