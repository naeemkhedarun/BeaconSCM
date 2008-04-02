using System;
using System.Collections.Generic;
using System.Reflection;

namespace Beacon.SCM
{
    public class BeaconAssemblyReader : IAssemblyReader
    {
        public BeaconAssemblyReader(IBeaconSCMConfiguration configuration)
        {
            Configuration = configuration;
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += CurrentDomain_OnReflectionOnlyAssemblyResolve;
        }

        private IBeaconSCMConfiguration Configuration { get; set; }

        public string BaseClassName { get; set; }
        public string NamespaceName { get; set; }

        #region IAssemblyReader Members

        public Dictionary<string, string> GetClassesDerivedFrom()
        {
            return GetClassesDerivedFrom(BaseClassName, NamespaceName);
        }

        public Dictionary<string, string> GetClassesDecoratedWith(string attributeName)
        {
            Dictionary<string, string> derivedClasses = new Dictionary<string, string>();

            foreach (string assemblyLocation in Configuration.AssemblyLocations)
            {
                Assembly assembly = Assembly.ReflectionOnlyLoadFrom(assemblyLocation);

                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    MemberInfo memberInfo = type;
                    IList<CustomAttributeData> attributes = CustomAttributeData.GetCustomAttributes(memberInfo);
                    foreach (CustomAttributeData data in attributes)
                    {
                        string name = GetAttributeName(data);

                        if (name.Equals(attributeName))
                        {
                            derivedClasses.Add(type.Name, GetNamespaceName(type));
                        }
                    }
                }
            }

            return derivedClasses;
        }

        public Dictionary<string, string> GetClassesDecoratedWith()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetClassesDerivedFrom(string baseClassName)
        {
            return GetClassesDerivedFrom(baseClassName, String.Empty);
        }

        public Dictionary<string, string> GetClassesDerivedFrom(string baseClassName, string namespaceName)
        {
            Dictionary<string, string> derivedClasses = new Dictionary<string, string>();

            foreach (string assemblyLocation in Configuration.AssemblyLocations)
            {
                Assembly assembly = Assembly.ReflectionOnlyLoadFrom(assemblyLocation);

                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    if (type.BaseType != null)
                    {
                        if (String.IsNullOrEmpty(namespaceName))
                        {
                            if (type.BaseType.Name.Equals(baseClassName))
                                derivedClasses.Add(type.Name, GetNamespaceName(type));
                        }
                        else
                        {
                            String fullName = String.Format("{0}.{1}", namespaceName, baseClassName);
                            if (!String.IsNullOrEmpty(type.BaseType.FullName) && type.BaseType.FullName.Equals(fullName))
                                derivedClasses.Add(type.Name, GetNamespaceName(type));
                        }
                    }
                }
            }

            return derivedClasses;
        }

        #endregion

        private static string GetNamespaceName(Type type)
        {
            return type.Assembly.ToString().Split(',')[0];
        }

        private static string GetAttributeName(CustomAttributeData data)
        {
            String sub = data.ToString().Substring(0, data.ToString().IndexOf("("));
            return sub.Substring(sub.LastIndexOf(".") + 1);
        }

        private static Assembly CurrentDomain_OnReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            return Assembly.ReflectionOnlyLoad(args.Name);
        }
    }
}