using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Sir Zeliek

namespace HREngine.Bots
{
	[Serializable]
    public class bNAX9_04H : Behavior
    {
		public bNAX9_04H() : base()
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
