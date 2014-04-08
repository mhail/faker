// include Fake lib
#I "tools/FAKE/tools"
#r @"FakeLib.dll"

open Fake

RestorePackages()

// Properties
let buildDir = "./build/"
let testDir  = "./test/"

// Targets
Target "Clean" (fun _ ->
    CleanDir buildDir
)

Target "BuildApp" (fun _ ->
   !! "src/app/**/*.csproj"
     |> MSBuildRelease buildDir "Build"
     |> Log "AppBuild-Output: "
)

Target "BuildTest" (fun _ ->
    !! "src/test/**/*.csproj"
      |> MSBuildDebug testDir "Build"
      |> Log "TestBuild-Output: "
)

//Target "RestoreNUnit" (fun _ ->
//  RestorePackageId (fun p ->
//   {p with
//      OutputPath = "./tools/Nunit"
//      ExcludeVersion = true
//   }
//  ) "NUnit.Runners"
//)

Target "Test" (fun _ ->
    !! (testDir + "/NUnit.Test.*.dll")
      |> NUnit (fun p ->
          {p with
             DisableShadowCopy = true;
             OutputFile = testDir + "TestResults.xml"

          })
)

Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)

// Dependencies
"Clean"
  ==> "BuildApp"
  ==> "BuildTest"
  ==> "Test"
//    ==> "RestoreNUnit"
  ==> "Default"

// start build
RunTargetOrDefault "Default"
