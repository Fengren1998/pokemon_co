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
    class PokemonRegInfo
    {
        public string PokemonName;
        public string PokemonType;
        public string PokemonBaseEvolution;
        public string Pokemon1stEvolution;
        public string Pokemon2ndEvolution;
        public int PokemonCandyCost;
        public int PokemonMultiplier;

        public PokemonRegInfo()
        {
            PokemonName = null;
            PokemonType = null;
            PokemonBaseEvolution = null;
            Pokemon1stEvolution = null;
            Pokemon2ndEvolution = null;
            PokemonCandyCost = 0;
            PokemonMultiplier = 0;
        }

        public PokemonRegInfo(string name, string type, string baseevolution, string firstevolution, string secondevolution, int cost, int multiplier)
        {
            PokemonName = name;
            PokemonType = type;
            PokemonBaseEvolution = baseevolution;
            Pokemon1stEvolution = firstevolution;
            Pokemon2ndEvolution = secondevolution;
            PokemonCandyCost = cost;
            PokemonMultiplier = multiplier;
        }

        public string GetPokemonName()
        {
            return PokemonName;
        }
    }
}
