namespace _6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> rows = [];
            var inp = Console.ReadLine();
            var lenghts = new List<int>(    inp.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length  );

            while (inp[0] != '+' && inp[0] != '*')
            {
                rows.Add(inp);
                var tmp = inp.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < tmp.Length; i++)
                {
                    if (lenghts.Count == 0)
                        for (int v = 0; v < tmp.Length; v++)
                            lenghts.Add(0);
                    if (tmp[i].Length > lenghts[i])
                        lenghts[i] = tmp[i].Length;
                }

                inp = Console.ReadLine();
            }

            Console.WriteLine(Part2(rows, lenghts, inp.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList()));
        }

        static long Part1(List<List<long>> rows, List<string> operations)
        {
            long res = 0;
            for(int j = 0; j < rows[0].Count; j++)
            {
                long s = operations[j] == "*"?1:0;
                for (int i = 0; i < rows.Count; i++)
                {
                    if (operations[j] == "*")
                        s *= rows[i][j];
                    else
                        s += rows[i][j];
                }
                res += s;
            }

            return res;
        }

        static long Part2(List<string> rows, List<int> lenghts, List<string> operations) 
        {
            long res = 0;
            int j = 0;
            long curNumb = 0;
            int curNumbLen = 0;

            for(int x = 0; x < lenghts.Count; x++)
            {
                long s = operations[x] == "*" ? 1 : 0;
                curNumbLen = 0;
                while (curNumbLen < lenghts[x])
                {
                    curNumb = 0;
                    for (int i = 0; i < rows.Count; i++)
                        if (rows[i][j] != ' ')
                            curNumb = curNumb * 10 + rows[i][j] - 48;
                    if (operations[x] == "*")
                        s *= curNumb;
                    else
                        s += curNumb;
                    j++;
                    curNumbLen++;
                }

                j++;
                res += s;
            }

            return res;
        }
    }
}
