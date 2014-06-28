using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//I Am Murloc

namespace HREngine.Bots
{
	[Serializable]
    public class bPRO_001a : Behavior
    {
		public bPRO_001a() : base()
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
