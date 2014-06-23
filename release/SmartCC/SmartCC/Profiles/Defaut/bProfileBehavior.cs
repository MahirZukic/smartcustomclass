using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HREngine.Bots
{
	[Serializable]
    public class bProfileBehavior : ProfileBehavior
    {
		public bProfileBehavior() : base()
        {
            
        }
		
		public override List<Card> HandleMulligan(List<Card> Choices)
        {
			List<Card> CardsToKeep = new List<Card>();
			List<string> WhiteList = new List<string>();
			List<string> BlackList = new List<string>();
			int MaxManaCost = 4;
			
			
			
			/* Setup WhiteList */ 
			
			/* Setup BlackList */
			
			BlackList.Add("EX1_007");//Acolyte of Pain
			BlackList.Add("EX1_349");//Divine Favor
			BlackList.Add("CS2_023");//Arcane Intellect
			BlackList.Add("CS2_011");//Savage roar
			BlackList.Add("EX1_622");//Shadow Word Death
			BlackList.Add("EX1_625");//Shadow Form
			
			/* -----PRIEST----- */
			WhiteList.Add("CS2_181");
			foreach(Card c in Choices)
			{
				if(c.template.Id == "CS2_181")
					WhiteList.Add("EX1_621");
			}
			
			

			
			foreach(Card c in Choices)
			{
				foreach(string s in WhiteList)
				{
					if(c.template.Id == s)
						CardsToKeep.Add(c);
				}
				bool isBlackListed = false;
				foreach(string s in BlackList)
				{
					if(c.template.Id == s)
						isBlackListed = true;
				}
				if(c.CurrentCost >= MaxManaCost || isBlackListed ||CardsToKeep.Contains(c))
					continue;
					
				CardsToKeep.Add(c);
			}
			
            return CardsToKeep;
        }
		
        public string EnemyClass(string id)
        {
            /*  WARRIOR  = "HERO_01"
                SHAMAN   = "HERO_02"
                ROGUE    = "HERO_03"
                PALADIN  = "HERO_04"
                HUNTER   = "HERO_05"
                DRUID    = "HERO_06"
                WARLOCK  = "HERO_07"
                MAGE     = "HERO_08"
                PRIEST   = "HERO_09"
                JARAXXUS = "EX1_323h"  */

            switch (id)
            {
                case "HERO_01":
                    return "warrior";
                case "HERO_02":
                    return "shaman";
                case "HERO_03":
                    return "rogue";
                case "HERO_04":
                    return "paladin";
                case "HERO_05":
                    return "hunter";
                case "HERO_06":
                    return "druid";
                case "HERO_07":
                    return "warlock";
                case "HERO_08":
                    return "mage";
                case "HERO_09":
                    return "priest";
                case "EX1_323h":
                    return "lordjaraxxus";
                default:
                    return "Unknown ID: " + id;
            }
        }

        public override bool ShouldPlayMoreMinions(Board board)
        {
			int worthyMinion = 0;
		
			foreach(Card c in board.MinionFriend)
			{
				if(c.GetValue(board) > 10)
					worthyMinion++;
			}
		
            string enemy = EnemyClass(board.HeroEnemy.template.Id);

            if (enemy == "mage" || enemy == "shaman")
            {
                if (worthyMinion >= 3 && board.Hand.Count < 4 && board.MinionEnemy.Count < worthyMinion)
                    return false;
            }
            
            return true;
        }
		
		public override bool ShouldAttackWithWeapon(Board board)
        {
			if(board.WeaponFriend != null)
				if(board.WeaponFriend.template.Id == "EX1_366")
					return false;
            return true;
        }

        public override bool ShouldAttackTargetWithWeapon(Card weapon,Card target)
        {
            return true;
        }
		
    }
}
