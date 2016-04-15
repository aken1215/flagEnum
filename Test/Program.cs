using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ESample sample = ESample.A | ESample.D;

            flagEnum convert = new flagEnum();
            var results= convert.GetUniqueFlags(sample);
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

      
    }


    public class flagEnum
    {
        public IEnumerable<int> GetUniqueFlags(Enum flags)
        {
            int flag = 1;
            foreach (var value in Enum.GetValues(flags.GetType()).Cast<Enum>())
            {
                int bits = Convert.ToInt16(value);
                while (flag < bits)
                {
                    flag <<= 1;
                }

                if (flag == bits && flags.HasFlag(value))
                {
                    yield return Convert.ToInt16(value);
                }
            }
        }
    }


    [Flags]
    public enum ESample
    {
        //這邊我使用 2 的冪次，整數表示，
        //也可使用 16 進制表示，如：0x01、0x08...         
        None = 0,
        A = 1,
        B = 2,
        C = 4,
        D = 8,
        E = None | A | B | C | D
    };
}
