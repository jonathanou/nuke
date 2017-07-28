// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Utilities;

namespace Nuke.Common.Tools.MSBuild
{
    partial class MSBuildSettings
    {
        [CanBeNull]
        private string GetTargetPlatform ()
        {
            if (TargetPlatform == null)
                return null;

            if (TargetPlatform == MSBuildTargetPlatform.MSIL)
                return TargetPath == null || TargetPath.EndsWith(".sln", StringComparison.OrdinalIgnoreCase)
                    ? "Any CPU".DoubleQuote()
                    : "AnyCPU";

            return TargetPlatform.ToString();
        }

        private string GetToolPath ()
        {
            return MSBuildToolPathResolver.Resolve(MSBuildVersion, MSBuildPlatform);
        }
    }
}
