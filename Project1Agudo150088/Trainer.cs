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
    class Trainer
    {
        private const int RegMAX = 100;
        private const int TeamMAX = 10;
        private PokemonRegInfo[] Pokemon;
        List<MyPokemon> PokemonStorage = new List<MyPokemon>();
        List<MyPokemon> PokemonTeam = new List<MyPokemon>();
        List<EnemyPokemon> OpponentTeam = new List<EnemyPokemon>();
        private int PokedexAmount;
        private int StorageAmount;
        private int TeamAmount;
        private int OpponentAmount;
        private int TotalCandy;
        private bool Checker1; //checks and stuff
        Random RNGesus = new Random();

        private int TeamAlive;
        private int OpponentAlive;

        int HP;
        int MinRoll;
        int MaxRoll;
        int CP;

        string ChooseID;
        int RealID;

        public Trainer()
        {
            Pokemon = new PokemonRegInfo[RegMAX];
            PokedexAmount = 0;
            TeamAmount = 0;
            TotalCandy = 0;
        }

        public void RegisterPokemon()
        {
            Checker1 = true;
            Console.WriteLine("");
            Console.WriteLine("=====REGISTER=====");
            Console.Write("Name: "); string name = Console.ReadLine().ToUpper();
            for (int i = 0; i < PokedexAmount; i++) //checks for duplicates
            {
                if (name.Equals(Pokemon[i].GetPokemonName(), StringComparison.OrdinalIgnoreCase)) //how you compare strings, OrdinalIgnoreCase to ignore cases
                {
                    Console.WriteLine("THAT POKEMON HAS ALREADY BEEN REGISTERED.");
                    Console.ReadLine();
                    Checker1 = false;
                }
            }
            if (Checker1 == true) //check for proceeding
            {
                string baseevolution = name;
                string secondevolution;
                Console.Write("Type: "); string type = Console.ReadLine().ToUpper();
                Console.Write("First Evolution: "); string firstevolution = Console.ReadLine().ToUpper();
                if (firstevolution != "NONE")
                {
                    Console.Write("Second Evolution: "); secondevolution = Console.ReadLine().ToUpper();
                    int cost = RNGesus.Next(10, 15); //RNG for cost and multiplier
                    int multiplier = RNGesus.Next(2, 3);
                    Pokemon[PokedexAmount] = new PokemonRegInfo(name, type, baseevolution, firstevolution, secondevolution, cost, multiplier);
                    PokedexAmount++;
                    Console.WriteLine(name + " SUCCESSFULLLY REGISTERED TO POKEDEX.");
                    Console.ReadLine();
                    Checker1 = false;
                }
                else if (firstevolution == "NONE")
                {
                    secondevolution = "NONE";
                    int cost = RNGesus.Next(10, 15); //RNG for cost and multiplier
                    int multiplier = RNGesus.Next(2, 3);
                    Pokemon[PokedexAmount] = new PokemonRegInfo(name, type, baseevolution, firstevolution, secondevolution, cost, multiplier);
                    PokedexAmount++;
                    Console.WriteLine(name + " SUCCESSFULLLY REGISTERED TO POKEDEX.");
                    Console.ReadLine();
                    Checker1 = false;
                }
            }
            Console.Clear();
        }

        public void CatchPokemon()
        {
            if (TeamAmount < 10)
            {
                Console.WriteLine("");
                Console.WriteLine("=====CATCH=====");
                if (PokedexAmount > 0)
                {
                    int RandomPokemon = RNGesus.Next(0, PokedexAmount);
                    string name = Pokemon[RandomPokemon].PokemonName;
                    RNGesusStatRoll();
                    int BattleHP = HP;
                    string baseevolution = Pokemon[RandomPokemon].PokemonBaseEvolution;
                    string firstevolution = Pokemon[RandomPokemon].Pokemon1stEvolution;
                    string secondevolution = Pokemon[RandomPokemon].Pokemon2ndEvolution;
                    int cost = Pokemon[RandomPokemon].PokemonCandyCost;
                    int multiplier = Pokemon[RandomPokemon].PokemonMultiplier;
                    int CatchOn = 1;
                    Console.Clear();
                    while (CatchOn == 1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("=====CATCH=====");
                        int RandomCatch = RNGesus.Next(1, 100);
                        int RandomEscape = RNGesus.Next(1, 100);
                        Console.WriteLine("You see a wild " + name + "!");
                        Console.WriteLine("PRESS ENTER TO THROW A POKEBALL");
                        if (RandomCatch > 60 && RandomCatch <= 100)
                        {
                            Console.WriteLine(".");
                            Console.ReadLine();
                            Console.WriteLine("..");
                            Console.ReadLine();
                            PokemonTeam.Add(new MyPokemon() { PokemonName = name, PokemonHP = HP, PokemonCP = CP, PokemonBattleHP = BattleHP, PokemonBaseEvolution = baseevolution, Pokemon1stEvolution = firstevolution, Pokemon2ndEvolution = secondevolution, PokemonCandyCost = cost, PokemonMultiplier = multiplier });
                            TeamAmount++;
                            Console.WriteLine(name + " HAS BEEN CAUGHT!");
                            Console.ReadLine();
                            CatchOn = 0;
                        }
                        else if (RandomEscape > 0 && RandomEscape <= 10)
                        {
                            Console.WriteLine(".");
                            Console.ReadLine();
                            Console.WriteLine("..");
                            Console.ReadLine();
                            Console.WriteLine(name + " ESCAPED!");
                            Console.ReadLine();
                            CatchOn = 0;
                        }
                        else
                        {
                            Console.WriteLine(".");
                            Console.ReadLine();
                            Console.WriteLine("..");
                            Console.ReadLine();
                            Console.WriteLine(name + " GOT OUT OF THE POKEBALL!");
                            Console.ReadLine();
                        }
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("YOU HAVE NOT REGISTERED A POKEMON");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("YOUR BAG IS FULL.");
                Console.ReadLine();
            }
            Console.Clear();
        }

        public void TransferPokemon()
        {
            Console.WriteLine("");
            Console.WriteLine("=====TRANSFER=====");
            PrintPokemonTeam();
            Console.WriteLine("==================");
            Console.WriteLine("TOTAL CANDY: {0}", TotalCandy);
            Console.WriteLine("BAG CAPACITY: {0}/{1}", TeamAmount, TeamMAX);
            PlayerChoice();
            if (RealID > 0 && RealID <= TeamAmount)
            {
                Console.WriteLine("{0} SUCCESSFULLY TRANSFERRED. YOU RECEIVED 1 CANDY.", PokemonTeam[RealID - 1].PokemonName);
                PokemonTeam.RemoveAt(RealID - 1);
                TeamAmount--;
                TotalCandy += 1;
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("INVALID ID");
                Console.ReadLine();
            }
            Console.Clear();
        }

        public void EvolvePokemon()
        {
            Console.WriteLine("");
            Console.WriteLine("=====EVOLVE=====");
            PrintPokemonTeam();
            Console.WriteLine("==================");
            Console.WriteLine("TOTAL CANDY: {0}", TotalCandy);
            Console.WriteLine("BAG CAPACITY: {0}/{1}", TeamAmount, TeamMAX);
            PlayerChoice();
            if (RealID <= TeamAmount && RealID > 0)
            {
                if (RealID > 0 && RealID <= TeamAmount && TotalCandy >= PokemonTeam[RealID - 1].PokemonCandyCost)
                {
                    if (PokemonTeam[RealID - 1].Pokemon1stEvolution == "NONE")
                    {
                        Console.WriteLine(PokemonTeam[RealID - 1].PokemonName + " CANNOT BE EVOLED FURTHER");
                        Console.ReadLine();
                    }
                    else if (PokemonTeam[RealID - 1].PokemonName.Equals(PokemonTeam[RealID - 1].Pokemon1stEvolution, StringComparison.OrdinalIgnoreCase) && PokemonTeam[RealID - 1].Pokemon2ndEvolution == "NONE")
                    {
                        Console.WriteLine(PokemonTeam[RealID - 1].PokemonName + " CANNOT BE EVOLED FURTHER");
                        Console.ReadLine();
                    }
                    else if (PokemonTeam[RealID - 1].PokemonName.Equals(PokemonTeam[RealID - 1].PokemonBaseEvolution, StringComparison.OrdinalIgnoreCase)) //base to 1st
                    {
                        Console.WriteLine(PokemonTeam[RealID - 1].PokemonName + " HAS EVOLVED INTO " + PokemonTeam[RealID - 1].Pokemon1stEvolution);
                        PokemonTeam[RealID - 1].PokemonName = PokemonTeam[RealID - 1].Pokemon1stEvolution; //changes name
                                                                                                           //PokemonTeam[ChooseID - 1].Pokemon1stEvolution = "---"; //changes evolution
                        PokemonTeam[RealID - 1].PokemonHP *= PokemonTeam[RealID - 1].PokemonMultiplier; //changes HP
                        PokemonTeam[RealID - 1].PokemonCP *= PokemonTeam[RealID - 1].PokemonMultiplier; //changes CP
                        TotalCandy -= PokemonTeam[RealID - 1].PokemonCandyCost; //deducts candies
                        Console.ReadLine();
                    }
                    else if (PokemonTeam[RealID - 1].PokemonName.Equals(PokemonTeam[RealID - 1].Pokemon1stEvolution, StringComparison.OrdinalIgnoreCase)) // 1st to 2nd
                    {
                        Console.WriteLine(PokemonTeam[RealID - 1].PokemonName + " HAS EVOLVED INTO " + PokemonTeam[RealID - 1].Pokemon2ndEvolution);
                        PokemonTeam[RealID - 1].PokemonName = PokemonTeam[RealID - 1].Pokemon2ndEvolution; //changes name
                                                                                                           //PokemonTeam[ChooseID - 1].Pokemon1stEvolution = "---"; //changes evolution
                        PokemonTeam[RealID - 1].PokemonHP *= PokemonTeam[RealID - 1].PokemonMultiplier; //changes HP
                        PokemonTeam[RealID - 1].PokemonCP *= PokemonTeam[RealID - 1].PokemonMultiplier; //changes CP
                        TotalCandy -= PokemonTeam[RealID - 1].PokemonCandyCost; //deducts candies
                        Console.ReadLine();
                    }
                }
                else if (TotalCandy < PokemonTeam[RealID - 1].PokemonCandyCost)
                {
                    Console.WriteLine("YOU DO NOT HAVE ENOUGH CANDY TO EVOLVE THIS POKEMON");
                    Console.WriteLine("NEED {0} CANDY TO EVOLVE", PokemonTeam[RealID - 1].PokemonCandyCost);
                    Console.ReadLine();
                }
            }
            else if (RealID <= 0 || RealID > TeamAmount)
            {
                Console.WriteLine("INVALID ID");
                Console.ReadLine();
            }

            Console.Clear();
        }

        public void ViewBag()
        {
            Console.WriteLine("");
            Console.WriteLine("=====VIEW BAG=====");
            PrintPokemonTeam();
            Console.WriteLine("==================");
            Console.WriteLine("TOTAL CANDY: {0}", TotalCandy);
            Console.WriteLine("BAG CAPACITY: {0}/{1}", TeamAmount, TeamMAX);
            Console.ReadLine(); //selection
            Console.Clear();
        }

        public void ViewPokedex()
        {
            Console.WriteLine("");
            Console.WriteLine("=====VIEW POKEDEX=====");
            Console.WriteLine("{0,-4}{1,-12}{2,-12}{3,-12}", "ID", "NAME", "TYPE", "EVOLUTION");
            for (int i = 0; i < PokedexAmount; i++)
            {
                Console.WriteLine("{0,-4}{1,-12}{2,-12}{3} >> {4} >> {5}", i + 1, Pokemon[i].PokemonName, Pokemon[i].PokemonType, Pokemon[i].PokemonBaseEvolution, Pokemon[i].Pokemon1stEvolution, Pokemon[i].Pokemon2ndEvolution);
            }
            Console.WriteLine("Total Registered: {0}", PokedexAmount);
            Console.WriteLine("======================");
            Console.ReadLine();
            Console.Clear();
        }

        public void LevelUpPokemon()
        {
            Console.WriteLine("");
            Console.WriteLine("=====POKEMON LEVEL UP=====");
            PrintPokemonTeam();
            Console.WriteLine("==================");
            Console.WriteLine("TOTAL CANDY: {0}", TotalCandy);
            Console.WriteLine("BAG CAPACITY: {0}/{1}", TeamAmount, TeamMAX);
            PlayerChoice();
            if (TotalCandy > 0)
            {
                if (RealID > 0 && RealID <= TeamAmount)
                { //level up
                    PokemonTeam[RealID - 1].PokemonHP += RNGesus.Next(15, 50) * PokemonTeam[RealID - 1].PokemonMultiplier;
                    PokemonTeam[RealID - 1].PokemonCP += RNGesus.Next(15, 50) * PokemonTeam[RealID - 1].PokemonMultiplier;
                    TotalCandy -= 1;
                    Console.WriteLine("{0} LEVELLED UP AND INCREASED IN POWER", PokemonTeam[RealID - 1].PokemonName);
                }
            }
            else if (RealID <= 0 || RealID > TeamAmount)
            {
                Console.WriteLine("INVALID ID");
            }
            else if (TotalCandy <= 0)
            {
                Console.WriteLine("NOT ENOUGH CANDY");
            }

            Console.ReadLine();
            Console.Clear();
        }

        public void DevolvePokemon()
        {
            Console.WriteLine("");
            Console.WriteLine("=====DEVOLVE POKEMON=====");
            PrintPokemonTeam();
            Console.WriteLine("==================");
            Console.WriteLine("TOTAL CANDY: {0}", TotalCandy);
            Console.WriteLine("BAG CAPACITY: {0}/{1}", TeamAmount, TeamMAX);
            PlayerChoice();
            if (RealID <= TeamAmount && RealID > 0)
            {
                if (RealID > 0 && RealID <= TeamAmount && TotalCandy >= (PokemonTeam[RealID - 1].PokemonCandyCost + (PokemonTeam[RealID - 1].PokemonMultiplier * 2)))
                {
                    if (PokemonTeam[RealID - 1].PokemonName == PokemonTeam[RealID - 1].Pokemon1stEvolution || PokemonTeam[RealID - 1].PokemonName == PokemonTeam[RealID - 1].Pokemon2ndEvolution)
                    {
                        Console.WriteLine("{0} WENT BACK TO BEING {1}!", PokemonTeam[RealID - 1].PokemonName, PokemonTeam[RealID - 1].PokemonBaseEvolution);
                        PokemonTeam[RealID - 1].PokemonName = PokemonTeam[RealID - 1].PokemonBaseEvolution;
                        RNGesusStatRoll();
                        PokemonTeam[RealID - 1].PokemonHP = HP;
                        PokemonTeam[RealID - 1].PokemonCP = CP;
                        PokemonTeam[RealID - 1].PokemonMultiplier += 1;
                        TotalCandy -= (PokemonTeam[RealID - 1].PokemonCandyCost + (PokemonTeam[RealID - 1].PokemonMultiplier));
                        Console.ReadLine();
                    }
                    else if (PokemonTeam[RealID - 1].PokemonName == PokemonTeam[RealID - 1].PokemonBaseEvolution)
                    {
                        Console.WriteLine("YOU HAVE NOT EVOLVED THIS POKEMON YET");
                        Console.ReadLine();
                    }
                }
                else if (TotalCandy < PokemonTeam[RealID - 1].PokemonCandyCost)
                {
                    Console.WriteLine("YOU DO NOT HAVE ENOUGH CANDY TO DEVOLVE THIS POKEMON");
                    Console.WriteLine("NEED {0} CANDY TO DEVOLVE", PokemonTeam[RealID - 1].PokemonCandyCost + (PokemonTeam[RealID - 1].PokemonMultiplier * 2));
                    Console.ReadLine();
                }
            }
            else if (RealID <= 0 || RealID > TeamAmount)
            {
                Console.WriteLine("INVALID ID");
                Console.ReadLine();
            }
            Console.Clear();
        }

        public void BattlePokemon()
        {
            bool BattleOn = true;
            bool BattleFlow;
            bool FightFlow;
            int TeamAdvantage;
            int StadiumMultiplier = 1;
            if (TeamAmount > 0)
            {
                for (int i = 0; i < TeamAmount; i++) //checks how many pokemon are currently alive
                {
                    if (PokemonTeam[i].PokemonBattleHP > 0)
                    {
                        TeamAlive++;
                    }
                }
                if (TeamAlive > 0)
                {
                    while (BattleOn == true)
                    {
                        BattleFlow = true;
                        FightFlow = false;
                        int CombinedCP = 0;
                        int CombinedHP = 0;
                        for (int i = 0; i < TeamAmount; i++) //checks for combined cp of player team
                        {
                            CombinedCP += PokemonTeam[i].PokemonCP;
                        }
                        CombinedCP /= TeamAmount;
                        for (int i = 0; i < TeamAmount; i++) //checks for combined cp of player team
                        {
                            CombinedHP += PokemonTeam[i].PokemonHP;
                        }
                        CombinedHP /= TeamAmount;
                        OpponentAmount = RNGesus.Next(1, TeamAmount);
                        TeamAdvantage = (TeamAmount + StadiumMultiplier) / (OpponentAmount + 2);
                        if (TeamAdvantage <= 0)
                        {
                            TeamAdvantage = 1;
                        }
                        for (int i = 0; i < OpponentAmount; i++) //generates opponent team
                        {
                            int RandomPokemon = RNGesus.Next(0, PokedexAmount);
                            string name = Pokemon[RandomPokemon].PokemonName;
                            int HP = (RNGesus.Next(CombinedHP - 10, CombinedHP) * TeamAdvantage);
                            int CP = (RNGesus.Next(CombinedCP - 10, CombinedCP) * TeamAdvantage);
                            int BattleHP = HP;
                            OpponentTeam.Add(new EnemyPokemon() { PokemonName = name, PokemonHP = HP, PokemonBattleHP = BattleHP, PokemonCP = CP });
                        }
                        while (BattleFlow == true) // part where player chooses pokemon
                        {
                            Console.WriteLine("");
                            Console.WriteLine("=====TRAINER STADIUM=====");
                            CheckPartyStatus();
                            if (TeamAlive <= 0 && OpponentAlive <= 0)
                            {
                                Console.WriteLine("DRAW!");
                                Console.ReadLine();
                                BattleOn = false;
                                BattleFlow = false;
                                RemoveOpponent();
                            }
                            else if (OpponentAlive <= 0)
                            {
                                Console.WriteLine("YOU WON THE BATTLE!");
                                int CandyMultiplier = StadiumMultiplier - 1;
                                TotalCandy += 15 * (CandyMultiplier);
                                Console.WriteLine("EARNED {0} CANDY", 15 * CandyMultiplier);
                                StadiumMultiplier += 1;
                                Console.ReadLine();
                                bool ForceChoice = true;
                                while (ForceChoice == true)
                                {
                                    Console.WriteLine(@"DO YOU WISH TO CONTINUE IN THE TRAINER STADIUM?
(0 for NO, 1 for YES)
NEXT STADIUM MULTIPLIER: {0}",StadiumMultiplier);
                                    Console.WriteLine("===============");
                                    PrintPokemonTeam();
                                    PlayerChoice();
                                    if (RealID == 1)
                                    {
                                        BattleFlow = false;
                                        ForceChoice = false;
                                    }
                                    else if (RealID == 0)
                                    {
                                        BattleOn = false;
                                        BattleFlow = false;
                                        ForceChoice = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("PLEASE ENTER A VALID CHOICE");
                                    }
                                    Console.Clear();
                                }
                                RemoveOpponent();
                            }
                            else if (TeamAlive <= 0)
                            {
                                Console.WriteLine("YOU WHITED OUT");
                                if (TotalCandy >= 15)
                                {
                                    TotalCandy -= 15;
                                    Console.WriteLine("LOST 15 CANDY");
                                }
                                else
                                {
                                    TotalCandy = 0;
                                    Console.WriteLine("ALL CANDY LOST");
                                }
                                Console.ReadLine();
                                BattleOn = false;
                                BattleFlow = false;
                                RemoveOpponent();
                            }
                            else if (TeamAlive > 0)
                            {
                                Console.WriteLine("");
                                int OpponentChoice = 0;
                                bool ForceOpponentChoice = true;
                                while (ForceOpponentChoice == true)
                                {
                                    OpponentChoice = RNGesus.Next(0, OpponentAmount);
                                    if (OpponentTeam[OpponentChoice].PokemonBattleHP > 0)
                                    {
                                        ForceOpponentChoice = false;
                                    }
                                }
                                Console.WriteLine("OPPONENT TEAM: {0}/{1}", OpponentAlive, OpponentAmount);
                                Console.WriteLine("OPPONENT CHOSE {0}!", OpponentTeam[OpponentChoice].PokemonName);
                                Console.WriteLine("OPPONENT'S {0}--> HP: {1}/{2} -- CP: {3}", OpponentTeam[OpponentChoice].PokemonName, OpponentTeam[OpponentChoice].PokemonBattleHP, OpponentTeam[OpponentChoice].PokemonHP, OpponentTeam[OpponentChoice].PokemonCP);
                                bool ForceChoice = true;
                                while (ForceChoice == true)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("=====CHOOSE YOUR POKEMON=====");
                                    PrintPokemonTeam();
                                    PlayerChoice();
                                    if (RealID > 0 && RealID <= TeamAmount)
                                    {
                                        if (PokemonTeam[RealID - 1].PokemonBattleHP > 0)
                                        {
                                            FightFlow = true;
                                            ForceChoice = false;
                                        }
                                    }
                                    else if (RealID <= 0 && RealID > TeamAmount)
                                    {
                                        Console.WriteLine("INVALID ID");
                                    }
                                    else
                                    {
                                        Console.WriteLine("THAT POKEMON DOES NOT HAVE ENOUGH HP!");
                                        Console.ReadLine();
                                    }
                                    Console.Clear();
                                }
                                while (FightFlow == true)
                                {
                                    CheckPartyStatus();
                                    Console.WriteLine("");
                                    Console.WriteLine("|=====TRAINER BATTLE=====");
                                    Console.WriteLine("|ACTIVE POKEMON: {0}/{1,-5}OPPONENT ACTIVE POKEMON: {2}/{3}", TeamAlive, TeamAmount, OpponentAlive, OpponentAmount);
                                    Console.WriteLine("|");
                                    Console.WriteLine("|YOUR {0}--> HP: {1}/{2, -5} -- CP: {3}", PokemonTeam[RealID - 1].PokemonName, PokemonTeam[RealID - 1].PokemonBattleHP, PokemonTeam[RealID - 1].PokemonHP, PokemonTeam[RealID - 1].PokemonCP);
                                    Console.WriteLine("|");
                                    Console.WriteLine("|OPPONENT'S {0}--> HP: {1}/{2} -- CP: {3}", OpponentTeam[OpponentChoice].PokemonName, OpponentTeam[OpponentChoice].PokemonBattleHP, OpponentTeam[OpponentChoice].PokemonHP, OpponentTeam[OpponentChoice].PokemonCP);
                                    Console.ReadLine();
                                    PokemonTeam[RealID - 1].PokemonBattleHP -= OpponentTeam[OpponentChoice].PokemonCP;
                                    OpponentTeam[OpponentChoice].PokemonBattleHP -= PokemonTeam[RealID - 1].PokemonCP;
                                    if (PokemonTeam[RealID - 1].PokemonBattleHP <= 0 && OpponentTeam[OpponentChoice].PokemonBattleHP <= 0)
                                    {
                                        Console.WriteLine("YOUR {0} FAINTED!", PokemonTeam[RealID - 1].PokemonName);
                                        Console.WriteLine("OPPONENT {0} FAINTED!", OpponentTeam[OpponentChoice].PokemonName);
                                        PokemonTeam[RealID - 1].PokemonBattleHP = 0;
                                        OpponentTeam[OpponentChoice].PokemonBattleHP = 0;
                                        Console.ReadLine();
                                        FightFlow = false;
                                    }
                                    else if (PokemonTeam[RealID - 1].PokemonBattleHP <= 0)
                                    {
                                        Console.WriteLine("YOUR {0} FAINTED!", PokemonTeam[RealID - 1].PokemonName);
                                        PokemonTeam[RealID - 1].PokemonBattleHP = 0;
                                        Console.ReadLine();
                                        FightFlow = false;
                                    }
                                    else if (OpponentTeam[OpponentChoice].PokemonBattleHP <= 0)
                                    {
                                        Console.WriteLine("OPPONENT {0} FAINTED!", OpponentTeam[OpponentChoice].PokemonName);
                                        OpponentTeam[OpponentChoice].PokemonBattleHP = 0;
                                        Console.ReadLine();
                                        FightFlow = false;
                                    }
                                    Console.Clear();
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("YOU DON'T HAVE ABLE POKEMON");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("=====TRAINER STADIUM=====");
                Console.WriteLine("YOU DO NOT HAVE ANY POKEMON WITH YOU");
                Console.ReadLine();
            }
            Console.Clear();
        }

        public void PokemonCenter()
        {
            Console.WriteLine("");
            Console.WriteLine(@"=====POKEMON CENTER=====
Hello and welcome to the Pokemon Center.
1 to Heal Pokemon on a Healing Machine
2 to Transfer Pokemon to Pokemon Storage
3 to Receive Pokemon from Pokemon Storage
4 to View Pokemon Storage
ANY OTHER KEY to Go Back");
            PlayerChoice();
            if (RealID == 1)
            {
                if (TeamAmount > 0)
                {
                    for (int i = 0; i < TeamAmount; i++)
                    {
                        PokemonTeam[i].PokemonBattleHP = PokemonTeam[i].PokemonHP;
                    }
                    Console.WriteLine("SUCCESFULLY RESTORED TIRED POKEMON TO FULL HEALTH");
                }
                else
                {
                    Console.WriteLine("YOU CURRENTLY DO NOT HAVE POKEMON");
                }
                Console.ReadLine();
            }
            else if (RealID == 2) //transfer
            {
                if (TeamAmount > 0 && StorageAmount != 100)
                {
                    Console.WriteLine("=====TRANSFER POKEMON=====");
                    PrintPokemonTeam();
                    PlayerChoice();
                    string name = PokemonTeam[RealID - 1].PokemonName;
                    HP = PokemonTeam[RealID - 1].PokemonHP;
                    CP = PokemonTeam[RealID - 1].PokemonCP;
                    int BattleHP = PokemonTeam[RealID - 1].PokemonBattleHP;
                    string baseevolution = PokemonTeam[RealID - 1].PokemonBaseEvolution;
                    string firstevolution = PokemonTeam[RealID - 1].Pokemon1stEvolution;
                    string secondevolution = PokemonTeam[RealID - 1].Pokemon2ndEvolution;
                    int cost = PokemonTeam[RealID - 1].PokemonCandyCost;
                    int multiplier = PokemonTeam[RealID - 1].PokemonMultiplier;
                    Console.WriteLine("SUCCESSFULLY TRANSFERRED {0}!", PokemonTeam[RealID - 1].PokemonName);
                    PokemonStorage.Add(new MyPokemon() { PokemonName = name, PokemonHP = HP, PokemonCP = CP, PokemonBattleHP = BattleHP, PokemonBaseEvolution = baseevolution, Pokemon1stEvolution = firstevolution, Pokemon2ndEvolution = secondevolution, PokemonCandyCost = cost, PokemonMultiplier = multiplier });
                    PokemonTeam.RemoveAt(RealID - 1);
                    TeamAmount--;
                    StorageAmount++;
                    Console.ReadLine();
                }
                else if (StorageAmount >= 100)
                {
                    Console.WriteLine("YOUR STORAGE IS FULL");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("YOU CURRENTLY DO NOT HAVE POKEMON");
                    Console.ReadLine();
                }
            }
            else if (RealID == 3) //receive
            {
                if (TeamAmount >= 10)
                {
                    Console.WriteLine("YOUR TEAM IS CURRENTLY FULL");
                    Console.ReadLine();
                }
                else if (StorageAmount > 0)
                {
                    Console.WriteLine("=====WITHDRAW POKEMON");
                    PrintPokemonStorage();
                    PlayerChoice();
                    string name = PokemonStorage[RealID - 1].PokemonName;
                    HP = PokemonStorage[RealID - 1].PokemonHP;
                    CP = PokemonStorage[RealID - 1].PokemonCP;
                    int BattleHP = PokemonStorage[RealID - 1].PokemonBattleHP;
                    string baseevolution = PokemonStorage[RealID - 1].PokemonBaseEvolution;
                    string firstevolution = PokemonStorage[RealID - 1].Pokemon1stEvolution;
                    string secondevolution = PokemonStorage[RealID - 1].Pokemon2ndEvolution;
                    int cost = PokemonStorage[RealID - 1].PokemonCandyCost;
                    int multiplier = PokemonStorage[RealID - 1].PokemonMultiplier;
                    Console.WriteLine("SUCCESSFULLY WITHDREW {0}!", PokemonStorage[RealID - 1].PokemonName);
                    PokemonTeam.Add(new MyPokemon() { PokemonName = name, PokemonHP = HP, PokemonCP = CP, PokemonBattleHP = BattleHP, PokemonBaseEvolution = baseevolution, Pokemon1stEvolution = firstevolution, Pokemon2ndEvolution = secondevolution, PokemonCandyCost = cost, PokemonMultiplier = multiplier });
                    PokemonStorage.RemoveAt(RealID - 1);
                    TeamAmount++;
                    StorageAmount--;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("YOUR STORAGE DOES NOT HAVE POKEMON");
                    Console.ReadLine();
                }
            }
            else if (RealID == 4)
            {
                Console.WriteLine("");
                Console.WriteLine("=====VIEW STORAGE=====");
                PrintPokemonStorage();
                Console.ReadLine();
            }
            Console.Clear();
        }

        public void PrintPokemonTeam() //prints all current pokemon
        {
            Console.WriteLine("{0,-4}{1,-15}{2,-11}{3,-12}{4,-11}", "ID", "NAME", "HP", "CURRENT HP", "CP"); //prints list
            for (int i = 0; i < TeamAmount; i++)
            {
                Console.WriteLine("{0,-4}{1,-15}{2,-11}{3,-12}{4,-11}", i + 1, PokemonTeam[i].PokemonName, PokemonTeam[i].PokemonHP, PokemonTeam[i].PokemonBattleHP, PokemonTeam[i].PokemonCP);
            }
            if (TeamAmount == 0)
            {
                Console.WriteLine("YOUR BAG IS EMPTY");
            }
        }

        public void PrintPokemonStorage()
        {
            Console.WriteLine("{0,-4}{1,-12}{2,-6}{3,-12}{4,-4}", "ID", "NAME", "HP", "CURRENT HP", "CP"); //prints list
            for (int i = 0; i < StorageAmount; i++)
            {
                Console.WriteLine("{0,-4}{1,-12}{2,-6}{3,-12}{4,-4}", i + 1, PokemonStorage[i].PokemonName, PokemonStorage[i].PokemonHP, PokemonStorage[i].PokemonBattleHP, PokemonStorage[i].PokemonCP);
            }
            if (StorageAmount == 0)
            {
                Console.WriteLine("YOUR STORAGE IS EMPTY");
            }
        }

        public void PlayerChoice()
        {
            ChooseID = null;
            RealID = 0;
            Console.Write("Enter ID: "); ChooseID = Console.ReadLine();
            bool IDCheck = int.TryParse(ChooseID, out RealID);
        }

        public void CheckPartyStatus()
        {
            TeamAlive = 0;
            OpponentAlive = 0;
            for (int i = 0; i < TeamAmount; i++) //checks how many pokemon are currently alive
            {
                if (PokemonTeam[i].PokemonBattleHP > 0)
                {
                    TeamAlive++;
                }
            }
            for (int i = 0; i < OpponentAmount; i++) //checks opponent's
            {
                if (OpponentTeam[i].PokemonBattleHP > 0)
                {
                    OpponentAlive++;
                }
            }
        }

        public void RemoveOpponent()
        {
            for (int i = 0; i < OpponentAmount; i++) //deletes opponent team
            {
                OpponentTeam.RemoveAt(0);
            }
            OpponentAmount = 0;
        }

        public void CheatCandy()
        {
            TotalCandy = 999999;
        }

        public void RNGesusStatRoll() //rolls stats for a new catch or for a devolved pokemon
        {
            MinRoll = RNGesus.Next(10, 120);
            MaxRoll = RNGesus.Next(310, 540);
            HP = RNGesus.Next(MinRoll, MaxRoll);
            CP = RNGesus.Next(MinRoll, MaxRoll);
        }
    }
}
