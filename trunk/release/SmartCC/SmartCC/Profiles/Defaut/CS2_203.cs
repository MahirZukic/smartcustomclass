using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Ironbeak Owl

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_203 : Behavior
    {
		public bCS2_203() : base()
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
			
			if(target.IsFriend)
			{
				if(!target.HasBadBuffs())
					return false;
			}
			if(!target.IsFriend && !target.HasGoodBuffs())
				return false;
			if(!target.IsFriend && target.HasBadBuffs())
				return false;
            return true;
		}

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
