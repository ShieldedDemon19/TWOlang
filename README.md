# TWO

Two, as the name suggests, is an esolang with only two variables *(A, B)*. It was created by Shielded Demon 19 *(melonkgur)* during class because he was bored. 

*Also, if you couldn't tell already, I wrote this in c#. You are going to need a compiler, such as [Mono](https://www.mono-project.com/docs/about-mono/languages/csharp/).*

## TWO Commands

TWO is a very simple language. A is used purely for data, while B is used to store data *as well as* call specific functions. Here is all 5 of the current commands: 
- To increment A, type " `.` ".
- To decrement A, type " `,` ".
- To increment B, type " `>` ".
- To decrement B, type " `<` ".
- To call the interpreter, type " `!` ". 
- To mark the start a loop, type " `[` ".
- To mark the end of a loop, type " `]` ".

## TWO Interpreter calls

Upon reading an exclamation point, the interpreter will call a special function. This function corresponds to the value in B. There are currently three functions:   
- If B is 0, the program will close. *(pressing enter with nothing on the current line will do the same thing)*
- If B is 1, the program will use the current value in A and output a character. This character can be anything from 0 to 27 *([space], a, b c... x, y, z, \n)*.
- If B is 2, the program will output the current numerical value of A.
- User input is coming soon!

## TWO Hello world example

This is what a simple "hello world" program would look like in TWO:  

`>........!,,,!.......!!...!,,,,,,,,,,,,,,,!.......................!,,,,,,,,!...!,,,,,,!,,,,,,,,!<!`

## TWO Loops

A loop will keep running so long as B is greater than 0. Once B is equal to zero, it will continue reading after it. The following program will output every letter in the TWO alphabet, **forever**.

`>[.!]`

*god, this really is horrible.*

