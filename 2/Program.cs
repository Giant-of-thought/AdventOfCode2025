using System.Text;

namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong s = 0;

            var results = new HashSet<ulong>();


            var ranges = Console.ReadLine().Split(',');


            foreach(var e  in ranges)
            {
                var tmp = e.Split('-');
                var numbers = tmp.Select(z => ulong.Parse(z)).ToList();
                var lenmax = tmp[1].Length;
                var lenmin = tmp[0].Length;

                for(int i = lenmin; i <= lenmax; i++)
                {
                    if(lenmax != lenmin)
                    {
                        Console.WriteLine(lenmin + " " + lenmax);
                    }
                    AssembleNumber(numbers[0], numbers[1], 0, 0, results, i);
                }



            }


            foreach(var e in results)
            {
                s += e;
            }

            Console.WriteLine(s);




        }


        static void AssembleNumber(ulong min, ulong max, int length, ulong prev, HashSet<ulong> sum, int OLen)
        {
            if(length!=0 && OLen % length == 0)
            {
                ulong number = 0;

                for(int i = 0; i < OLen/length; i++)
                {
                    number = number * (ulong)Math.Pow(10, length) + prev;
                }

                if(number >= min && number <= max)
                {
                    sum.Add(number);
                }

            }
            if(length != OLen/2)
            {
                
                for(ulong i = (ulong)(length == 0?1:0); i < 10; i++)
                {
                    AssembleNumber(min, max, length+1, prev*10 + i, sum, OLen);
                }
            }
        }


    }
}
