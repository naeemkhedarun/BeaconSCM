namespace Beacon.SCM
{
    public interface IServiceStringGenerator
    {
        string GetServiceString(string fullname, string namespaceName);
    }
}