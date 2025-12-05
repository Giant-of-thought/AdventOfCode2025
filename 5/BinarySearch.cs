using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    internal class BinarySearch
    {
        public static int Search<T>(List<T> list, Func<T,T,int> compare, T target)
        {
            var l = 0;
            var r = list.Count - 1;
            int m = (l + r) / 2;
            while (l <= r)
            {
                m = l + (r - l) / 2;
                if(compare(target, list[m]) > 0)
                {
                    l = m + 1;
                }
                else if(compare(target, list[m]) < 0)
                {
                    r = m - 1;
                }
                else
                {
                    break;
                }
            }
            return m;
        }
    }
}
