using System;

namespace YuriyGuts.Midichlorian.VSPackage
{
    static class PackageGuids
    {
        public const string PackageGuidString = "e2e1b11d-6fcc-47ef-bb62-282315b08784";
        public const string PackageCmdSetGuidString = "b95aacc5-de46-4a59-a517-65ff33188e56";
        public const string PackageOptionsGuidString = "8095e696-d878-418f-af5a-ac086b14dec4";

        public static readonly Guid PackageCmdSetGuid = new Guid(PackageCmdSetGuidString);
    };
}