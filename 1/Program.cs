namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inp = Console.ReadLine();
            var s = 50;

            var res = 0;

            while(inp != "s")
            {
                var n = int.Parse(inp[1..]);

                if (inp[0] == 'L')
                {
                    var olds = s;
                    res = res + n / 100;
                    n = n % 100;
                    s = (s - n)%100;
                    if (s < 0)
                    {
                        if (olds != 0)
                            res = res + 1;
                        s = s + 100;
                    }
                    else if (s == 0)
                    {
                        res++;
                    }

                }
                else
                {
                    res = res + (s + n) / 100;
                    s = (s + n) % 100;
                }


                inp = Console.ReadLine();
            }

            Console.WriteLine(res);
        }
    }
}
