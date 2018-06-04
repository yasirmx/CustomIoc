# CustomIoc
Custom IoC Container in .NET

I have been playing around with System.Reflection and ended up developing a tiny IoC container.

How it works:

I use a dictionary to maintain the keypair value of an interface and its corresponding implementation. The method register instance retrieves the type of the values being passed (T, U) and then checks if the key (interface) exists in the dictionary. If the key is present, it means that the interface already has an implementation and will throw an exception, otherwise it will add the interface and its corresponding implementation to the dictionary.

The method GetInstance will check if the key(interface) exists. An exception is thrown if the interface has no corresponding implementation. If the interface (key) is present in the dictionary, the namespace (from the dictionary) is returned and all the assembly names are retrieved via a foreach and finally a match is tried against the namespace and the assembly. 

The found match equals the assembly name and the assembly name is loaded before GetType is called. GetType is executed and Activator is used with the result from GetType and the concrete implementation is resolved and returned.


Steps to use the container:
 - Reference Custom.IoC
 - Reference your .Net libraries
 - Instantiate the container by the following snippet:
    var container = new Container();
 - Register your dependencies via:
    container.Register<interface,implementation>();
 - Call resolve concrete class via:
    var concreteImplementation = container.GetInstance<Iinterface>();

I have put a stopwatch to track the time it takes.

See Program.cs for a working example
