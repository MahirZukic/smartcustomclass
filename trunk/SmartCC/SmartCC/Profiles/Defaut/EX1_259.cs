using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Lightning Storm

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_259 : Behavior
    {
		public bEX1_259() : base()
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
            return 2;
        }
		
		public override int GetHandValue(Board board)
		{
			return 11;
		}
    }
}
