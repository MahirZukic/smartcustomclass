using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Life Tap

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_056 : Behavior
    {
		public bCS2_056() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
             if (board.HeroFriend.CurrentHealth < 10 || board.Hand.Count > 5)
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
            return 10;
        }
		
    }
}
