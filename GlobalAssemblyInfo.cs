#region Using directives

using System;
using System.Reflection;
using System.Runtime.InteropServices;

#endregion

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
[assembly: AssemblyProduct("MashedVVM (Debug)")]
#else
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyProduct("MashedVVM")]
#endif

[assembly: AssemblyCompany("Michael Seeger")]
[assembly: AssemblyCopyright("2012 © Michael Seeger")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]
 
[assembly: AssemblyVersion("1.0.1.0")]
[assembly: AssemblyFileVersion("1.0.1.0")]