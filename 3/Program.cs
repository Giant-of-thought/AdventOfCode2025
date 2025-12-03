namespace _3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inp = Console.ReadLine();

            long s = 0;

            while(inp != "")
            {
                s += FindLargestNumber(inp,12);
                inp = Console.ReadLine();
            }

            Console.WriteLine(s);
        }

        static long FindLargestNumber(string str, int len)
        {
            char[] arr = new char[len];
            Array.Fill(arr, '0');

            for (int i = 0; i < str.Length; i++)
            {
                for(int j = 0; j < len; j++)
                {
                    if (str[i] > arr[j] && str.Length - i >= len - j)
                    {
                        arr[j] = str[i];
                        Array.Fill(arr, '0', j+1, len - j - 1);
                        break;
                    }
                }
            }
            long s = 0;

            foreach(var e in arr)
            {
                s = s * 10 + e - 48;
            }

            return s;
        }
    }
}
