
namespace AntSwarm;

public class AntVisitor : Visitor
{


    public override string Visit(Dictionary<string, Path> dict)
    {
        if (FullPath.Count == dict.Count)
        {
            return string.Empty;
        }

        Dictionary<string, double> p  = new Dictionary<string, double>();

        double sum = 0;
        foreach(var namePath in dict.Keys)
        {
            if (!FullPath.Contains(namePath))
            {
                var path = dict[namePath];
                var localResult = Math.Pow(path.Length, 0.5) * Math.Pow(path.F, 0.5);
                sum += localResult;
                p.Add(namePath, localResult);
            } 
        }

        foreach(var namePath in p.Keys)
        {
            p[namePath] = Convert.ToInt32(p[namePath] / sum * 100);
        }

        var random = new Random();
        var result = random.Next(1, 99);

        var numericLine = 0;

        foreach(var namePath in p.Keys)
        {
            numericLine += Convert.ToInt32(p[namePath]);

            if (numericLine - p[namePath] <= result && numericLine > result)
            {
                dict[namePath].F += 0.5 / dict[namePath].Length;
                LengthAllPath += dict[namePath].Length;

                return namePath;
            }
        }

        throw new ArgumentOutOfRangeException(nameof(p));
    }
}
