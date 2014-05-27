using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Holy Smite

namespace HREngine.Bots
{
	[Serializable]
    public class bCS1_130 : Behavior
    {
		public bCS1_130() : base()
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
