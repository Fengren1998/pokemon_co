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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Agudo150088
{
    class MyPokemon
    {
        public string PokemonName;
        public int PokemonHP;
        public int PokemonBattleHP;
        public int PokemonCP;
        public string PokemonBaseEvolution;
        public string Pokemon1stEvolution;
        public string Pokemon2ndEvolution;
        public int PokemonCandyCost;
        public int PokemonMultiplier;

        public MyPokemon()
        {
            PokemonName = null;
            PokemonHP = 0;
            PokemonBattleHP = 0;
            PokemonCP = 0;
            PokemonBaseEvolution = null;
            Pokemon1stEvolution = null;
            Pokemon2ndEvolution = null;
        }

        public MyPokemon(string name, int HP, int CP, int BattleHP, string baseevolution, string firstevolution, string secondevolution)
        {
            PokemonName = name;
            PokemonHP = HP;
            PokemonBattleHP = BattleHP;
            PokemonCP = CP;
            PokemonBaseEvolution = baseevolution;
            Pokemon1stEvolution = firstevolution;
            Pokemon2ndEvolution = secondevolution;
        }

        public string Get1stEvolution()
        {
            return Pokemon1stEvolution;
        }
    }
}
