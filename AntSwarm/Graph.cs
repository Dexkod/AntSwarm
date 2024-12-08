using System.Text;

namespace AntSwarm;

public class Graph
{
    public string NameGraph { get; set; } = null!;

    public Dictionary<string, Path> Paths = new Dictionary<string, Path>();
    public List<Graph> Graphs { get; set; } = new List<Graph>();

    public Visitor Attech(Visitor visitor)
    {
        visitor.FullPath.Add(NameGraph);
        var result = visitor.Visit(Paths);

        if(result != string.Empty)
        {
            var graph = Graphs.First(_ => _.NameGraph == result);
            return graph.Attech(visitor);
        }

        return visitor;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        foreach(var path in Paths.Keys)
        {
            result.Append($"Path: {path} Length: {Paths[path].Length} \t");
        }

        return $"Graph {NameGraph} : \n{result}";
    }
}
