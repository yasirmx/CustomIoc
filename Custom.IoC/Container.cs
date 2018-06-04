namespace Custom.IoC
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class Container
    {
        public Lazy<Dictionary<string,string>>  ContainerDictionary { get; set; }

        public Container()
        {
            ContainerDictionary = new Lazy<Dictionary<string, string>>();
        }

        public  T GetInstance<T>() where T: class
        {
            if(ContainerDictionary.Value.ContainsKey(typeof(T).ToString()))
            {
                string typeName = ContainerDictionary.Value[typeof(T).ToString()];

                var assemblytoBeLoaded = string.Empty;
                foreach(var assemblyName in AppDomain.CurrentDomain.GetAssemblies())
                {
                    if(typeName.Contains(assemblyName.ManifestModule.Name.ToString().Substring(0, assemblyName.ManifestModule.Name.ToString().Length-4)))
                    {
                        assemblytoBeLoaded = assemblyName.ToString();
                        break;
                    }
                }
                
                var loadedAssembly = Assembly.Load(assemblytoBeLoaded);
                Type type = loadedAssembly.GetType(typeName);

                var activatedInstance = Activator.CreateInstance(type);

                T returnType = activatedInstance as T;

                return returnType;
            }
            else
            {
                throw new Exception(string.Format("{0} has not been registered", typeof(T).GetType().ToString()));
            }

        }

        public void Register<T,U>() where T:class
        {
            var origin = typeof(T).ToString();

            var destination = typeof(U).ToString();

            if(ContainerDictionary.Value.ContainsKey(origin))
            {
                throw new Exception(string.Format("{0} has already been registered", origin));
            }
            else
            {
                ContainerDictionary.Value.Add(origin, destination);
            }

        }
    }
}
