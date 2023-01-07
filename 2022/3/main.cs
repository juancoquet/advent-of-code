using System.IO;

class Day3
{
    public static int toPriority(char c)
    {
        // a -> 1 ... z -> 26 ... A -> 27 ... Z -> 52
        int p = c;
        if (c >= 97)  // lowercase 
        {
            p -= 'a';
        } else
        {
            p -= 'A';
            p += 26;
        }
        p++;
        return p;
    }

    public static void Main(string[] args)
    {
        // read items
        using (StreamReader items = new StreamReader("input.txt"))
        {
            int dupeSums = 0;
            string bag;
            while ((bag = items.ReadLine()) != null)
            {
                int l = 0, r = bag.Length / 2;
                HashSet<char> lSeen = new HashSet<char>();
                HashSet<char> rSeen = new HashSet<char>();
                while (r < bag.Length)
                {
                    lSeen.Add(bag[l]);
                    rSeen.Add(bag[r]);
                    l++;
                    r++;
                }
                lSeen.IntersectWith(rSeen);
                dupeSums += toPriority(lSeen.First());
            }
            Console.WriteLine(dupeSums);
        }
    }
}

Day3.Main(null);
