namespace _5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ranges = new List<(long, long)>();
            var ids = new List<long>();

            var inp = Console.ReadLine();

            while (inp != "")
            {
                var tmp = inp.Split('-').Select(z => long.Parse(z)).ToArray();
                ranges.Add((tmp[0], tmp[1]));
                inp = Console.ReadLine();
            }

            inp = Console.ReadLine();

            while (inp != "")
            {
                ids.Add(long.Parse(inp));
                inp = Console.ReadLine();
            }

            Console.WriteLine(Part2(ranges));
        }

        static int Part1(List<(long, long)> ranges, List<long> ids)
        {
            var s = 0;

            MergeRanges(ranges);

            foreach (var e in ids)
            {
                var tmp = BinarySearch.Search(ranges,(x,y) => x.Item1.CompareTo(y.Item1) , (e, 0));
                
                for(int i = -2; i <= 2; i++)
                {
                    if(e >= ranges[Math.Clamp(tmp + i, 0, ranges.Count - 1)].Item1 &&  e <= ranges[Math.Clamp(tmp + i, 0, ranges.Count - 1)].Item2)
                    {
                        s++;
                        //Console.WriteLine(tmp);
                        break;
                    }
                    else
                    {
                        //Console.WriteLine(e + " " + tmp);
                    }
                }
            }
            return s;
        }

        static long Part2(List<(long, long)> ranges)
        {
            long s = 0;
            MergeRanges(ranges);

            foreach (var e in ranges)
                s = s + (e.Item2-e.Item1) + 1;

            return s;
        }

        static void MergeRanges(List<(long, long)> ranges)
        {
            ranges.Sort((x, y) => x.Item1.CompareTo(y.Item1));



            for (int i = 1; i < ranges.Count; i++)
            {
                if (ranges[i].Item1 <= ranges[i - 1].Item2)
                {
                    Console.WriteLine("Merge " + ranges[i - 1] + " with " + ranges[i]);
                    ranges[i - 1] = (ranges[i - 1].Item1, Math.Max(ranges[i].Item2, ranges[i - 1].Item2));
                    ranges.RemoveAt(i);
                    i--;
                }
            }
        }



    }
}
