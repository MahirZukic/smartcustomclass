using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Wild Pyromancer

namespace HREngine.Bots
{
	[Serializable]
    public class bNEW1_020 : Behavior
    {
		public bNEW1_020() : base()
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
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
		public override int GetMinionValue(Board board)
        {
			if(board.MinionEnemy.Count > 2 || board.HeroFriend.CurrentHealth < 20)
				return 0;
            return 8;
        }
    }
}
