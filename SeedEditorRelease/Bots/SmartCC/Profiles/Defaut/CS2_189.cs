using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Elven Archer

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_189 : Behavior
    {
		public bCS2_189() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
            return true;
        }

        public override bool ShouldAttack(Board board)
        {
            return true;
        }

        public override bool ShouldAttackTarget(Board board,Card target)
        {
            return true;
        }
		
		public override bool ShouldBePlayedOnTarget(Board board,Card target)
        {
			int mortalCount = 0;
	        foreach(Card c in board.Hand)
            {
                if (c.template.Id == "EX1_302") 
		            mortalCount++;
            }
			if (mortalCount > 1) 
		        return true;

			if(target.Type == Card.CType.HERO && target.CurrentHealth <= 10 && !target.IsFriend)
				return true;
				
			if(target.IsFriend && !target.HasEnrage)
				return false;
			
			if(!target.IsFriend && target.IsDivineShield)
				return true;
			
			if(!target.IsFriend && target.CurrentHealth > 1)
				return false;
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
