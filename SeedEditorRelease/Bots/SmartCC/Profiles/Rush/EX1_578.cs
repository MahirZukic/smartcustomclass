using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Savagery

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_578 : Behavior
    {
		public bEX1_578() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
            if (board.HeroFriend.CurrentAtk < 1)
                return false;
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
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
