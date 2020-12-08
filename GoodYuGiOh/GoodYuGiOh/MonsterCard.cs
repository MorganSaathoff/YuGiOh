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
	public class MonsterCard : Card
	{
		private string _attribute;
		private int _lvl;
		private int _ap;
		private int _dp;

		public string Attribute
		{
			get { return _attribute; }
		}

		public int Level
		{
			get { return _lvl; }
		}

		public int AttackPoints
		{
			get { return _ap; }
		}
		public int DefensePoints
		{
			get { return _dp; }
		}

		public bool ValidAttribute = false;
		public bool Dark;
		public bool Divine;
		public bool Earth;
		public bool Fire;
		public bool Light;
		public bool Water;
		public bool Wind;

		public const int DefaultLevel = 0;
		public const int DefaultAP = 0;
		public const int DefaultDP = 0;

		public MonsterCard(Dualist owner, string name, string attribute, int level, int AP, int DP) : base(owner, name, "Monster")
		{
			this._owner = owner.Name;
			this.ValidateCardType(this._type);
			this._name = name;
			this.ValidateAttribute(attribute);
			this._lvl = level;
			this._ap = AP;
			this._dp = DP;

			owner.AddToDeck(this);
		}

		public MonsterCard(string name, string attribute, int level, int AP, int DP) : base(name, "Monster")
		{
			this._owner = this.DefaultOwner;
			this.ValidateCardType(this._type);
			this._name = name;
			this.ValidateAttribute(attribute);
			this._lvl = level;
			this._ap = AP;
			this._dp = DP;
			
		}

		public MonsterCard(string name, string attribute) : base(name, "Monster")
		{
			this._owner = this.DefaultOwner;
			this.ValidateCardType(this._type);
			this._name = name;
			this.ValidateAttribute(attribute);
			this._lvl = DefaultLevel;
			this._ap = DefaultAP;
			this._dp = DefaultDP;
		}

		public override void PrintInfo()
        {
			Console.WriteLine("Owner: " + this.Owner);
			Console.WriteLine("Card: " + this.Name);
			Console.WriteLine("Attribute: " + this.Attribute);
			Console.WriteLine("Level: " + this.Level);
			Console.WriteLine("Attack Points: " + this.AttackPoints);
			Console.WriteLine("Defense Points: " + this.DefensePoints);
		}

		public void ValidateAttribute(string attribute)
		{
			if (attribute == "Dark" || attribute == "dark")
			{
				Dark = true;
				Divine = false;
				Earth = false;
				Fire = false;
				Light = false;
				Water = false;
				Wind = false;
			}
			else if (attribute == "Divine" || attribute == "divine")
			{
				Dark = false;
				Divine = true;
				Earth = false;
				Fire = false;
				Light = false;
				Water = false;
				Wind = false;
			}
			else if (attribute == "Earth" || attribute == "earth")
			{
				Dark = false;
				Divine = false;
				Earth = true;
				Fire = false;
				Light = false;
				Water = false;
				Wind = false;
			}
			else if (attribute == "Fire" || attribute == "fire")
			{
				Dark = false;
				Divine = false;
				Earth = false;
				Fire = true;
				Light = false;
				Water = false;
				Wind = false;
			}
			else if (attribute == "Light" || attribute == "light")
			{
				Dark = false;
				Divine = false;
				Earth = false;
				Fire = false;
				Light = true;
				Water = false;
				Wind = false;
			}
			else if (attribute == "Water" || attribute == "water")
			{
				Dark = false;
				Divine = false;
				Earth = false;
				Fire = false;
				Light = false;
				Water = true;
				Wind = false;
			}
			else if (attribute == "Wind" || attribute == "wind")
			{
				Dark = false;
				Divine = false;
				Earth = false;
				Fire = false;
				Light = false;
				Water = false;
				Wind = true;
			}
			else
			{
				Dark = false;
				Divine = false;
				Earth = false;
				Fire = false;
				Light = false;
				Water = false;
				Wind = false;
			}

			if (Dark == true)
			{
				this._attribute = "Dark";
				ValidAttribute = true;
			}
			else if (Divine == true)
			{
				this._attribute = "Divine";
				ValidAttribute = true;
			}
			else if (Earth == true)
			{
				this._attribute = "Earth";
				ValidAttribute = true;
			}
			else if (Fire == true)
			{
				this._attribute = "Fire";
				ValidAttribute = true;
			}
			else if (Light == true)
			{
				this._attribute = "Light";
				ValidAttribute = true;
			}
			else if (Water == true)
			{
				this._attribute = "Water";
				ValidAttribute = true;
			}
			else if (Wind == true)
			{
				this._attribute = "Wind";
				ValidAttribute = true;
			}
			else
			{
				this._attribute = attribute + "...is an INVALID ATTRIBUTE (valid attributes: dark, divine, earth, fie, light, water, or wind) and cannot be added to decks";
			}
		}
	}
}