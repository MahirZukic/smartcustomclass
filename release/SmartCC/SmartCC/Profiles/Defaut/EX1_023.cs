using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Silvermoon Guardian

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_023 : Behavior
    {
		public bEX1_023() : base()
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
