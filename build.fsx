// include Fake lib
#I "tools/FAKE/tools"
#r @"FakeLib.dll"

open Fake

// Default target
Target "Default" (fun _ ->
    trace "Hello World from FAKE"
)

// start build
RunTargetOrDefault "Default"
