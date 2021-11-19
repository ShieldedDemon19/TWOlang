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
	loops [x]
	add/div/mul/sub a & b
	input
	other various garbage
*/

using System;
//using System.IO; //probably not needed yet. file import support coming somtime, maybe never.

namespace TWO
{ //devilmayquake.com
	public class Interpreter
	{ //corndog.io
		static char[] CharTable = {' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '\n'};
		//maybe replace this garbage with ascii sometime
        
		static bool PE = false;
		//die, or die?
		
		static bool Loop = false;
		//in a loop, or NHYOOM
		
		static int operand = -1;
		//dunno why i need this, it is just kinda existing.
		
		static int a = 0; 
		//first variable, used for data, etc.
		
		static int b = 0; 
		//second variable, used for functions and events, etc
		
		public static void Main(string[] args)
		{
			Console.Title = "TWO"; //incase you decide to rename the project or something idrk
			Console.WriteLine($"PROGRAM READY { CharTable.Length }"); //purely for debug purposes.
			string data = Console.ReadLine();
			int ks = 0;
			
			for(int k = 0; k < data.Length; k++)
			{ //main loop
				if(b < 0)
				{
					b = 0;
				}
				
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
						
					case '[': //start loop
						Loop = true;
						ks = k;
						break;
					
					case ']': //end loop
						if(Loop && b >= 0){
							k = ks;
						}else{
							Loop = false;
						}
						break;
					
					case '+': //add operator
						a = a+b;
						break;
					
					case '-': //subtract operator
						a = a-b;
						break;
					
					case '$': //cash money operator 
						{
							int temp = a+b;
							a = temp;
							b = temp;
						}
						break;
						
					case '_': //depression operator
						{
							int temp = a-b;
							a = temp;
							b = temp;
						}
						break;
					
					default: //invalid characters are skipped
						operand = -1;
						break;
				}
				
				TWO(); //call function that handles interpreter calls
				
				if(k+1 == data.Length && !PE)
				{ //reset
					Console.Write('\n');
					a = 0;
					b = 0;
					k = -1;
					data = Console.ReadLine();
					continue;
				}
				
				if(PE)
				{ //die
					break;
				}
			}
			Console.Write('\n');
			Console.WriteLine("PRESS ANY KEY TO CONTINUE");
			Console.ReadKey();
		} //commit die
		
		static void TWO()
		{ //operations
			switch(operand)
			{
				case 0: //die
					PE = true;
					break;
					
				case 1: //output character
					if(a < 0 || a > CharTable.Length - 1)
					{ //check if a is OOB
						a = 0;
					}
					Console.Write(CharTable[a]);
					break;
					
				case 2://output a raw
					Console.Write(a);
					break;
					
				case 3:
					{
						char temp = char.ToLower(Console.ReadKey(true).KeyChar);
						//fixed this bit. get user input, turn to lowercase, and see if its in the TWO alphabet.
						
						for(int i = 0; i < CharTable.Length; i++)
						{
							if(temp == CharTable[i])
							{
								a = i;
								break;
							}
						}
					}
					break;
					
				case 4:
					{	
						int temp = 0;
						int intermediate = 0;
						char tempTwo = '\0';
						for(int i = 0; i < 9; i++)
						{
							tempTwo = Console.ReadKey(true).KeyChar;
							
							//broken bad \n doesnt work literalyy crying. run. 
							if(tempTwo == ' ' || tempTwo == '\n')
							{
								a = temp;
								break; //die if they type space or something i have no idea what im doing anymore please send helb
							}
							
							intermediate = (int) Char.GetNumericValue(tempTwo);
							
							//temp (current value to import) times ten to the power of i (current iteration) plus intermediate (new num to add)
							//great algorithm, i know. hire me microsoft
							temp = (temp * (int) Math.Pow(10, i)) + intermediate;
						}
					}
					break;
					
					
				default://broken? skip it!
					break;
			}
		}
	}
}

/*
	. - increase a 
	, - decrease a 
	> - increase b 
	< - decrease b 
	! - call function based on b's current value
	[ - start loop
	] - end loop
	+ - add a and b and store in a
	- - subtract a and b and store in a
	$ - add a and b and store in both
	_ - subtract a and b and store in both
	more operations coming soon!
	
	0 - end program
	1 - output character in a 
	2 - output a raw
	3 - input char into a
	4 - input raw number into a
	more stuff comin sone!
*/
