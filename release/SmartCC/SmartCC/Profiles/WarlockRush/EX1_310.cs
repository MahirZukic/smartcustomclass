using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Doomguard

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_310 : Behavior
    {
		public bEX1_310() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			int sum = 0;
			foreach(Card c in board.MinionFriend)
			{
				sum += c.CurrentAtk;
			}
			if(sum + 5 >= board.HeroEnemy.CurrentHealth)
				return true;
				
			int PlayableMinionInHand = 0;
			foreach(Card c in board.Hand)
			{
				if(c.template.Id == "EX1_310")
				{
					continue;
				}
					
				if(c.CurrentCost <= board.ManaAvailable && c.Type == Card.CType.MINION)
				{
					PlayableMinionInHand++;
					break;
				}
			}
			
			if(PlayableMinionInHand > 2 && board.Hand.Count < 4)
			{
				return false;
			}
			
            return true;
        }

        public override bool ShouldAttack(Board board)
        {
            return true;
        }

        public override bool ShouldAttackTarget(Card target)
        {
            return true;
        }
		
		public override bool ShouldBePlayedOnTarget(Card target)
        {
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
