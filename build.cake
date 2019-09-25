#tool "nuget:?package=GitVersion.CommandLine"

#addin nuget:?package=Newtonsoft.Json

using Newtonsoft.Json;

var target = Argument("target", "Default");

var configuration = Argument("configuration", "Release");

var artifactsDirectory = MakeAbsolute(Directory("./artifacts"));

Setup(context =>
{
    CleanDirectory(artifactsDirectory);
});

Task("Build")
.Does(() =>
{
    foreach(var project in GetFiles("./DMTools/DMTools/*.csproj"))
    {
        DotNetCoreBuild(
            project.GetDirectory().FullPath, 
            new DotNetCoreBuildSettings()
            {
                Configuration = configuration
            });
    }
});

Task("Test")
.IsDependentOn("Build")
.Does(() =>
{
    foreach(var project in GetFiles("./DMTools/DMTools.Test/*.csproj"))
    {
        DotNetCoreTest(
            project.GetDirectory().FullPath,
            new DotNetCoreTestSettings()
            {
                Configuration = configuration
            });
    }
});

Task("Create-Nuget-Package")
.IsDependentOn("Test")
.WithCriteria(ShouldRunRelease())
.Does(() =>
{
    var version = GetPackageVersion();
    var url = GetProjectUrl();
    foreach (var project in GetFiles("./DMTools/DMTools/*.csproj"))
    {      
        DotNetCorePack(
            project.GetDirectory().FullPath,
            new DotNetCorePackSettings()
            {               
                Configuration = configuration,
                OutputDirectory = artifactsDirectory,
                ArgumentCustomization = args => args.Append($"/p:Version={version}")                                               
                                                .Append($"/p:ProjectUrl={url}")
                                                 .Append($"/p:Description={url}")
            });
    }
});

Task("Push-Nuget-Package")
.IsDependentOn("Create-Nuget-Package")
.WithCriteria(ShouldRunRelease())
.Does(() =>
{
    var apiKey = EnvironmentVariable("NUGET_API_KEY");
    foreach (var package in GetFiles($"{artifactsDirectory}/*.nupkg"))
    {
        NuGetPush(package, 
            new NuGetPushSettings {
                Source = "https://www.nuget.org/api/v2/package",
                ApiKey = apiKey
            });
    }
});

Task("Default")
    .IsDependentOn("Push-Nuget-Package");

RunTarget(target);

private bool ShouldRunRelease() => AppVeyor.IsRunningOnAppVeyor && AppVeyor.Environment.Repository.Tag.IsTag;

private string GetPackageVersion()
{
    var gitVersion = GitVersion(new GitVersionSettings {
        RepositoryPath = "."
    });

    Information($"Git Semantic Version: {JsonConvert.SerializeObject(gitVersion)}");
    return gitVersion.NuGetVersionV2;
}

private string GetProjectUrl()
{
    return "https://github.com/JDouglasMendes/DMTools";
}

private string Description()
{
    return "General tools for developers";
}