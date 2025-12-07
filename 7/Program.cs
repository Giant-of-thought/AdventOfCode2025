namespace _7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inp = Console.ReadLine();
            var beams = new List<long[]>();
            beams.Add(new long[inp.Length]);
            var tmp = inp.IndexOf('S');
            beams[0][tmp] = 1;
            int s = 0;

            inp = Console.ReadLine();

            var ind = 0;

            while(inp != "")
            {
                beams.Add(new long[inp.Length]);
                for(int i = 0; i < inp.Length; i++)
                {
                    if (inp[i] == '^' && beams[ind][i] > 0) // По хорошему должна быть провекра на ^^ и границе массива, но в инпуте нет таких случаев
                    {
                        s++;
                        beams[ind + 1][i - 1] += beams[ind][i];
                        beams[ind + 1][i + 1] += beams[ind][i];
                        //beams[ind][i] = 0;
                    }
                    else if (beams[ind][i] > 0)
                        beams[ind + 1][i] += beams[ind][i];
                }
                ind++;
                inp = Console.ReadLine();
            }

            Console.WriteLine();
            /*

            foreach (var e in beams)
            {
                foreach (var g in e)
                    Console.Write(g);
                Console.WriteLine();
            }
            */

            long s2 = 0;

            foreach (var item in beams[^1])
            {
                s2 += item;
            }

            Console.WriteLine(s2);

        }
    }
}
