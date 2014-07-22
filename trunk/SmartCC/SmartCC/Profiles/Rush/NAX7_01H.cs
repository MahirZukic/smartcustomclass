using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Instructor Razuvious

namespace HREngine.Bots
{
	[Serializable]
    public class bNAX7_01H : Behavior
    {
		public bNAX7_01H() : base()
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
		
		public override int GetHandValue(Board board)
		{
			return 5;
		}
    }
}
