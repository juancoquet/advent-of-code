class Program
{
    private static int FindContainedRanges(IEnumerable<string> input)
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

        var fullyContained = tuples.Where(
            x => ((x.a0 >= x.b0 && x.a1 <= x.b1) || (x.a0 <= x.b0 && x.a1 >= x.b1))
        );

        return fullyContained.Count();
    }

    private static IEnumerable<string> GetInput()
    {
        return System.IO.File.ReadAllLines("input.txt");
    }

    public static void Main(string[] args)
    {
        var input = GetInput();
        var fullyContained = FindContainedRanges(input); // challenge 1 answer
        Console.WriteLine(fullyContained);
    }
}
