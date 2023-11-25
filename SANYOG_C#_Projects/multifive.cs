using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class multifive
    {  internal static void Test()

        {
            int num;
            
            System.Console.WriteLine("enter number");
        num=int.Parse(System.Console.ReadLine());   
            if(num%5==0&&num!=0)

            { System.Console.WriteLine("multiple of 5"); }
            

            

            else { System.Console.WriteLine("not a multiple of 5"); }
        
       }
    }
}
