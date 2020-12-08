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
	public class Dualist
	{
		protected string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public List<string> Deck = new List<string>();

		public string SignatureCard { get; set; }

		public bool valid = false;

		public int NumofCards = 0;
		public int NumMonsterCards = 0;
		public int NumSpellCards = 0;
		public int NumTrapCards = 0;

		public Dualist(string name)
		{
			this._name = name;
		}

		public void AddToDeck(MonsterCard monster)
		{
			if (monster.ValidAttribute == true)
			{
				NumofCards++;
				Deck.Add(monster.Name);
				Deck.Add(monster.Type);
				monster.Owner = this.Name;
				valid = true;
			}
            else
            {
				Deck.Add("Unable to add " + monster.Name + " to " + this.Name + "'s deck due to");
				Deck.Add("INVALID ATTRIBUTE");
			}
			this.CalMonCards();
			this.CalSpellCards();
			this.CalTrapCards();
			valid = false;
		}

		public void AddToDeck(SpellCard spell)
        {
			if (spell.ValidSpellType == true)
			{
				NumofCards++;
				Deck.Add(spell.Name);
				Deck.Add(spell.Type);
				spell.Owner = this.Name;
				valid = true;
			}
			else
			{
				Deck.Add("Unable to add " + spell.Name + " to " + this.Name + "'s deck due to");
				Deck.Add("INVALID SPELL TYPE");
				valid = false;
			}
			this.CalMonCards();
			this.CalSpellCards();
			this.CalTrapCards();
			valid = false;
		}

		public void AddToDeck(TrapCard spell)
		{
			if (spell.ValidTrapType == true)
			{
				NumofCards++;
				Deck.Add(spell.Name);
				Deck.Add(spell.Type);
				spell.Owner = this.Name;
				valid = true;
			}
			else
			{
				Deck.Add("Unable to add " + spell.Name + " to " + this.Name + "'s deck due to");
				Deck.Add("INVALID SPELL TYPE");
				valid = false;
			}
			this.CalMonCards();
			this.CalSpellCards();
			this.CalTrapCards();
			valid = false;
		}

		public void PrintDeck()
		{			
			Console.WriteLine(" ");
			Console.WriteLine(this.Name + "'s Deck:");
			for (int i = 0; i < Deck.Count; i++)
			{
				Console.WriteLine(Deck[i] + " - " + Deck[i+1]);
				i++;
			}
			Console.WriteLine(" ");

			Console.WriteLine("Deck Info:");
			Console.WriteLine(this.Name + "'s Signature Card: " + this.SignatureCard);
			Console.WriteLine("Total Monster Cards in Deck: " + this.NumMonsterCards);
			Console.WriteLine("Total Spell Cards in Deck: " + this.NumSpellCards);
			Console.WriteLine("Total Trap Cards in Deck: " + this.NumTrapCards);
			Console.WriteLine("Total Cards in Deck: " + this.NumofCards);
			Console.WriteLine(" ");
			Console.WriteLine(" ");
		}

		public void CalMonCards()
		{
			NumMonsterCards = 0;
			for (int i = 1; i < Deck.Count; i++)
			{
				if (Deck[i] == "Monster" && valid == true)
				{
					NumMonsterCards++;
					i++;
				}
                else
                {
					i ++;
                }

			}
		}

		public void CalSpellCards()
		{
			NumSpellCards = 0;
			for (int i = 1; i < Deck.Count; i++)
			{
				if (Deck[i] == "Spell" && valid == true)
				{
					NumSpellCards++;
					i++;
				}
                else
                {
					i++;
                }	
			}
		}

		public void CalTrapCards()
		{
			NumTrapCards = 0;
			for (int i = 1; i < Deck.Count; i++)
			{
				if (Deck[i] == "Trap" && valid == true)
				{
					NumTrapCards++;
					i++;
				}
                else
                {
					i++;
                }	
			}
		}
	}
}
