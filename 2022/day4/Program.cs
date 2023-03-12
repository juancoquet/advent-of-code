class Program
{
    private static int FindContainedRanges(IEnumerable<(int a0, int a1, int b0, int b1)> tuples)
    {
        var fullyContained = tuples.Where(
            x => ((x.a0 >= x.b0 && x.a1 <= x.b1) || (x.a0 <= x.b0 && x.a1 >= x.b1))
        );

        return fullyContained.Count();
    }

    private static int FindOverlappingRanges(IEnumerable<(int a0, int a1, int b0, int b1)> tuples)
    {
        var overlaps = tuples.Where(
            x => ((x.a0 >= x.b0 && x.a0 <= x.b1) || (x.b0 >= x.a0 && x.b0 <= x.a1))
        );
        return overlaps.Count();
    }

    private static IEnumerable<(int, int, int, int)> PrepareData(IEnumerable<string> input)
    {
        var tuples = input
            .Select(
                ranges =>
                    ranges
                        .Split(",")
                        .SelectMany(ab => ab.Split("-").Select(n => int.Parse(n)))
                        .ToList()
            )
            .Select(ab => (a0: ab[0], a1: ab[1], b0: ab[2], b1: ab[3]));
        return tuples;
    }

    private static IEnumerable<string> GetInput()
    {
        return System.IO.File.ReadAllLines("input.txt");
    }

    public static void Main(string[] args)
    {
        var input = GetInput();
        var tuples = PrepareData(input);

        var fullyContained = FindContainedRanges(tuples); // challenge 1 answer
        Console.WriteLine(fullyContained);

        var overlaps = FindOverlappingRanges(tuples); // challenge 2 answer
        Console.WriteLine(overlaps);
    }
}
