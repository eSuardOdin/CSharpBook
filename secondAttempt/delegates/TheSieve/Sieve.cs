public class Sieve 
{
    private Predicate<int> Checker { get; set; }
    public Sieve(Predicate<int> deleg)
    {
        this.Checker = deleg;
    }

    public bool IsGood(int number)
    {
        return Checker(number);
    }

}
