using System.Diagnostics;
using Microsoft.Extensions.Configuration;

#region Base    
string logPath = "./log.txt";

Console.WriteLine($"Writing to: {logPath}");

TextWriterTraceListener logFile = new(File.CreateText(logPath));

Trace.Listeners.Add(logFile);

Trace.AutoFlush = true; // Does not wait to the buffer to be full before writing
Debug.WriteLine("Debug says : OK BOY"); // dotnet run --configuration Debug
Trace.WriteLine("Trace says : Watching"); // dotnet run --configuration Debug + Release
#endregion

// int unitsInStock = 12;
// LogSourceDetails(unitsInStock > 10);


Console.WriteLine("Reading from appsettings.json in {0}",
    arg0: Directory.GetCurrentDirectory());
ConfigurationBuilder builder = new();

builder.SetBasePath(Directory.GetCurrentDirectory());

builder.AddJsonFile("appsettings.json",
 optional: true, reloadOnChange: true);
IConfigurationRoot configuration = builder.Build();

TraceSwitch ts = new(
    displayName: "PacktSwitch",
    description: "This switch is set via a JSON config."); 

configuration.GetSection("PacktSwitch").Bind(ts);
Trace.WriteLineIf(ts.TraceError, "Trace error");
Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
Trace.WriteLineIf(ts.TraceInfo, "Trace information");
Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");
Console.ReadLine();