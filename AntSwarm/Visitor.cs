namespace AntSwarm;

public abstract class Visitor
{
    public int LengthAllPath { get; set; } = 0;

    public List<string> FullPath = new List<string>();
    public abstract string Visit(Dictionary<string, Path> dict);
}
