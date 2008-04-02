namespace Beacon.SCM
{
    /// <summary>
    /// Interface encapsulating initial configuration for the application.
    /// </summary>
    public interface IBeaconSCMConfiguration
    {
        /// <summary>
        /// Returns the set of assembly locations to read entities from.
        /// </summary>
        string[] AssemblyLocations { get; set; }

        /// <summary>
        /// Returns the locations of the service files we wish to write
        /// the service strings for.
        /// </summary>
        string[] ServiceFileLocations { get; set; }

        /// <summary>
        /// Returns any custom / additionals services we have manually specified
        /// and wish to be written to the service files.
        /// </summary>
        string AdditionalServices { get; set; }
    }
}