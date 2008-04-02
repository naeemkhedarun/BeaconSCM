using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beacon.SCM.Test
{
    /// <summary>
    /// Summary description for BeaconSCMConfigurationTest
    /// </summary>
    [TestClass]
    public class BeaconSCMConfigurationTest
    {
        private readonly IBeaconSCMConfiguration _configuration =
            CastleWindsorFrameworkHelper.New<IBeaconSCMConfiguration>();

        [TestMethod]
        public void BeaconSCMConfigurationTest_Initialise_IsNotNull()
        {
            Assert.IsNotNull(_configuration, Result.FAILED_TO_INITIALISE);
        }

        [TestMethod]
        public void AssemblyLocations_AlreadyInAppConfig_ReturnsCorrectAssemblyLocations()
        {
            Assert.AreEqual(@"C:\Users\Administrator\Documents\Visual Studio 2008\Projects\Beacon.SCM\TestAssembly\bin\Debug\TestAssembly.dll", _configuration.AssemblyLocations[0],
                            Result.FAILED_TO_LOAD);
        }

        [TestMethod]
        public void ServiceFileLocations_AlreadyInAppConfig_ReturnsCorrectServiceFileLocations()
        {
            Assert.AreEqual(@"C:\Users\Administrator\Documents\Visual Studio 2008\Projects\Beacon.SCM\Beacon.SCM.Test\TestConfigurationData/ServiceConfigA.config", _configuration.ServiceFileLocations[0],
                            Result.FAILED_TO_LOAD);
            Assert.AreEqual(@"C:\Users\Administrator\Documents\Visual Studio 2008\Projects\Beacon.SCM\Beacon.SCM.Test\TestConfigurationData/ServiceConfigB.config", _configuration.ServiceFileLocations[1],
                            Result.FAILED_TO_LOAD);
        }

        [TestMethod]
        public void AdditionalServices_AlreadyInAppConfig_ReturnsCorrectAdditionalServicesString()
        {
            Assert.AreEqual("<service crap=\"blah\"></service>", _configuration.AdditionalServices.Trim(),
                            Result.FAILED_TO_LOAD);
        }
    }
}