// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;

[assembly: AssemblyTitle         (AssemblyVersionNumber.TitleMedicalRulesAddin)]
[assembly: AssemblyDescription   (AssemblyVersionNumber.DescriptionMedicalRulesAddin)]
[assembly: AssemblyConfiguration (AssemblyVersionNumber.Configuration)]
[assembly: AssemblyCompany       (AssemblyVersionNumber.CompanyName)]
[assembly: AssemblyProduct       (AssemblyVersionNumber.Product)]
[assembly: AssemblyCopyright     (AssemblyVersionNumber.Copyright)]
[assembly: AssemblyTrademark     (AssemblyVersionNumber.Trademark)]
[assembly: AssemblyCulture       (AssemblyVersionNumber.Culture)]

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("3BEA8E88-33F2-42f0-BB52-CB041D85751A")]

[assembly: AssemblyVersion                (AssemblyVersionNumber.Version)]
[assembly: AssemblyInformationalVersion   (AssemblyVersionNumber.Version)]
[assembly: AssemblyFileVersion            (AssemblyVersionNumber.FileVersionMedicalRulesAddin)]

[assembly: CLSCompliant(true)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, UnmanagedCode = true)]

// ************ Obfuscation stuff begin
[assembly: ObfuscateAssembly(false)]

// This is used by the obfuscation detector helper used by Tech support to
// figure out if this assembly is obfuscated or not
namespace Leadtools.Medical.Rules.AddIn
{
    [Obfuscation(Exclude = true)]
    class LeadtoolsObfuscationClass
    {
    }
}
// ************ Obfuscation stuff end
