using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Power of the Horde

namespace HREngine.Bots
{
	[Serializable]
    public class bPRO_001c : Behavior
    {
		public bPRO_001c() : base()
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
		
    }
}
