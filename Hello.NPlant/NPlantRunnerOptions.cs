using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using NPlant.Generation;

namespace Hello.NPlant
{
    class NPlantRunnerOptions : INPlantRunnerOptions
    {
        static NPlantRunnerOptions()
        {
            AddGraphViz();
        }

        private static void AddGraphViz()
        {
            var graphVizDot = FindGraphVizDot();
            if (string.IsNullOrEmpty(graphVizDot))
                Trace.TraceWarning("Could not find Graphviz dot.exe.");
            else
                Environment.SetEnvironmentVariable("GRAPHVIZ_DOT", graphVizDot, EnvironmentVariableTarget.Process);
        }

        public string OutputDirectory { get; set; }
        public string AssemblyToScan { get; set; }
        public string Clean { get; set; }
        public string Categorize { get; set; }
        public string JavaPath { get; set; }
        public string PlantUml { get; set; }
        public NPlantCategorizations ParsedCategorized { get; set; }

        public NPlantRunnerOptions(Assembly assembly = null)
        {
            var safeAssembly = assembly ?? typeof (NPlantRunnerOptions).Assembly;
            var assemblyFile = safeAssembly.GetPath();
            AssemblyToScan = assemblyFile;
            OutputDirectory = FindOutputDir();
            JavaPath = FindJava();
            PlantUml = FindPlantUml();
        }

        private static string FindOutputDir()
        {
            //return Path.GetDirectoryName(assemblyFile);
            var solutionDir = Path.Combine(Environment.CurrentDirectory, @"..\..\..");
            var docsImgDir = Path.Combine(solutionDir, @"docs\img");
            return docsImgDir;
        }

        private static string FindJava()
        {
            // find from path
            var javaExePath = Find.File("java.exe").InPath();
            // find from JAVA_HOME
            // -> %JAVA_HOME%\bin\java.exe
            if (string.IsNullOrEmpty(javaExePath))
                javaExePath = Find.File("java.exe").BeneathEnv("JAVA_HOME");
            return javaExePath;
        }

        private static string FindGraphVizDot()
        {
            // find from path
            var dotPath = Find.File("dot.exe").InPath();
            // Find in Program Files
            // cf.: http://plantuml.sourceforge.net/graphvizdot.html
            if (string.IsNullOrEmpty(dotPath))
                dotPath = Find.File("dot.exe").InProgramFilesBeneath("Graphviz*");

            // find from Chocolatey portable (choco install graphviz.portable)
            // cf.: https://chocolatey.org/packages/graphviz.portable)
            // -> %ChocolateyInstall%\lib\graphviz.portable.*\tools\release\bin\dot.exe
            if (string.IsNullOrEmpty(dotPath))
                dotPath = Find.File("dot.exe").BeneathEnv("ChocolateyInstall");

            return dotPath;
        }

        private static string FindPlantUml()
        {
            // find from Chocolatey (choco install plantuml)
            // NOTE: you may skip dependency GraphViz installer and use graphviz.portable instead
            // cf.: https://chocolatey.org/packages/plantuml)
            // -> %ChocolateyInstall%\lib\plantuml.*\tools\plantuml.jar
            var plantUmlFile = Find.File("plantuml.jar").BeneathEnv("ChocolateyInstall");
            return plantUmlFile;
        }
    }
}