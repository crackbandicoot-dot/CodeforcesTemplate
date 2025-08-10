namespace CodeforcesTemplate
{
    
    internal class Program
    {

        public static int Int()
        {
            return int.Parse(Console.ReadLine()!);
        }
        public static long Long()
        {
            return long.Parse(Console.ReadLine()!);
        }
        public static long[] LongArray()
        {
            return Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
        }
        public static int[] IntArray()
        {
            return Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        }
        public static (int x, int y) Vector2D()
        {
            var arr = Console.ReadLine()!.Split();
            return (int.Parse(arr[0]), int.Parse(arr[1]));
        }
        public static (int x, int y, int z) Vector3D()
        {
            var arr = Console.ReadLine()!.Split();
            return (int.Parse(arr[0]), int.Parse(arr[1]), int.Parse(arr[2]));
        }
        public static (long x, long y) LongVector2D()
        {
            var arr = Console.ReadLine()!.Split();
            return (long.Parse(arr[0]), long.Parse(arr[1]));
        }
        public static (long x, long y, long z) LongVector3D()
        {
            var arr = Console.ReadLine()!.Split();
            return (long.Parse(arr[0]), long.Parse(arr[1]), long.Parse(arr[2]));
        }
        
        /// <summary>
        /// Computes the sum of the interval [a,b]
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static long Sum(long a,long b)
        {
            return b * (b + 1) / 2 - (a - 1) * a / 2;
        }
        static long MaxProffit(int[] A,int n,int m)
        {
            if(n==1)
            {
                return Sum(A[0] - Math.Min(A[0],n), A[0]);
            }
            long ans = 0;
            for (int i = m - 2; i >= 0; i--)
            {
                if (A[i+1] - A[i]>=n)
                {
                    ans += Sum(A[i+1]-n, A[i+1]);
                    return ans;
                }
                else
                {
                    ans+= Sum(A[i+1]-A[i]+1, A[i+1]);
                    n-= (A[i+1] - A[i]);
                    if (m-i>=n)
                    {
                        ans += n * A[i];
                        return ans;
                    }
                    else
                    {
                        A[i + 1] = A[i];
                        ans += (m-i)* A[i+1];
                        n -= (m - i);
                    }

                }
            }
            return ans;
        }
        static void Main(string[] args)
        {
            (int n, int m) = Vector2D();
            int[] A = IntArray();
            Array.Sort(A);
            long max = MaxProffit(A, n, m);
            for (int i = 0; i < m; i++)
            {
                A[i] = -A[i];
            }
            Array.Sort(A);
            long min = MaxProffit(A, n, m);
            Console.WriteLine($"{max} {min}");
        }
    }
}