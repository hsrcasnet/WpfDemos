﻿using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows;

[assembly: AssemblyTitle("WpfMultilingual")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("WpfMultilingual")]
[assembly: AssemblyCopyright("Copyright © 2021")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
    //(used if a resource is not found in the page,
    // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
    //(used if a resource is not found in the page,
    // app, or any theme specific resource dictionaries)
)]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]


// DEMO:
// This is a workaround to have the default Resources.resx file in a neutral language ("developer english").
// Language "sv" is Swedish. Select a language as neutral language which you will never have as a display language.
[assembly: NeutralResourcesLanguage("sv")]