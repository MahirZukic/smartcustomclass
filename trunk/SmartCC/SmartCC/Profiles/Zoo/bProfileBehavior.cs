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
		
		public override List<Card> HandleMulligan(List<Card> Choices, Card.CClass opponentClass)
        {
			/*
			public enum Card.CClass
			{
            SHAMAN = 0,
            PRIEST = 1,
            MAGE = 2,
            PALADIN = 3,
            WARRIOR = 4,
            WARLOCK = 5,
            HUNTER = 6,
            ROGUE = 7,
            DRUID = 8
			}
			*/
		
			List<Card> CardsToKeep = new List<Card>();
			List<string> WhiteList = new List<string>();
			List<string> BlackList = new List<string>();
			int MaxManaCost = 2;
			bool AllowDoublon = true;
			
			if( opponentClass == Card.CClass.MAGE)
			{
				BlackList.Add("EX1_004"); //young priest					
                BlackList.Add("CS2_188"); //abusive sergeant
			}
			
            if (opponentClass == Card.CClass.DRUID || opponentClass == Card.CClass.ROGUE )
            {
				bool hasTaunt = false;
				foreach(Card c in Choices)
				{
					if(c.IsTaunt)
						hasTaunt = true;
				}
				if(!hasTaunt)
					BlackList.Add("EX1_004"); //young priest					
					BlackList.Add("CS2_188"); //abusive sergeant
            }
			
			if(Choices.Count > 3)
			{
				WhiteList.Add("EX1_014");//Mukla
			}
			
			WhiteList.Add("EX1_319");//FlameImp
			
			
			/* Setup WhiteList */ 
			WhiteList.Add("GAME_005");//Coin

			/* Setup BlackList */
			
            BlackList.Add("EX1_308"); //SF
            BlackList.Add("EX1_316"); //PO
			
			foreach(Card c in Choices)
			{
				foreach(string s in WhiteList)
				{
					bool alreadyHasOne = false;
					foreach(Card ccc in CardsToKeep)
					{
						if(ccc.template.Id == c.template.Id)
							alreadyHasOne = true;
					}
				
					if(c.template.Id == s && (!alreadyHasOne || AllowDoublon))
						CardsToKeep.Add(c);
				}
				bool isBlackListed = false;
				foreach(string s in BlackList)
				{
					if(c.template.Id == s)
						isBlackListed = true;
				}
				if(c.CurrentCost >= MaxManaCost || isBlackListed || CardsToKeep.Contains(c))
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
            return true;
        }
		
		public override bool ShouldAttackWithWeapon(Board board)
        {
			if(board.WeaponFriend != null)
				if(board.WeaponFriend.template.Id == "EX1_366")
					return false;
					
			bool hasOtherPlayableCard = false;
			
			foreach(Card c in board.Hand)
			{
				if(c.CurrentCost <= board.ManaAvailable && c.ShouldBePlayed(board))
				{
					hasOtherPlayableCard = true;
				}
			}
					
			if(board.WeaponFriend.CurrentAtk == 1 &&  board.WeaponFriend.CurrentDurability == 2 && (board.HasCardInHand("CS2_074") || hasOtherPlayableCard || board.ManaAvailable < 2))
				return false;
			
            return true;
        }

        public override bool ShouldAttackTargetWithWeapon(Board board,Card weapon,Card target)
        {
				if(target.Type == Card.CType.HERO && !board.HasWeaponInHand() && target.CurrentHealth + target.CurrentArmor > 15)
					return false;
				
				if(target.Type == Card.CType.HERO && (board.WeaponFriend.template.Id == "EX1_411") && target.CurrentHealth + target.CurrentArmor > board.WeaponFriend.CurrentAtk)
					return false;
				
            return true;
        }
		
    }
}
