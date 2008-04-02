using System.Collections.Generic;

namespace Beacon.SCM
{
    public interface IAssemblyReader
    {
        /// <summary>
        /// Returns fully qualified class name which derieves from baseClassName.
        /// </summary>
        /// <param name="baseClassName"></param>
        /// <returns></returns>
        Dictionary<string, string> GetClassesDerivedFrom(string baseClassName);

        Dictionary<string, string> GetClassesDerivedFrom(string baseClassName, string namespaceName);
        Dictionary<string,string> GetClassesDerivedFrom();
        Dictionary<string,string> GetClassesDecoratedWith(string attributeName);
        Dictionary<string,string> GetClassesDecoratedWith();
    }
} 