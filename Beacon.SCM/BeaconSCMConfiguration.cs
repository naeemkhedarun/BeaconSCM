namespace Beacon.SCM
{
    public class BeaconSCMConfiguration : IBeaconSCMConfiguration
    {
        #region IBeaconSCMConfiguration Members

        /// <summary>
        /// Returns the set of assembly locations to read entities from.
        /// </summary>
        public string[] AssemblyLocations { get; set; }

        /// <summary>
        /// Returns the locations of the service files we wish to write
        /// the service strings for.
        /// </summary>
        public string[] ServiceFileLocations { get; set; }

        /// <summary>
        /// Returns any custom / additionals services we have manually specified
        /// and wish to be written to the service files.
        /// </summary>
        public string AdditionalServices { get; set; }

        #endregion
    }
}