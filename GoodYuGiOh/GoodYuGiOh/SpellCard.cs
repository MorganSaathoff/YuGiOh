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
	public class SpellCard : Card
	{
		private string _effect;
		private string _spelltype;
		
		public string Effect
        {
            get { return _effect; }
        }

		public string TypeofSpell 
		{ 
			get { return _spelltype; }
		}

		public bool ValidSpellType = false;
		public bool Normal;
		public bool Continuous;
		public bool Equip;
		public bool QuickPlay;
		public bool Field;
		public bool Ritual;

		public const string DefaultEffect = "Draw one card";

		public SpellCard(Dualist owner, string name, string spelltype, string effect) : base(owner, name, "Spell")
		{
			this._owner = owner.Name;
			this.ValidateCardType(this._type);
			this._name = name;
			this.ValidateAttribute(spelltype);
			this._effect = effect;

			owner.AddToDeck(this);
		}

		public SpellCard(string name, string spelltype, string effect) : base(name, "Spell")
		{
			this._owner = this.DefaultOwner;
			this.ValidateCardType(this._type);
			this._name = name;
			this.ValidateAttribute(spelltype);
			this._effect = effect;
		}

		public SpellCard(string name, string spelltype) : base(name, "Spell")
		{
			this._owner = this.DefaultOwner;
			this.ValidateCardType(this._type);
			this._name = name;
			this.ValidateAttribute(spelltype);
			this._effect = DefaultEffect;
		}
		public void ValidateAttribute(string type)
		{
			if (type == "Normal" || type == "normal")
			{
				Normal = true;
				Continuous = false;
				Equip = false;
				QuickPlay = false;
				Field = false;
				Ritual = false;
			}
			else if (type == "Continuous" || type == "continuous")
			{
				Normal = false;
				Continuous = true;
				Equip = false;
				QuickPlay = false;
				Field = false;
				Ritual = false;
			}
			else if (type == "Equip" || type == "equip")
			{
				Normal = false;
				Continuous = false;
				Equip = true;
				QuickPlay = false;
				Field = false;
				Ritual = false;
			}
			else if (type == "Quick Play" || type == "quick play" || type == "Quick-Play" || type == "quick-play" || type == "quickplay" || type == "QuickPlay" || type == "Quickplay" || type == "Quick-play" || type == "Quick play")
			{
				Normal = false;
				Continuous = false;
				Equip = false;
				QuickPlay = true;
				Field = false;
				Ritual = false;
			}
			else if (type == "Field" || type == "light")
			{
				Normal = false;
				Continuous = false;
				Equip = false;
				QuickPlay = false;
				Field = true;
				Ritual = false;
			}
			else if (type == "Ritual" || type == "water")
			{
				Normal = false;
				Continuous = false;
				Equip = false;
				QuickPlay = false;
				Field = false;
				Ritual = true;
			}
			else
			{
				Normal = false;
				Continuous = false;
				Equip = false;
				QuickPlay = false;
				Field = false;
				Ritual = false;
			}

			if (Normal == true)
			{
				this._spelltype = "Normal";
				ValidSpellType = true;
			}
			else if (Continuous == true)
			{
				this._spelltype = "Continuous";
				ValidSpellType = true;
			}
			else if (Equip == true)
			{
				this._spelltype = "Equip";
				ValidSpellType = true;
			}
			else if (QuickPlay == true)
			{
				this._spelltype = "QuickPlay";
				ValidSpellType = true;
			}
			else if (Field == true)
			{
				this._spelltype = "Field";
				ValidSpellType = true;
			}
			else if (Ritual == true)
			{
				this._spelltype = "Ritual";
				ValidSpellType = true;
			}
			else
			{
				this._spelltype = type + "...is an INVALID SPELL TYPE (valid spell types: normal, continuous, equip, quick-play, field, or ritual) and cannot be added to decks";
			}
		}

		public override void PrintInfo()
		{
			Console.WriteLine("Owner: " + this.Owner);
			Console.WriteLine("Card: " + this.Name);
			Console.WriteLine("Spell Type: " + this.TypeofSpell);
			Console.WriteLine("Effect: " + this.Effect);
		}
	}
}
