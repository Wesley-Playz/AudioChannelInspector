# AudioChannelInspector

A program that looks at an audio file, tells you how many channels it has, and what order the channels are in.

&nbsp;

If you want to build v1, v2, or v2-python yourself I would recommend editing the files in Visual Studio 2022 then running CMD in the project folder (the one with the sln file) and running this command: `dotnet publish -r win-x64 --self-contained -p:PublishSingleFile=true -c Release`.

&nbsp;

NOTE: You WILL NEED the [NAudio](https://www.nuget.org/packages/NAudio) NuGet package in order for the program to work.