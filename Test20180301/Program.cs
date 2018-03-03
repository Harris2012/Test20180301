using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test20180301
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseValue = 5;

            for (int i = 0; i < Math.Pow(baseValue, 10); i++)
            {
                var items = TenToX(i, baseValue);
                if (items == null)
                {
                    continue;
                }

                var isValid = IsValid(items);
                if (isValid)
                {
                    DisplayValue(items);
                }
            }

            Console.WriteLine("...");

            Console.Read();
        }

        static void DisplayValue(List<int> items)
        {
            if (items == null)
            {
                Console.WriteLine(nameof(items) + " is null.");
            }
            else
            {
                Console.WriteLine(string.Join(" ", items.Select(v => "ABCD"[v - 1])));
                Console.WriteLine();
            }
        }

        static bool IsValid(List<int> items)
        {
            var one = items[0];
            var two = items[1];
            var three = items[2];
            var four = items[3];
            var five = items[4];
            var six = items[5];
            var seven = items[6];
            var eight = items[7];
            var nine = items[8];
            var ten = items[9];

            var A = 1;
            var B = 2;
            var C = 3;
            var D = 4;

            //第2题
            var secondIsValid =
                (two == A && five == C)
                ||
                (two == B && five == D)
                ||
                (two == C && five == A)
                ||
                (two == D && five == B);
            if (!secondIsValid)
            {
                return false;
            }

            //第3题
            var threeIsValid =
                (three == A && three != six && three != two && three != four)
                ||
                (three == B && six != three && six != two && six != four)
                ||
                (three == C && two != three && two != six && two != four)
                ||
                (three == D && four != three && four != six && four != two);
            if (!threeIsValid)
            {
                return false;
            }

            //第4题
            var fourIsValid =
                (four == A && one == five)
                ||
                (four == B && two == seven)
                ||
                (four == C && one == nine)
                ||
                (four == D && six == ten);
            if (!fourIsValid)
            {
                return false;
            }

            //第5题
            var fiveIsValid =
                (five == A && five == eight)
                ||
                (five == B && five == four)
                ||
                (five == C && five == nine)
                ||
                (five == D && five == seven);
            if (!fiveIsValid)
            {
                return false;
            }

            //第6题
            var sixIsValid =
                (six == A && eight == two && eight == four)
                ||
                (six == B && eight == one && eight == six)
                ||
                (six == C && eight == three && eight == ten)
                ||
                (six == D && eight == five && eight == nine);
            if (!sixIsValid)
            {
                return false;
            }

            //第7题
            var aCount = items.Where(v => v == A).Count();
            var bCount = items.Where(v => v == B).Count();
            var cCount = items.Where(v => v == C).Count();
            var dCount = items.Where(v => v == D).Count();
            var sevenIsValid =
                (seven == A && aCount < bCount && aCount < cCount && aCount < dCount)
                ||
                (seven == B && bCount < aCount && bCount < cCount && bCount < dCount)
                ||
                (seven == C && cCount < aCount && cCount < bCount && cCount < dCount)
                ||
                (seven == D && dCount < aCount && dCount < bCount && dCount < cCount);
            if (!sevenIsValid)
            {
                return false;
            }

            //第8题
            var eightIsValid =
                (eight == A && Math.Abs(seven - one) > 1)
                ||
                (eight == B && Math.Abs(five - one) > 1)
                ||
                (eight == C && Math.Abs(two - one) > 1)
                ||
                (eight == D && Math.Abs(ten - one) > 1);
            if (!eightIsValid)
            {
                return false;
            }

            //第9题
            var nineIsValid =
                (nine == A && ((one == six) != (six == five)))
                ||
                (nine == B && ((one == six) != (ten == five)))
                ||
                (nine == C && ((one == six) != (two == five)))
                ||
                (nine == D && ((one == six) != (nine == five)));
            if (!nineIsValid)
            {
                return false;
            }

            //第10题
            var maxCount = Math.Max(Math.Max(aCount, bCount), Math.Max(cCount, dCount));
            var minCount = Math.Min(Math.Min(aCount, bCount), Math.Min(cCount, dCount));
            var tenIsValid =
                (ten == A && maxCount - minCount == 3)
                ||
                (ten == B && maxCount - minCount == 2)
                ||
                (ten == C && maxCount - minCount == 4)
                ||
                (ten == D && maxCount - minCount == 1);

            return true;
        }

        /// <summary>
        /// 转字母
        /// </summary>
        /// <param name="number">十进制转换成N进制</param>
        /// <returns></returns>
        static List<int> TenToX(int number, int baseValue)
        {
            List<int> returnValue = new List<int>();

            while (number != 0)
            {
                returnValue.Insert(0, number % baseValue);
                number /= baseValue;
            }

            if (returnValue.Count == 0)
            {
                returnValue.Add(0);
            }

            if (returnValue.Count < 10 || returnValue.Contains(0))
            {
                return null;
            }

            return returnValue;
        }
    }
}
