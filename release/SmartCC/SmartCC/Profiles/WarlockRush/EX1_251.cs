using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Forked Lightning

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_251 : Behavior
    {
		public bEX1_251() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
           if (board.MinionEnemy.Count < 2)
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
