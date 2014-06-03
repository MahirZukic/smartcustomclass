using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Inner Fire

namespace HREngine.Bots
{
	[Serializable]
    public class bCS1_129 : Behavior
    {
		public bCS1_129() : base()
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
			if(!target.IsFriend && target.CurrentAtk <= target.CurrentHealth)
				return false;
		
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
