using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Arcane Golem

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_089 : Behavior
    {
		public bEX1_089() : base()
        {
            
        }
		
		public override bool ShouldBePlayed(Board board)
        {
			if(board.TurnCount < 5)
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
