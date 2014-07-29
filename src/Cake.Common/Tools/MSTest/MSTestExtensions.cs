﻿using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Common.Tools.MSTest
{
    /// <summary>
    /// Contains functionality related to running MSTest unit tests.
    /// </summary>
    [CakeAliasCategory("MSTest")]
    public static class MSTestExtensions
    {
        /// <summary>
        /// Runs all MSTest unit tests in the assemblies matching the specified pattern.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="pattern">The pattern.</param>
        [CakeMethodAlias]
        public static void MSTest(this ICakeContext context, string pattern)
        {
            var assemblies = context.Globber.GetFiles(pattern);
            MSTest(context, assemblies);
        }

        /// <summary>
        /// Runs all MSTest unit tests in the assemblies matching the specified pattern.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void MSTest(this ICakeContext context, string pattern, MSTestSettings settings)
        {
            var assemblies = context.Globber.GetFiles(pattern);
            MSTest(context, assemblies, settings);
        }

        /// <summary>
        /// Runs all MSTest unit tests in the specified assemblies.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="assemblyPaths">The assembly paths.</param>
        [CakeMethodAlias]
        public static void MSTest(this ICakeContext context, IEnumerable<FilePath> assemblyPaths)
        {
            MSTest(context, assemblyPaths, new MSTestSettings());            
        }

        /// <summary>
        /// Runs all MSTest unit tests in the specified assemblies.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="assemblyPaths">The assembly paths.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        public static void MSTest(this ICakeContext context, IEnumerable<FilePath> assemblyPaths, MSTestSettings settings)
        {
            var runner = new MSTestRunner(context.FileSystem, context.Environment, context.ProcessRunner);
            foreach (var assembly in assemblyPaths)
            {
                runner.Run(assembly, settings);
            }
        }
    }
}