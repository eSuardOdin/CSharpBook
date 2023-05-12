List<char> charList = new List<char>();
charList.Add('e');
charList.Add('%');
charList.Add('8');
charList.Add('\'');
PasswordValidator pv = new PasswordValidator(5, 12, 3, 1, 1, charList);
pv.PrintPasswordSpec();

while(true) {
    Console.Write("Enter a password : ");
    string pass = Console.ReadLine();
    (bool status, string error) = pv.CheckPassword(pass);
    if(!status) Console.WriteLine(error);
    else Console.WriteLine($"Password \"{pass}\" is valid");
}


// Rajouter un validateur de possibilité de création de mdp

public class PasswordValidator {
    public uint MinLen {get;}
    public uint MaxLen {get;}
    public uint UpperCaseMinChar {get;}
    public uint LowerCaseMinChar {get;}
    public uint NumberMinChar {get;}
    public List<char> ForbiddenChar {get;}

    public PasswordValidator(uint minlen, uint maxlen, uint upper, uint lower, uint number, List<char> forbiddenChar) {
        MinLen = minlen;
        MaxLen = maxlen;
        UpperCaseMinChar = upper;
        LowerCaseMinChar = lower;
        NumberMinChar = number;
        ForbiddenChar = forbiddenChar;
    }

    public (bool, string) CheckPassword(string pass) {
        uint upper, lower, number;
        upper = lower = number = 0;
        // Check for length 
        if(pass.Length > MaxLen) {
            return (false, "Password is too long");
        } else if (pass.Length < MinLen) {
            return (false, "Password is too short");
        }
        // Check for forbidden
        foreach (char c in pass)
        {
            if(char.IsDigit(c)) number++;
            else if (char.IsUpper(c)) upper++;
            else if (char.IsLower(c)) lower++;

            if(ForbiddenChar.Contains(c)) return (false, $"Password should not contain \"{c}\"");
        }
        if(upper < UpperCaseMinChar) return (false, "Not enough uppercase chars");
        else if(lower < LowerCaseMinChar) return (false, "Not enough lowercase chars");
        else if(number < NumberMinChar) return (false, "Not enough digit chars");

        return(true,"");
    }

    public void PrintPasswordSpec() {
        Console.WriteLine($"- Password length : {MinLen}-{MaxLen}");
        Console.WriteLine("- Character type needed : ");
        Console.WriteLine($"\t. Uppercase : {UpperCaseMinChar}");
        Console.WriteLine($"\t. Lowercase : {LowerCaseMinChar}");
        Console.WriteLine($"\t. Number    : {NumberMinChar}");
        if(ForbiddenChar.Count() != 0) {
            Console.WriteLine("- Banned characters :\n[");
            foreach (char c in ForbiddenChar)
            {
                Console.WriteLine($"\t\"{c}\"");
            }
            Console.WriteLine("]");
        }
    }
}