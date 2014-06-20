using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Darkscale Healer

namespace HREngine.Bots
{
	[Serializable]
    public class bDS1_055 : Behavior
    {
		public bDS1_055() : base()
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
