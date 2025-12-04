namespace _4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new List<char[]>();
            var inp = Console.ReadLine();

            while (inp != "")
            {
                var tmp = inp.ToCharArray();
                arr.Add(tmp);
                inp = Console.ReadLine();
            }


            Console.WriteLine(Part2(arr).Count);
        }

        static List<(int,int)> Part1(List<char[]> arr)
        {
            var res = new List<(int,int)>();

            for(int i = 0; i < arr.Count; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    if(arr[i][j] == '@')
                    {
                        var sur = 0;

                        for (int x = Math.Max(0, i - 1); x <= Math.Min(arr.Count - 1, i + 1); x++)
                            for (int y = Math.Max(0, j - 1); y <= Math.Min(arr[i].Length - 1, j + 1); y++)
                                if (arr[x][y] == '@')
                                    sur++;

                        if (sur < 5)
                            res.Add((i,j));
                    }
                }
            }

            return res;
        }

        static List<(int, int)> Part2(List<char[]> arr)
        {
            var res = new List<(int, int)>();

            var tmp = Part1(arr);

            while(tmp.Count != 0)
            {
                foreach(var e  in tmp)
                {
                    res.Add(e);
                    arr[e.Item1][e.Item2] = '.';
                }

                tmp = Part1(arr);
            }

            return res;

        }

    }
}
