namespace Beacon.SCM
{
    public class RunBeaconSCM
    {
        public static void Main(string[] args)
        {
            IAssemblyReader assemblyReader = CastleWindsorFrameworkHelper.New<IAssemblyReader>();
            IServiceWriter serviceWriter = CastleWindsorFrameworkHelper.New<IServiceWriter>();

            serviceWriter.WriteServices(assemblyReader.GetClassesDecoratedWith("DataContractAttribute"));
        }
    }
}