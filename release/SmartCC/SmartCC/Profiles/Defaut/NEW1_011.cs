using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Kor\'kron Elite

namespace HREngine.Bots
{
	[Serializable]
    public class bNEW1_011 : Behavior
    {
		public bNEW1_011() : base()
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
