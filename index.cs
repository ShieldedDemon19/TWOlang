/*
                ___________             __________
    |\        /|           |           |          |
    | \      / |           |           |          |
    |  \    /  |           |           |          | 
    |   \  /   |_______    |           |          |
    |    \/    |           |           |          |
    |          |           |           |          |
    |          |           |           |          |
    |          |___________|___________|__________|
    
    made by me (MELO[nkgur])
    spare classtime? make an esolang!
    or eat self esteem idrc

*/


/*
    FEATURES TO ADD:
    loops
    add/div/mul/sub a & b
    input
    other various garbage
*/

using System;
using System.IO;

namespace TWO
{
    public class Interpreter
    {
        static char[] CharTable = {' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '\n'};
        //maybe replace this garbage with ascii sometime
        static bool PE = false;
        
        public static void Main(string[] args)
        {
            Console.Title = "TWO";
            string data = Console.ReadLine(); //get data from user
            int a = 0; //first variable, used for data, etc.
			int b = 0; //second variable, used for functions and events, etc.
            int operand = -1;

			for(int k = 0; k < data.Length; k++)
			{
				char i = data[k];

                switch(i) 
				{
					case '.': //add to a
						a++;
                        operand = -1;
						break;
					
					case ',': //sub from a
						a--;
                        operand = -1;
						break;

					case '>': //add to b
						b++;
                        operand = -1;
						break;

					case '<': //sub from b
						b--;
                        operand = -1;
						break;

                    case '!': //tell interpreter to do something
                        operand = b;
                        break;

					default: //invalid characters are skipped
                        operand = -1;
						break;
				}

				TWO(operand, a);

                if(k+1 == data.Length && !PE)
                {
                    Console.Write('\n');
                    a = 0;
                    b = 0;
                    k = -1;
                    data = Console.ReadLine();
                    continue;
                }

                if(PE)
                {
                  break;
                }
			}
            Console.Write('\n');
            Console.WriteLine("PRESS ANY KEY TO CONTINUE");
            Console.ReadKey();
        }

		public static void TWO(int operand, int a)
		{
            switch(operand)
            {
                case 0:
                    PE = true;
                    break;

                case 1:
                    if(CharTable[a] != 0 && a < CharTable.Length)
                    {
                        Console.Write(CharTable[a]);
                    }else{
                        Console.WriteLine($"INVALID CHAR: { a } ");
                    }
                    break;

                case 2:
                    Console.WriteLine(a);
                    break;

                default:
                    break;
            }
		}
    }
}

/*
	OTHER OPERANDS
	. - increase a 
	, - decrease a 
	> - increase b 
	< - decrease b 
	! - call function based on b's current value

	B CHART:
	0 - end program
	1 - output character in a 
	2 - output a raw

    More coming soon!
*/