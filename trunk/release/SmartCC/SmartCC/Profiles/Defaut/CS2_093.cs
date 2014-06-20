using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Consecration

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_093 : Behavior
    {
		public bCS2_093() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			if(board.MinionEnemy.Count < 2)
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
