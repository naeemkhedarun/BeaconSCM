using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beacon.SCM.Test
{
    /// <summary>
    /// Summary description for BeaconAssemblyReaderTest
    /// </summary>
    [TestClass]
    public class BeaconAssemblyReaderTest
    {
        private readonly IAssemblyReader _assemblyReader = CastleWindsorFrameworkHelper.New<IAssemblyReader>();

        [TestMethod]
        public void BeaconAssemblyReader_Initialise_IsNotNull()
        {
            Assert.IsNotNull(_assemblyReader, Result.FAILED_TO_INITIALISE);
        }

        [TestMethod]
        public void GetClassesDerivedFrom_WithValidAssemblyLocations_ReturnsCorrectTypeFullNames()
        {
//            string[] derivedFrom = _assemblyReader.GetClassesDerivedFrom();
//            Assert.AreEqual("TestAssembly.TestClassOne", derivedFrom[0], Result.FAILED_TO_RETURN_CORRECT_VALUE);
//            Assert.AreEqual("TestAssembly.TestClassTwo", derivedFrom[1], Result.FAILED_TO_RETURN_CORRECT_VALUE);
        }

        [TestMethod]
        public void GetClassesDerivedFrom_WithValidAssemblyLocationsAndValidNamespace_ReturnsCorrectTypeFullNames()
        {
//            string[] derivedFrom = _assemblyReader.GetClassesDerivedFrom();
//            Assert.AreEqual("TestAssembly.TestClassOne", derivedFrom[0], Result.FAILED_TO_RETURN_CORRECT_VALUE);
//            Assert.AreEqual("TestAssembly.TestClassTwo", derivedFrom[1], Result.FAILED_TO_RETURN_CORRECT_VALUE);
        }
    }
}
