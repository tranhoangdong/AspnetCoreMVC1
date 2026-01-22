using System;
using System.Reflection;
using System.Runtime.Loader;

public class CustomAssemblyLoadContext : AssemblyLoadContext
{
    public IntPtr LoadUnmanagedLibrary(string absolutePath)
        => LoadUnmanagedDllFromPath(absolutePath);

    protected override Assembly Load(AssemblyName assemblyName) => null;
}
