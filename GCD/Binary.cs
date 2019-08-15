using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    class Binary
    {

        public static long BinaryGCD(long a, long b)
        {
            if (a == 0)
                return b;                            
            if (b == 0)
                return a;                            
            if (a == b)
                return a;                            
            if (a == 1 || b == 1)
                return 1;                           
            if ((a & 1) == 0)                        
                return ((b & 1) == 0)
                    ? BinaryGCD(a >> 1, b >> 1) << 1       
                    : BinaryGCD(a >> 1, b);              
            else                                   
                return ((b & 1) == 0)
                    ? BinaryGCD(a, b >> 1)                 
                    : BinaryGCD(b, a > b ? a - b : b - a); 
        }


        public static long BinaryGCD(out long time, long a, long b) => GCD(BinaryGCD, a, b, out time);


        public static long BinaryGCD(long a, long b, long c) => GCD(BinaryGCD, a, b, c);


        public static long BinaryGCD(out long time, long a, long b, long c) => GCD(BinaryGCD, a, b, c, out time);


        public static long BinaryGCD(params long[] nums) => GCD(BinaryGCD, nums);

        public static long BinaryGCD(out long time, params long[] nums) => GCD(BinaryGCD, out time, nums);




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
