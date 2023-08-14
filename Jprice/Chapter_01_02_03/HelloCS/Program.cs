#region Arguments
    // WriteLine($"There are {args.Length} arguments");
// foreach (var arg in args)
// {
//     WriteLine(arg);
// }


// if(args.Length < 3)
// {
//     WriteLine("You must specify two colors and a cursor size");
//     return;
// }

// ForegroundColor = (ConsoleColor)Enum.Parse(
//     enumType: typeof(ConsoleColor),
//     value: args[0],
//     ignoreCase: true); // -> Case insensitive


// BackgroundColor = (ConsoleColor)Enum.Parse(
//     enumType: typeof(ConsoleColor),
//     value: args[1],
//     ignoreCase: true);

// try
// {
//     CursorSize = int.Parse(args[2]); // -> Only supported on windows
// }
// catch (PlatformNotSupportedException)
// {
//     WriteLine("Not supported on this platform");
// }
#endregion

#region ReadKey
// Write("Press any key combination: ");
// ConsoleKeyInfo key = ReadKey();
// WriteLine();
// WriteLine("Key: {0}, Char: {1}, Modifiers: {2}",
//     arg0: key.Key,
//     arg1: key.KeyChar,
//     arg2: key.Modifiers); 
#endregion

#region Async
// HttpClient client = new();
// HttpResponseMessage res = 
//     await client.GetAsync("http://apple.com/");
// Console.WriteLine($"Apple home page has {res.Content.Headers.ContentLength} bytes");
#endregion
