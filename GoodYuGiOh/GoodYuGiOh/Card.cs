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
	public abstract class Card
	{
		protected string _owner;
		protected string _name;
		protected string _type;

		public string Owner
		{
			get { return _owner; }
            set { _owner = value; }
		}

		public string Name
		{
			get { return _name; }
           // set { _name = value; }
		}

		public string Type
		{
			get { return _type; }
		}

		public bool ValidType = false;
		protected bool Monster;
		protected bool Spell;
		protected bool Trap;
		
		public string InvalidReason = " ";
		public bool Valid = true; 
		public string mon1 = "Monster";
		public string mon2 = "monster";
		public string spell1 = "Spell";
		public string spell2 = "spell";
		public string trap1 = "Trap";
		public string trap2 = "trap";

		public string DefaultOwner = "Unowned";
		public string DefaultName = "Unknown";
		public string DefaultType = "Unknown";

		public Card(Dualist owner, string cardname, string type)
		{
			this._owner = owner.Name;
			this._name = cardname;
			this.ValidateCardType(type);
		}

		public Card(Dualist owner, string cardname)
		{
			this._owner = owner.Name;
			this._name = cardname;
		}

		public Card(string cardname, string type)
		{
			this._name = cardname;
			this._type = type;
			this._owner = DefaultOwner;
		}

		public Card(string cardname)
		{
			this._name = cardname;
			this._type = DefaultType;
			this.ValidateCardType(this._type);
			this._owner = DefaultOwner;
		}

		public Card()
        {
			this._name = DefaultName;
			this._owner = DefaultOwner;
			this._type = DefaultType;
			this.ValidateCardType(this._type);
        }

		public virtual void PrintInfo()
		{
			Console.WriteLine("Card: " + this.Name);
			Console.WriteLine("Card Type: " + this.Type);
			Console.WriteLine("Owner: " + this.Owner);
		}

		public void ValidateCardType(string type)
		{
			if (type == mon1 || type == mon2)
			{
				Monster = true;
				Spell = false;
				Trap = false;
			}
			else if (type == spell1 || type == spell2)
			{
				Monster = false;
				Spell = true;
				Trap = false;
			}
			else if (type == trap1 || type == trap2)
			{
				Monster = false;
				Spell = false;
				Trap = true;
			}
			else
			{
				Monster = false;
				Spell = false;
				Trap = false;
			}

			if(Monster == true)
            {
				this._type = "Monster";
				ValidType = true;
				
            }
			else if(Spell == true)
            {
				this._type = "Spell";
				ValidType = true;
			}
			else if(Trap == true)
            {
				this._type = "Trap";
				ValidType = true;
			}
            else
            {
				this._type = type + "...is an INVALID CARD TYPE (valid card types: monster, trap, or spell)";
			}
		}
	}
}
