using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Lesser Heal

namespace HREngine.Bots
{
	[Serializable]
    public class bCS1h_001 : Behavior
    {
		public bCS1h_001() : base()
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
			if(board.HealFactor > 0 && target.Type == Card.CType.HERO && !target.IsFriend)
				return false;
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
