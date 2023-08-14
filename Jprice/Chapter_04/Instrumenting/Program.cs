using System.Diagnostics;
string logPath = "./log.txt";

Console.WriteLine($"Writing to: {logPath}");

TextWriterTraceListener logFile = new(File.CreateText(logPath));

Trace.Listeners.Add(logFile);

Trace.AutoFlush = true; // Does not wait to the buffer to be full before writing
Debug.WriteLine("Debug says : Watching"); // dotnet run --configuration Debug
Trace.WriteLine("Trace says : Watching"); // dotnet run --configuration Debug + Release
