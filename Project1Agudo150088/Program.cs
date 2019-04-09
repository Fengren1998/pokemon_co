//	Agudo,	Mikhail Joseph T.
//	150088
//	November 11, 2016
//	I	have	not	discussed	the	C# language	code	in	my	program	
//	with	anyone	other	than	my	instructor	or	the	teaching	assistants	assigned	to	this
//	course. I	have	not	used	C# language	code	obtained	from	
//	another person,	or	any	other	unauthorized	source,	either	modified	or	unmodified.
//	Any	C# language	code	or	documentation	used	in	my	program	
//	that	was	obtained	from	another	source,	such	as	a	text	book,	a	web	page,
//	or	another	person, have	been	clearly	noted	with	proper	citation	in	the	
//	comments	of	my	program.

//Special Thanks to Stack Overflow
//for helping me clear up why some things don't work and why some things make an error
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Agudo150088
{
    class Program
    {
        static void Main(string[] args)
        {
            Trainer Player = new Trainer();
            bool QuitChecker = false;
            string PlayerChoice;
            Player.CheatCandy();
            while (QuitChecker == false) //Prints Main Menu
            {
                Console.WriteLine("");
                Console.WriteLine(@"=====POKEMON CO MENU=====
1 for Register
2 for Catch
3 for Transfer
4 for Level Up
5 for Evolve
6 for Devolve
7 for View Bag
8 for View Pokedex
9 for Trainer Stadium
10 for Pokemon Center
0 to QUIT");
                Console.Write("Enter Choice: ");
                PlayerChoice = (Console.ReadLine());
                Console.Clear();
                if (PlayerChoice == "1")
                {
                    Player.RegisterPokemon();
                }
                else if (PlayerChoice == "2")
                {
                    Player.CatchPokemon();
                }
                else if (PlayerChoice == "3")
                {
                    Player.TransferPokemon();
                }
                else if (PlayerChoice == "4")
                {
                    Player.LevelUpPokemon();
                }
                else if (PlayerChoice == "5")
                {
                    Player.EvolvePokemon();
                }
                else if (PlayerChoice == "6")
                {
                    Player.DevolvePokemon();
                }
                else if (PlayerChoice == "7")
                {
                    Player.ViewBag();
                }
                else if (PlayerChoice == "8")
                {
                    Player.ViewPokedex();
                }
                else if (PlayerChoice == "9")
                {
                    Player.BattlePokemon();
                }
                else if (PlayerChoice == "10")
                {
                    Player.PokemonCenter();
                }
                else if (PlayerChoice == "0")
                {
                    QuitChecker = true;
                }
            }
        }
    }
}
