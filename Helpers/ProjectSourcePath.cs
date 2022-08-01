using System.Runtime.CompilerServices;
using System;

namespace Backend.Helpers
{
    internal static class ProjectSourcePath
    {
        private const string myRelativePath = "Helpers\\" + nameof(ProjectSourcePath) + ".cs";
        private static string lazyValue;
        public static string Value => lazyValue ?? calculatePath();

        private static string calculatePath()
        {
            string pathName = GetSourceFilePathName();
            if (pathName.EndsWith(myRelativePath, StringComparison.Ordinal))
                return pathName.Substring(0, pathName.Length - myRelativePath.Length);
            else
                return null;
        }

        public static string GetSourceFilePathName([CallerFilePath] string callerFilePath = null) //
            => callerFilePath ?? "";
    }
}
