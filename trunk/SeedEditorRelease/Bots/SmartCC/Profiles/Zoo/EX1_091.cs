using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Cabal Shadow Priest

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_091 : Behavior
    {
		public bEX1_091() : base()
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
            if (target.CurrentAtk > 2)
                return false;
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
