
Door door = new Door();

door.ChangePassCode();


public class Door {
    private string _passcode;
    // public string Passcode {get;}
    public Status Status {get;}


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
