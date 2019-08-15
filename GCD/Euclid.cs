using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    public class Euclid
    {
        public static long EuclidGCD(long a, long b)
        {
            if (b == 0)
                return Math.Abs(a);
            return EuclidGCD(b, a % b);
        }

        public static long EuclidGCD(out long time, long a, long b) => GCD(EuclidGCD, a, b, out time);


        public static long EuclidGCD(long a, long b, long c) => GCD(EuclidGCD, a, b, c);

        public static long EuclidGCD(out long time, long a, long b, long c) => GCD(EuclidGCD, a, b, c, out time);


        public static long EuclidGCD(params long[] nums) => GCD(EuclidGCD, nums);

        public static long EuclidGCD(out long time, params long[] nums) => GCD(EuclidGCD, out time, nums);




        private static void CheckInputArray(long[] nums)
        {
            if (nums == null)
                throw new ArgumentNullException();

            if (nums.Length < 2)
                throw new ArgumentException();
        }

        private static long GCD(Func<long, long, long> gcdFunc, long a, long b, out long time)
        {
            var sw = Stopwatch.StartNew();

            long gcd = gcdFunc(a, b);

            time = sw.ElapsedTicks;


            return gcd;
        }


        private static long GCD(Func<long, long, long> gcdFunc, long a, long b, long c) => gcdFunc(gcdFunc(a, b), c);

        private static long GCD(Func<long, long, long, long> gcdFunc, long a, long b, long c, out long time)
        {
            var sw = Stopwatch.StartNew();

            long gcd = gcdFunc(a, b, c);

            time = sw.ElapsedTicks;

            return gcd;
        }


        private static long GCD(Func<long, long, long> gcdFunc, params long[] nums)
        {
            CheckInputArray(nums);

            long gcd = gcdFunc(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                gcd = gcdFunc(gcd, nums[i]);
            }

            return gcd;
        }

        private static long GCD(Func<long[], long> gcdFunc, out long time, params long[] nums)
        {
            var sw = Stopwatch.StartNew();

            long gcd = gcdFunc(nums);

            time = sw.ElapsedTicks;


            return gcd;
        }
    }
}
