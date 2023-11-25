using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class questionfour
    {
        
        internal static void Test()
        {
            Console.WriteLine("enter array");
            int[] arr = new int[5];
            int x;
            for (int i = 0; i < 5; i++)
            {
                x = int.Parse(System.Console.ReadLine());
                if (x % 7 == 0 && x % 9 == 0)
                { arr[i] = x; }

            }
            for (int i = 0; i < arr.Length; i++)
            { Console.WriteLine(arr[i]); }
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            { Console.WriteLine(arr[i]); }
            Console.WriteLine("maximum array element is");
            Console.WriteLine(arr[arr.Length - 1]);
        }
    }
}
