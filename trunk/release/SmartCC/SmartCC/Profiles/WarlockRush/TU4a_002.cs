using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Riverpaw Gnoll

namespace HREngine.Bots
{
	[Serializable]
    public class bTU4a_002 : Behavior
    {
		public bTU4a_002() : base()
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