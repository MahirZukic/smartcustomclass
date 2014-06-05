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
			int MaxManaCost = 2;
			
			
			
			/* Setup WhiteList */ 
			
			/* Setup BlackList */
			
			
			
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
				if(c.CurrentCost > MaxManaCost || isBlackListed ||CardsToKeep.Contains(c))
					continue;
					
				CardsToKeep.Add(c);
			}
			
            return CardsToKeep;
        }
		
		public override bool ShouldPlayMoreMinions(Board board)
        {
            return true;
        }
		
		public override bool ShouldAttackWithWeapon(Board board)
        {
            return true;
        }

        public override bool ShouldAttackTargetWithWeapon(Card weapon,Card target)
        {
            return true;
        }
		
    }
}
