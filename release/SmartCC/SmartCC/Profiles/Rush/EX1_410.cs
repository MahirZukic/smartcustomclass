using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Shield Slam

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_410 : Behavior
    {
		public bEX1_410() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
            if (board.HeroFriend.CurrentArmor < 1)
                return false;
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
