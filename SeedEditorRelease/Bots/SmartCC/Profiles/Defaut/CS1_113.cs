using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Mind Control

namespace HREngine.Bots
{
	[Serializable]
    public class bCS1_113 : Behavior
    {
		public bCS1_113() : base()
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
