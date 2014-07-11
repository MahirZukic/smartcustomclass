using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Hungry Crab

namespace HREngine.Bots
{
	[Serializable]
    public class bNEW1_017 : Behavior
    {
		public bNEW1_017() : base()
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
            if (target.Race != Card.CRace.MURLOC)
                return false;
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
    }
}
