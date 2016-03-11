using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace Key_Exploration
{

    class KeyExploration
    {

    }

    class Program
    {

        static BigInteger Pow(BigInteger a, BigInteger t, BigInteger n)
        {
            BigInteger ans = 1;
            while (t > 0)
            {
                if (t % 2 == 0)
                {
                    a *= a;
                    a %= n;
                    t /= 2;
                }
                else
                {
                    ans *= a;
                    ans %= n;
                    t--;
                }
            }
            return ans;
        }

        static bool IsProbablyPrime(BigInteger num, int k, int lengthBit)
        {
            BigInteger t = num -1;
            BigInteger temp = num - 1;
            int s = 0;
            do
            {
                if(temp % 2 == 0)
                {
                    temp /= 2;
                    s++;
                    t = temp;
                }
            } while(t % 2 == 0);
            Random rand = new Random();
            while (k > 0)
            {
                k--;
                BigInteger a;

                do
                {
                    byte[] data = new byte[lengthBit - 1];
                    rand.NextBytes(data);
                    a = new BigInteger(data);
                    if (a < 0)
                        a *= -1;
                } while (a < 2 || a > num - 2);


                BigInteger x = Pow(a, t, num);
                if (x == 1 || x == num - 1)
                    continue;

                int i = 0;
                while (i < s)
                {
                    i++;
                    x = x * x % num;
                    if (x == 1)
                        return false;
                    if (x == num - 1)
                    {
                        break;
                    }
                    return false;
                }
            }
            return true;

        }

        static BigInteger CalcPrimeNum(int lengthBit, int k)
        {
            BigInteger ans;
            byte[] bytes = new byte[lengthBit];
            bytes[0] = 1;
            bytes[lengthBit - 1] = 1;

            ans = new BigInteger(bytes);

            while (!IsProbablyPrime(ans, k, lengthBit))
            {
                ans += 2;
            }
            return ans;
        }

        static void Main(string[] args)
        {
            BigInteger a = CalcPrimeNum(10, 1000);
            Console.WriteLine(a);
            
        }
    }
}
