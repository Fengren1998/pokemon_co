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
    class EnemyPokemon
    {
        public string PokemonName;
        public int PokemonHP;
        public int PokemonBattleHP;
        public int PokemonCP;

        public EnemyPokemon()
        {
            PokemonName = null;
            PokemonHP = 0;
            PokemonBattleHP = 0;
            PokemonCP = 0;
        }

        public EnemyPokemon(string name, int HP, int BattleHP, int CP)
        {
            PokemonName = name;
            PokemonHP = HP;
            PokemonBattleHP = BattleHP;
            PokemonCP = CP;
        }
    }
}
