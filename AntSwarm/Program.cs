using AntSwarm;

List<Graph> graphs = new List<Graph>();

for(int i = 0; i < 6; i++)
{
    var graph  = new Graph();
    graph.NameGraph = ((char)(i + 'A')).ToString();
    graphs.Add(graph);
}

var random = new Random();

for(int i = 0; i < graphs.Count; i++)
{
    for(int j = 0; j < graphs.Count; j++)
    {
        if (graphs[i] == graphs[j])
        {
            continue;
        }

        graphs[i].Graphs.Add(graphs[j]);

        if (i < j)
        {
            graphs[i].Paths.Add(graphs[j].NameGraph, new AntSwarm.Path()
            {
                F = 0.5,
                Length = random.Next(1, 20)
            });
        }
        else
        {
            graphs[i].Paths.Add(graphs[j].NameGraph, new AntSwarm.Path()
            {
                F = 0.5,
                Length = graphs[j].Paths[graphs[i].NameGraph].Length
            });
        }
        
    }
}

Console.WriteLine("Весь граф\n");
Console.Write("\t");

foreach(var graph in graphs)
{
    Console.Write($"{graph.NameGraph} \t");
}

for(int i = 0; i < graphs.Count; i++)
{
    Console.Write($"\n{graphs[i].NameGraph} \t");
    int index = 0;

    for(int j = 0; j < graphs.Count; j++)
    {   
        if (index == i)
        {
            Console.Write("\t");
        }
        else
        {
            Console.Write($"{graphs[i].Paths[graphs[j].NameGraph].Length}\t");
        }

        index++;
    }
}

int result = int.MaxValue;
List<string> fullPath = new List<string>();

for(int i = 0; i < 50; i++)
{
    var visitor = graphs[random.Next(0, graphs.Count)].Attech(new AntVisitor());

    if(result > visitor.LengthAllPath)
    {
        result = visitor.LengthAllPath;
        fullPath = visitor.FullPath;
    }

    foreach(var graph in graphs)
    {
        foreach(var path in graph.Paths.Values)
        {
            path.F = path.F * 0.5;
        }
    }
}

Console.WriteLine("\n\nЛучший путь:");
foreach(var path in fullPath)
{
    Console.Write($"{path}\t");
}

Console.WriteLine($"Длина лучшего пути: {result}");