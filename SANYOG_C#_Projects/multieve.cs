using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class multieve
    {internal static void Test()
        {
            int num;
            

            do
            {
                System.Console.WriteLine("enter a number");
                num = int.Parse(System.Console.ReadLine());
                if (num > 100)
                { System.Console.WriteLine("Outside Range"); }
            }while (num > 100);
            
                
               
                if (num % 2 == 0)
                {
                    Console.WriteLine("even number");

                    if (num % 4 == 0 && num % 8 == 0 && num != 0)
                    {
                        Console.WriteLine("its a multiple of 4 and 8");
                    }
                    else { Console.WriteLine("not a multiple of 4 and 8"); }

                }

          else  if (num < 0) { Console.WriteLine("NEGATIVE NUMBER ENTERED"); }


                else { Console.WriteLine("not even "); }

                

            
        }

    }
}
