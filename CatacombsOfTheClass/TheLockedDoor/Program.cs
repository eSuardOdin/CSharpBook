
Door door = new Door();
bool running = true;
while (running == true)
{
    string action = "";
    Console.WriteLine($"What do you want to do with the door ? (now {door.Status})");
    Console.WriteLine("\t- change : Change the passcode");
    Console.WriteLine("\t- open : Open the door");
    Console.WriteLine("\t- close : Close the door");
    Console.WriteLine("\t- lock : Lock the door");
    Console.WriteLine("\t- unlock : Unlock the door");
    Console.WriteLine("\t- quit : Quit program");
    Console.Write("Action : ");
    action = Console.ReadLine();

    switch (action)
    {
        case "change":
            door.ChangePassCode();
            break;
        case "open":
            if(door.Open()) Console.WriteLine("Door " + door.Status);
            else Console.WriteLine("Door must be unlocked (closed)");
            break;
        case "close":
            if(door.Close()) Console.WriteLine("Door " + door.Status);
            else Console.WriteLine("Door must be open to be closed");
            break;
        case "lock":
            if(door.Lock()) Console.WriteLine("Door " + door.Status);
            else Console.WriteLine("Door must be closed");
            break;
        case "unlock":
            if(door.Unlock(Helper.AskPasscode("Enter the passcode -> "))) Console.WriteLine("Door " + door.Status);
            else Console.WriteLine("Error in unlocking");
            break;
        case "quit":
            running = false;
            break;
        default:
            Console.WriteLine("Wrong input !");
            break;
    }

}


public class Door {
    private string _passcode;
    public Status Status {get; private set;}


    public Door(){
        Status = Status.Locked;
        _passcode = Helper.AskPasscode("Please enter the new passcode (In a 4 digits format : \"1234\" )-> ");
    }

    public void ChangePassCode() {
        int triesLeft = 3;
        while(true) {
            if (triesLeft == 0) {
                Console.WriteLine("Error, passcode unchanged");
                return;
            }
            if (Helper.AskPasscode($"Enter the old password (Try left : {triesLeft}) -> ") != _passcode) triesLeft --;
            else break;
        }
        string newPasscode = Helper.AskPasscode("Please enter the new passcode (In a 4 digits format : \"1234\" )-> ");
        triesLeft = 3;
        while(true) {
            if (triesLeft == 0) {
                Console.WriteLine("Error, passcode unchanged");
                return;
            }
            if (Helper.AskPasscode($"Confirm new passcode (Try left : {triesLeft}) -> ") != newPasscode) triesLeft --;
            else {
                _passcode = newPasscode;
                break;
            }
        }
    }

    public bool Close() {
        if(Status == Status.Open) {
            Status = Status.Closed;
            return true;
        }
        return false;
    }
    public bool Open() {
        if(Status == Status.Closed) {
            Status = Status.Open;
            return true;
        }
        return false;
    }
    public bool Lock() {
        if(Status == Status.Closed) {
            Status = Status.Locked;
            return true;
        }
        return false;
    }
    public bool Unlock(string pass) {
        if(Status == Status.Locked && pass == _passcode) {
            Status = Status.Closed;
            return true;
        }
        return false;
    }
}


static public class Helper {
    public static string AskPasscode(string prompt){
        string res = "";
        while(!CheckPass(res)) {
            Console.Write(prompt);
            res = Console.ReadLine(); 
        }
        return res;
    }

    public static bool CheckPass(string pass) {
        if(pass.Length != 4) return false;
        return int.TryParse(pass, out int _);
    }
}
public enum Status {Open, Closed, Locked}
