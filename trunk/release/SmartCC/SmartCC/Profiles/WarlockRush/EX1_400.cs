using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Whirlwind

namespace HREngine.Bots
{
	[Serializable]
    public class bEX1_400 : Behavior
    {
		public bEX1_400() : base()
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
