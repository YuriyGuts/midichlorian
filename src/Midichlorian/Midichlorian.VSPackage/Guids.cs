// Guids.cs
// MUST match guids.h
using System;

namespace YuriyGuts.Midichlorian.VSPackage
{
    static class GuidList
    {
        public const string guidMidichlorianPackagePkgString = "e2e1b11d-6fcc-47ef-bb62-282315b08784";
        public const string guidMidichlorianPackageCmdSetString = "b95aacc5-de46-4a59-a517-65ff33188e56";

        public static readonly Guid guidMidichlorian_VSPackageCmdSet = new Guid(guidMidichlorianPackageCmdSetString);
    };
}