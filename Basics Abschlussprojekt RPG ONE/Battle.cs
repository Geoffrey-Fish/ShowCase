using static System.Console;

namespace RPGOne
    {

    /// <summary>
    /// No game without some fights!
    /// </summary>
    public class Battles
        {
        /// <summary>
        /// Call a Fight, get a fight, till only one survives!
        /// </summary>
        /// <param name="attacker">Npcs stats</param>
        /// <param name="defender">Players stats</param>
        public static void Battle(Character attacker,Player defender,Room room)
            {
            Clear();
            WriteLine($"YOU ARE ATTACKED BY {attacker.name}!");
            WriteLine($"{attacker.name} SAYS:");
            Narrative.EnemyAttack();
            Thread.Sleep(2000);

            do
                {
                Initiative(attacker,defender);
                }
            while(attacker.hp > 0 && defender.hp > 0);

            if(attacker.hp <= 0)
                {
                defender.xp += attacker.xp;
                attacker.QueueFree(room);
                room.npcs.Remove(attacker);
                WriteLine("MAYBE DRINK A HEALTH POTION...");
                Thread.Sleep(2000);
                Clear();
                Program.Options(room,defender);
                }
            else if(defender.hp <= 0)
                {
                WriteLine("OH NO, NOW YOU ARE PRETTY MUCH DEAD!!!");
                Thread.Sleep(2000);
                Player.DeadHero(defender);
                }

            ///Who is attacking
            void Initiative(Character att,Player def)
                {
                WriteLine("----------");
                // INITIATIVE PHASE
                if(att.RollDice(0,10 + (att.dex / 9)) >= def.RollDice(0,10 + (def.dex / 5)))
                    {
                    WriteLine($"{att.name} HAS INITIATIVE !");
                    Thread.Sleep(700);
                    // ATTACKER ATTACK PHASE
                    FoeAttack(att,def);
                    }
                else
                    {
                    WriteLine($"{def.name} HAS INITIATIVE !");
                    Thread.Sleep(700);
                    // DEFENDER ATTACK PHASE
                    HeroAttack(def,att);
                    }

                }

            ///Npc attacks
            void FoeAttack(Character attacker,Player defender)
                {
                WriteLine();
                Thread.Sleep(700);
                WriteLine($"{attacker.name} IS ATTACKING {defender.name} !");
                Thread.Sleep(700);
                if(attacker.RollDice(0,20) >= defender.RollDice(0,30))
                    {
                    int damage = ((attacker.dmg + (attacker.st / 7)) - defender.ar);
                    defender.hp -= damage;
                    WriteLine($"{attacker.name} HITS {defender.name}\n" +
                              $"WITH {damage} DAMAGE!\n" +
                              $"{defender.name} NOW HAS: {defender.hp} HP.");
                    WriteLine("----------");
                    Thread.Sleep(700);
                    }
                else
                    {
                    WriteLine($"{attacker.name} MISSED {defender.name}.");
                    }
                WriteLine("----------");
                Thread.Sleep(700);
                }


            /// Player attacks
            void HeroAttack(Player attacker,Character defender)
                {
                WriteLine();
                Thread.Sleep(700);
                WriteLine($"{attacker.name} IS ATTACKING {defender.name} !");
                Thread.Sleep(700);
                if(attacker.RollDice(0,30) >= defender.RollDice(0,20))
                    {
                    int damage = ((attacker.dmg + (attacker.st / 5)) - defender.ar);
                    defender.hp -= damage;
                    WriteLine($"{attacker.name} HITS {defender.name}\n" +
                              $"WITH {damage} DAMAGE!\n" +
                              $"{defender.name} NOW HAS: {defender.hp} HP.");
                    WriteLine("----------");
                    Thread.Sleep(700);

                    }
                else
                    {
                    WriteLine($"{attacker.name} MISSED {defender.name}.");
                    }
                WriteLine("----------");
                Thread.Sleep(700);
                }

            }
        }
    }

