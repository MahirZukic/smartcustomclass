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

        public override bool ShouldAttackTarget(Card target)
        {
            return true;
        }
		
		public override bool ShouldBePlayedOnTarget(Card target)
        {
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
