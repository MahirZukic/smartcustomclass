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
			bool PlayableMinionInHand = false;
			foreach(Card c in board.Hand)
			{
				if(c.template.Id == "EX1_310")
				{
					continue;
				}
					
				if(c.CurrentCost <= board.ManaAvailable && c.Type == Card.CType.MINION)
				{
					PlayableMinionInHand = true;
					break;
				}
			}
			
			if(PlayableMinionInHand && board.Hand.Count < 4)
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
