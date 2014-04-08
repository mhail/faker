#!/bin/sh

SCRIPTPATH=$(dirname "$0")
#echo $SCRIPTPATH

mono "$SCRIPTPATH/tools/nuget.exe" install "FAKE" -Version "2.13.1" -NonInteractive -OutputDirectory "$SCRIPTPATH/tools" -ExcludeVersion
mono "$SCRIPTPATH/tools/FAKE/tools/Fake.exe" "$SCRIPTPATH/build.fsx"
