using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Abusive Sergeant

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_188 : Behavior
    {
		public bCS2_188() : base()
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
            if (target.IsFriend && target.CanAttack)
                return true;
            return false;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
