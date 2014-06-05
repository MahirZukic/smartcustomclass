using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Violet Apprentice

namespace HREngine.Bots
{
	[Serializable]
    public class bNEW1_026t : Behavior
    {
		public bNEW1_026t() : base()
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
