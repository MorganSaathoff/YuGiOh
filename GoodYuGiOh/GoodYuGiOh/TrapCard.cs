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
	public class TrapCard : Card
	{
		private string _traptype;
		private string _trigger;
		private string _effect;

		public string TrapType
        {
            get { return _traptype; }
        }
		public string Trigger
        {
            get { return _trigger; }
        }
		public string Effect
        {
            get { return _effect; }
        }

		public bool ValidTrapType = false;
		public bool Normal;
		public bool Continuous;
		public bool Counter;
		public bool Equip;
		public bool Field;

		public const string DefaultEffect = "Attcking monster is destroyed";
		public const string DefaultTrigger = "Monster attacking";

		public TrapCard(Dualist owner, string name, string traptype, string trig, string effect) : base(owner, name, "Trap")
		{
			this._owner = owner.Name;
			this.ValidateCardType(this._type);
			this._name = name;
			this.ValidateAttribute(traptype);
			this._trigger = trig;
			this._effect = effect;

			owner.AddToDeck(this);
		}

		public TrapCard(string name, string traptype, string trig, string effect) : base(name, "Trap")
		{
			this._owner = this.DefaultOwner;
			this.ValidateCardType(this._type);
			this._name = name;
			this.ValidateAttribute(traptype);
			this._trigger = trig;
			this._effect = effect;
		}

		public TrapCard(string name, string traptype) : base(name, "Trap")
		{
			this._owner = this.DefaultOwner;
			this.ValidateCardType(this._type);
			this._name = name;
			this.ValidateAttribute(traptype);
			this._effect = DefaultEffect;
			this._trigger = DefaultTrigger;
		}

		public void ValidateAttribute(string type)
		{
			if (type == "Normal" || type == "normal")
			{
				Normal = true;
				Continuous = false;
				Counter = false;
				Equip = false;
				Field = false;
			}
			else if (type == "Continuous" || type == "continuous")
			{
				Normal = false;
				Continuous = true;
				Counter = false;				
				Equip = false;
				Field = false;
			}
			else if (type == "Counter" || type == "counter")
			{
				Normal = false;
				Continuous = false;
				Counter = true;				
				Equip = false;
				Field = false;

			}
			else if (type == "Equip" || type == "equip")
			{
				Normal = false;
				Continuous = false;
				Counter = false;
				Equip = true;
				Field = false;
			}
			else if (type == "Field" || type == "field")
			{
				Normal = false;
				Continuous = false;
				Counter = false;
				Equip = false;
				Field = true;
			
			}
			
			else
			{
				Normal = false;
				Continuous = false;
				Counter = false;
				Equip = false;
				Field = false;
			}

			if (Normal == true)
			{
				this._traptype = "Normal";
				ValidTrapType = true;
			}
			else if (Continuous == true)
			{
				this._traptype = "Continuous";
				ValidTrapType = true;
			}
			else if (Counter == true)
			{
				this._traptype = "Counter";
				ValidTrapType = true;
			}
			else if (Equip == true)
			{
				this._traptype = "Equip";
				ValidTrapType = true;
			}
			else if (Field == true)
			{
				this._traptype = "Field";
				ValidTrapType = true;
			}
			else
			{
				this._traptype = type + "...is an INVALID SPELL TYPE (valid spell types: normal, continuous, equip, quick-play, field, or ritual) and cannot be added to decks";
			}
		}

		//public override void PrintInfo()
		//{
		//	throw new NotImplementedException();
		//}

	}
}

