using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;
using System.Security.AccessControl;


namespace YuGiOh
{
    class Program
    {
        static void Main(string[] args)
        {
            var dualist1 = new Dualist("Yugi Muto");
            var dualist2 = new Dualist("Seto Kaiba");
            var dualist3 = new Dualist("Yusei Fudo");

            var moncard1 = new MonsterCard(dualist2, "Blue Eyes White Dragon", "Light", 8, 3000, 2500);
            var moncard2 = new MonsterCard(dualist2, "Tutle", "Boat", 8, 3000, 2500);
            var moncard3 = new MonsterCard("Salamangreat Foxer", "Fire", 3, 1200, 1000);
            var moncard4 = new MonsterCard("Gallant Granite", "Earth", 4, 2300, 1800);
            var moncard5 = new MonsterCard(dualist3, "Speed Warrior", "Wind", 2, 900, 400);

            var spellcard1 = new SpellCard(dualist3, "Speedlift", "Quick-Play", "Secial Summon");
            var spellcard2 = new SpellCard(dualist1, "Fusion of Fire", "Normal", "Fusion Summon from Extra Deck");
            var spellcard3 = new SpellCard("Mordschlag", "Equip");

            var trapcard1 = new TrapCard(dualist1, "Dwimmered Glimmer", "Continuous", "Banishing 1 Face Up Monster", "Special Summon a Card as Normal Monster");
            var trapcard2 = new TrapCard(dualist3, "Gladiator Beast Charge", "Normal", "Monster Attacking", "Destroy Face-Up Cards on Opponinents Field");

            moncard1.PrintInfo();
            moncard2.PrintInfo();

            dualist1.PrintDeck();

            dualist2.SignatureCard = moncard1.Name;
            dualist2.PrintDeck();

            dualist3.PrintDeck();

            Console.ReadLine();
        }
    }
}