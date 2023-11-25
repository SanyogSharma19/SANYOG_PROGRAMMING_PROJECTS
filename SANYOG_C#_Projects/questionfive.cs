using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class questionfive
    {internal static void Test()
        {
            int counter = 0;
            Console.WriteLine("enter element");
            counter = int.Parse(System.Console.ReadLine());
            int[] arr = new int[counter];
            int x;
            Console.WriteLine($"Count:{counter}");
            Console.WriteLine("inputs");
            for (int i = 0; i < counter; i++)
            {
                x = int.Parse(System.Console.ReadLine());
                
                 arr[i] = x; 

            }
            Console.WriteLine("Outputs:");
            Console.Write("numbers are: ");

            for (int i = 0; i < arr.Length; i++)
            { Console.Write($"{arr[i]} " ); }


        }
    }
}
