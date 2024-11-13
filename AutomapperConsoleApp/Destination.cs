namespace AutomapperConsoleApp;

public class Destination
{
    public int Age { get; set; }
    public string Name { get; set; }
    public DateTime BirthDay { get; set; }

    public override string ToString()
    {
        return $"{Name}ning yoshi {Age} da, u {BirthDay} kuni tug'ilgan.";
    }
}