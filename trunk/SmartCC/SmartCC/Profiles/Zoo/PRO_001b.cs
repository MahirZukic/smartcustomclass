using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Rogues Do It...

namespace HREngine.Bots
{
	[Serializable]
    public class bPRO_001b : Behavior
    {
		public bPRO_001b() : base()
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
