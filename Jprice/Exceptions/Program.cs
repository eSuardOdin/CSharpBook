// PAGE 169

#region Basic    
// Console.WriteLine("Before parsing");
// Console.Write("How old are you: ");
// string? input = Console.ReadLine();

// try
// {
//     int age = int.Parse(input);
//     Console.WriteLine($"You are {age} years old");
// }

// catch(FormatException)  // If you know the exception type
// {
//     Console.WriteLine("The input you entered is an invalid age format");
// }
// catch (Exception ex)   // If there is another (here, an overflow for instance)
// {
//     Console.WriteLine($"{ex.GetType} says \"{ex.Message}\"");
// }


// Console.WriteLine("After parsing");
#endregion

#region Filters
// Console.Write("Enter an amount: ");
// string? amount = Console.ReadLine();
// if(string.IsNullOrEmpty(amount)) { return; }

// try
// {
//     decimal value = decimal.Parse(amount,
//         System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands,
//         System.Globalization.CultureInfo.InvariantCulture);
//     Console.WriteLine($"Amount formatted as currency: {value:C}");
// }
// // Filter
// catch (FormatException) when (amount.Contains('$') || amount.Contains('€'))
// {
//     Console.WriteLine("Don't add a dollar or euro sign!");
// }

// catch (FormatException)
// {
//     Console.WriteLine("The input you entered is an invalid amount format");
// }

// catch (Exception ex)   // If there is another (here, an overflow for instance)
// {
//     Console.WriteLine($"{ex.GetType} says \"{ex.Message}\"");
// }
#endregion

#region Overflow
// In order to notify an overflow instead of letting it silent

// Classic behavior :
Console.WriteLine("Classic behavior");
int x = int.MaxValue - 1;
Console.WriteLine($"Initial value: {x}");
x++;
Console.WriteLine($"After incrementing: {x}");
x++;
Console.WriteLine($"After incrementing: {x}");
x++;
Console.WriteLine($"After incrementing: {x}");
Console.WriteLine("");

// Checked behavior
checked
{
    Console.WriteLine("Checked behavior");
    int y = int.MaxValue - 1;
    Console.WriteLine($"Initial value: {y}");
    y++;
    Console.WriteLine($"After incrementing: {y}");
    y++;
    Console.WriteLine($"After incrementing: {y}");
    y++;
    Console.WriteLine($"After incrementing: {y}");
}
#endregion