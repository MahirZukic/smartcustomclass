using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//Mark of the Wild

namespace HREngine.Bots
{
	[Serializable]
    public class bCS2_009 : Behavior
    {
		public bCS2_009() : base()
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

        public override bool ShouldAttackTarget(Board board,Card target)
        {
            return true;
        }
		
		public override bool ShouldBePlayedOnTarget(Board board,Card target)
        {
            return true;
        }

        public override int GetPriorityPlay(Board board)
        {
            return 1;
        }
		
		public override int GetHandValue(Board board)
		{
			return 2;
		}
		
    }
}
